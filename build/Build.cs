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
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.IO.XmlTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using Logger = Serilog.Log;

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

    private const string CodeGenDotNetFrameworkVersion = "net6.0";

    private static string GetPackageVersionInternal(string projectPath, string packageName)
    {
        return XmlPeek(projectPath, $"/Project/ItemGroup/PackageReference[@Include='{packageName}']/@Version").FirstOrDefault();
    }

    public static bool HasPackageVersion(string projectPath, string packageName, string expectedVersion)
    {
        return GetPackageVersionInternal(projectPath, packageName) == expectedVersion;
    }

    public static bool HasPackageVersion(AbsolutePath project, string packageName, string expectedVersion)
    {
       return GetPackageVersionInternal(project, packageName) == expectedVersion;
    }

    public static void DotNetAddReference(AbsolutePath projectPath, AbsolutePath referenceToAddProjectPath)
    {
        var projectReferences = XmlPeek(projectPath, $"/Project/ItemGroup/ProjectReference/@Include");
        var projectDirectory = Path.GetDirectoryName(projectPath);

        foreach (var projectReference in projectReferences)
        {
            try
            {
                var path = (AbsolutePath)Path.Combine(projectDirectory, projectReference);

                if (path.Equals(referenceToAddProjectPath))
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

    public static void DotNetAddPackage(AbsolutePath projectPath, PackageDefinition packageDefinition)
    {
        if (!HasPackageVersion(projectPath, packageDefinition.Name, packageDefinition.Version))
        {
        
            try
            {
                DotNet($"add {projectPath} package {packageDefinition.Name} -v {packageDefinition.Version}");
            }
            catch (Exception exception)
            {
                Logger.Warning($"There was an exception trying run a dotnet add with project {projectPath}, package {packageDefinition.Name}, version {packageDefinition.Version}");
                Logger.Warning($"{exception}");
            }

        }
    }

    Target CodeGenInstallCodeGenUp => _ => _
      .Requires(() => CodeGenProjectKind, () => CodeGenProjectName, () => CodeGenProjectKind, () => CodeGenOpenApiSpecLocalPath)
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

      Target CodeGenCreateProject => _ => _
      .DependsOn(CodeGenInstallCodeGenUp)
      .Requires(()=> CodeGenProjectKind, () => CodeGenProjectName, () => CodeGenProjectKind, () => CodeGenOpenApiSpecLocalPath)
      .Executes(() =>
      {
        
          var outputDirectory = $"./src/{CodeGenProjectName}";


          if (CodeGenForce)
          {
              if (Directory.Exists(outputDirectory))
              {
                  Directory.Delete(outputDirectory, true);
              }


              var dotNetNewOutputs = DotNet($"new {CodeGenProjectKind} -n {CodeGenProjectName} -f {CodeGenDotNetFrameworkVersion} -o ./src/{CodeGenProjectName} --force");

              foreach (var dotNetNewOutput in dotNetNewOutputs)
              {
                  Logger.Information(dotNetNewOutput.Text);
              }

          }
      });

        Target CodeGenGenerateFromOpenApiSpec => _ => _
        .DependsOn(CodeGenCreateProject)
        .Requires(() => CodeGenProjectKind, () => CodeGenProjectName, () => CodeGenProjectKind, () => CodeGenOpenApiSpecLocalPath)
        .Executes(() =>
        {

            var outputDirectory = $"./src/{CodeGenProjectName}";
            var outputDirectoryGeneratedFolder = Path.Combine(outputDirectory, "_Generated");

            if (Directory.Exists(outputDirectoryGeneratedFolder))
            {
                Directory.Delete(outputDirectoryGeneratedFolder, true);
            }
 
            var startProcess = ProcessTasks.StartProcess("CodegenUP", $"-s {CodeGenOpenApiSpecLocalPath} -o {outputDirectory} -t ./_build/CodeGenTemplates", logOutput: true);

            if (!startProcess.WaitForExit())
            {
                throw new Exception("!StartProcess().WaitForExit()");
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


      });


}
