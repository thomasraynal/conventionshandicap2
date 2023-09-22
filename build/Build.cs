using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using CodeGen;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.Build.Utilities;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.IO.XmlTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using Logger = Serilog.Log;
using YamlDotNet.Core;
using Anabasis.Common;
using Microsoft.Azure.KeyVault.Models;

[CheckBuildProjectConfigurations]
class Build : NukeBuild
{
    public static int Main() => Execute<Build>(build => build.DeployHeroku);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
    [Solution] readonly Solution Solution;

    [Parameter]
    public bool CodeGenForce;
    [Parameter]
    public string CodeGenProjectKind;
    [Parameter]
    public string CodeGenProjectName;
    [Parameter]
    public string CodeGenOpenApiSpecLocalPath;

    private CodeGenSpec CodeGenSpec;

    private const string CodeGenDotNetFrameworkVersion = "net6.0";

    public static void DotNetAddReference(string projectPath, string referenceToAddProjectPath)
    {
        var projectReferences = XmlPeek(projectPath, $"/Project/ItemGroup/ProjectReference/@Include");
        var projectDirectory = Path.GetDirectoryName(projectPath);

        foreach (var projectReference in projectReferences)
        {
            try
            {
                var path = Path.Combine(projectDirectory, projectReference);

                if (path == referenceToAddProjectPath)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                Logger.Warning(ex.Message);
            }
        }

        DotNet($"add {projectPath} reference {referenceToAddProjectPath}");
    }

    public static void DotNetAddPackage(string projectPath, PackageDefinition packageDefinition)
    {

        try
        {
            var packageAddCommand = $"add {projectPath} package {packageDefinition.Name}";

            if (null != packageDefinition.Version)
            {
                packageAddCommand += $" -v {packageDefinition.Version}";
            }

            DotNet(packageAddCommand);
        }
        catch (Exception exception)
        {
            Logger.Warning($"There was an exception trying run a dotnet add with project {projectPath}, package {packageDefinition.Name}, version {packageDefinition.Version}");
            Logger.Warning($"{exception}");
        }

    }

    Target CodeGenInstallCodeGenUp => _ => _
      .Requires(() => CodeGenProjectKind, () => CodeGenProjectName, () => CodeGenOpenApiSpecLocalPath)
      .ProceedAfterFailure()
      .Executes(() =>
      {
          try
          {

              var dotNetToolInstallOutputs = DotNetToolInstall((dotNetToolInstallSettings) =>
              {
                  dotNetToolInstallSettings = dotNetToolInstallSettings.SetGlobal(true);
                  dotNetToolInstallSettings = dotNetToolInstallSettings.SetPackageName("CodegenUP");
                  
                  return dotNetToolInstallSettings;

              });

              foreach (var dotNetToolInstallOutput in dotNetToolInstallOutputs)
              {
                  Logger.Information(dotNetToolInstallOutput.Text);
              }

          }
          catch(Exception ex)
          {
              Logger.Information($"{ex}");
          }

      });

     Target CodeGenParseApiSpec=> _ => _
      .DependsOn(CodeGenInstallCodeGenUp)
      .Requires(() => CodeGenProjectKind, () => CodeGenProjectName, () => CodeGenOpenApiSpecLocalPath)
      .ProceedAfterFailure()
      .Executes(() =>
      {
          var deserializer = new DeserializerBuilder()
            .IgnoreUnmatchedProperties()
          .Build();

          var yamlString = File.ReadAllText(CodeGenOpenApiSpecLocalPath);

          CodeGenSpec = deserializer.Deserialize<CodeGenSpec>(yamlString);

          Logger.Information(CodeGenSpec.ToJson());

      });

