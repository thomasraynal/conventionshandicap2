using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
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
