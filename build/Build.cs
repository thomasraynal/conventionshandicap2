using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;
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

[CheckBuildProjectConfigurations]
class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.DeployHeroku);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
    [Solution] readonly Solution Solution;

    //public static AbsolutePath DotNetNewIfNotExists(ProjectKind kind, string name, AbsolutePath directory,
    //bool useOldFramework)
    //{
    //    var projFile = directory / $"{name}.csproj";
    //    if (!FileExists(projFile))
    //    {

    //        DotNet($"new {kind.GetDotNetNewKind()} -n {name} -f {kind.GetTargetFramework(useOldFramework)} -o {directory} --force");

    //        //pending dotnet new templates
    //        {
    //            var generatedNetCoreVersion = "netcoreapp2.1";
    //            var targetNetCoreVersion = "netcoreapp2.2";
    //            var netFrameworkVersion = "net462";

    //            var netVersionReplacement = useOldFramework ? netFrameworkVersion : targetNetCoreVersion;

    //            var newProjFileContent = File.ReadAllText(projFile).Replace(generatedNetCoreVersion, netVersionReplacement);

    //            File.WriteAllText(projFile, newProjFileContent);
    //        }

    //        // TODO: GetDotNetNewKind should also give instructions for cleanup, so the maintenance is in the same place
    //        switch (kind)
    //        {
    //            case ProjectKind.ClassLib:
    //                DeleteFile(directory / "Class1.cs");
    //                break;
    //            case ProjectKind.WebApi:
    //                DeleteDirectory(directory / "Controllers");
    //                break;
    //            case ProjectKind.Tests:
    //                DeleteFile(directory / "UnitTest1.cs");
    //                break;
    //            case ProjectKind.Console:
    //                // leave program.cs
    //                break;
    //            default:
    //                throw new ArgumentOutOfRangeException(nameof(kind));
    //        }
    //    }
    //    return projFile;
    //}

    [Parameter]
    public bool CodeGenForce;
    [Parameter]
    public string CodeGenProjectKind;
    [Parameter]
    public string CodeGenProjectName;
    [Parameter]
    public string CodeGenOpenApiSpecLocalPath;

    private const string CodeGenDotNetFrameworkVersion = "net6.0";

    Target CodeGenInstallCodeGenUp => _ => _
     .Requires(() => CodeGenProjectKind, () => CodeGenProjectName, () => CodeGenProjectKind, () => CodeGenOpenApiSpecLocalPath)
       .ProceedAfterFailure()
      .Executes(() =>
      {
          try
          {

              var dotNetToolInstallOutputs = DotNetTasks.DotNetToolInstall((dotNetToolInstallSettings) =>
              {
                  dotNetToolInstallSettings = dotNetToolInstallSettings.SetGlobal(true);
                  dotNetToolInstallSettings = dotNetToolInstallSettings.SetPackageName("CodegenUP");
                  
                  return dotNetToolInstallSettings;

              });

              foreach (var dotNetToolInstallOutput in dotNetToolInstallOutputs)
              {
                  Console.WriteLine(dotNetToolInstallOutput.Text);
              }

          }
          catch(Exception ex)
          {
              Console.WriteLine(ex.ToString());
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


              var dotNetNewOutputs = DotNetTasks.DotNet($"new {CodeGenProjectKind} -n {CodeGenProjectName} -f {CodeGenDotNetFrameworkVersion} -o ./src/{CodeGenProjectName} --force");

              foreach (var dotNetNewOutput in dotNetNewOutputs)
              {
                  Console.WriteLine(dotNetNewOutput.Text);
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