    Target CodeGenCreateProject => _ => _
      .DependsOn(CodeGenParseApiSpec)
      .Requires(()=> CodeGenProjectKind, () => CodeGenProjectName,  () => CodeGenOpenApiSpecLocalPath)
      .Executes(() =>
      {
        
          var outputDirectory = $"./src/{CodeGenProjectName}";
          var projectDirectory = $"./src/{CodeGenProjectName}";
          var projectFilePath = Path.Combine(projectDirectory, CodeGenProjectName + ".csproj");

          var doesProjectExist = Directory.Exists(outputDirectory);

          if (CodeGenForce || !doesProjectExist)
          {
              Logger.Information($"Creating project {projectFilePath}");

              if (doesProjectExist)
              {
                  Directory.Delete(outputDirectory, true);
              }

              var dotNetNewOutputs = DotNet($"new {CodeGenProjectKind} -n {CodeGenProjectName} -f {CodeGenDotNetFrameworkVersion} -o {projectDirectory} --force");

              foreach (var dotNetNewOutput in dotNetNewOutputs)
              {
                  Logger.Information(dotNetNewOutput.Text);
              }

              if (null != CodeGenSpec?.CodeGenSpecProduct?.AppPackageReferences)
              {
                  foreach (var appPackageReference in CodeGenSpec?.CodeGenSpecProduct?.AppPackageReferences)
                  {
                      Logger.Information($"Adding package reference {appPackageReference}");

                      DotNetAddPackage(projectFilePath, new PackageDefinition() { Name = appPackageReference });
                  }
              }

              if (null != CodeGenSpec?.CodeGenSpecProduct?.AppProjectReferences)
              {
                  foreach (var appProjectReference in CodeGenSpec?.CodeGenSpecProduct?.AppProjectReferences)
                  {

                      Logger.Information($"Adding project reference {appProjectReference}");

                      DotNetAddReference(projectFilePath, appProjectReference);
                  }
              }
          }
          else
          {
              Logger.Information($"Project {projectFilePath} already exist");
          }

      });

    Target CodeGenGenerateFromOpenApiSpec => _ => _
    .DependsOn(CodeGenCreateProject)
    .Requires(() => CodeGenProjectKind, () => CodeGenProjectName, () => CodeGenOpenApiSpecLocalPath)
    .Executes(() =>
    {

        var outputDirectory = $"./src/{CodeGenProjectName}";

        Logger.Information($"Generating {outputDirectory}...");

        var outputDirectoryGeneratedFolders = Directory.GetDirectories(outputDirectory, string.Empty, SearchOption.AllDirectories).Where(directory => directory.Contains("_Generated"));

        foreach (var directory in outputDirectoryGeneratedFolders)
        {
            Logger.Information($"Deleting {directory}...");
            Directory.Delete(directory, true);
        }

        var startProcess = ProcessTasks.StartProcess("CodegenUP", $"-s {CodeGenOpenApiSpecLocalPath} -o {outputDirectory} -t {BuildProjectDirectory / "CodeGenTemplates"}", logOutput: true);

        if (!startProcess.WaitForExit())
        {
            throw new Exception("!StartProcess().WaitForExit()");
        }

        if (startProcess.ExitCode > 0)
        {
            throw new Exception($"Exit code => {startProcess.ExitCode}");
        }

    });


    //Target NgBuild => _ => _
    //    .Executes(() =>
    //    {

    //        var startProcess = ProcessTasks.StartProcess("ng", "build --prod", logOutput: true);

    //        if (!startProcess.WaitForExit())
    //            throw new Exception("!StartProcess().WaitForExit()");

    //    });

    //Target CopyNgBuild => _ => _
    //    .DependsOn(NgBuild)
    //    .Executes(() =>
    //    {
    //        var startProcess = ProcessTasks.StartProcess("cp", "-R dist/ConventionsHandicap/. service/ConventionsHandicap/wwwroot", logOutput: true);

    //        if (!startProcess.WaitForExit())
    //            throw new Exception("!StartProcess().WaitForExit()");

    //    });

    Target HerokuLogin => _ => _
      //.DependsOn(CopyNgBuild)
      .Executes(() =>
      {

          var startProcess = ProcessTasks.StartProcess("heroku", "container:login", logOutput: true);

          if (!startProcess.WaitForExit())
          {
              throw new Exception("!StartProcess().WaitForExit()");
          }
          if (startProcess.ExitCode > 0)
          {
              throw new Exception($"Exit code => {startProcess.ExitCode}");
          }

      });

    Target PushHeroku => _ => _
        .DependsOn(HerokuLogin)
        .Executes(() =>
        {
            var startProcess = ProcessTasks.StartProcess("heroku", "container:push web -a conventions-handicap", Solution.Directory, logOutput: true);

            if (!startProcess.WaitForExit())
            {
                throw new Exception("!StartProcess().WaitForExit()");
            }
            if (startProcess.ExitCode > 0)
            {
                throw new Exception($"Exit code => {startProcess.ExitCode}");
            }

        });

    Target DeployHeroku => _ => _
      .DependsOn(PushHeroku)
      .Executes(() =>
      {
          var startProcess = ProcessTasks.StartProcess("heroku", "container:release web -a conventions-handicap", Solution.Directory, logOutput: true);

          if (!startProcess.WaitForExit())
          {
              throw new Exception("!StartProcess().WaitForExit()");
          }
          if (startProcess.ExitCode > 0)
          {
              throw new Exception($"Exit code => {startProcess.ExitCode}");
          }

      });


}
