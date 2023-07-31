using Anabasis.Common;
using Anabasis.Common.Configuration;
using ConventionsHandicap.App;
using ConventionsHandicap.Controller;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSubstitute.Extensions;
using NUnit.Framework;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Tests.Integration
{
    public partial class Program { }


    public class ConventionsHandicapApi : WebApplicationFactory<Program>
    {

        protected override IHostBuilder? CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder();
        }
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseContentRoot(Directory.GetCurrentDirectory());

            var configuration = Configuration.GetAnabasisConfigurations();

            var appContext = new AnabasisAppContext("test", "test", new Version("1.0.0"));

            var conventionsHandicapConfiguration = new ConventionsHandicapConfigurationOptions();
            configuration.ConfigurationRoot.GetSection("conventionsHandicapConfigurationOptions").Bind(conventionsHandicapConfiguration);

            builder.ConfigureWebHostDefaults(webHostBuilder => webHostBuilder.UseTestServer().Configure(appBuilder =>
            {
                appBuilder.UseRouting();

                appBuilder.UseAuthentication();
                appBuilder.UseAuthorization();

                appBuilder.UseEndpoints(endpoints =>
                {
                    endpoints.MapDefaultControllerRoute();
                });


            }));


            builder.ConfigureServices(serviceCollection =>
             {

                 serviceCollection.AddDbContext<ConventionHandicapDbContext>((builder) =>
                 {
                     builder.UseInMemoryDatabase("Tests");
                 });

                 ServicesSetup.ConfigureServiceCollection(appContext, serviceCollection, configuration.ConfigurationRoot);

                 serviceCollection.AddControllers();

                 serviceCollection.AddMvc().AddApplicationPart(typeof(ConventionsHandicapWorkspaceController).Assembly);

             });


            return base.CreateHost(builder);
        }
    }


    [TestFixture]
    public class TestUsers
    {
        private Task EnsureRootUserIsCreated()
        {
            return Task.CompletedTask;
        }

        [Test]
        public async Task ShouldLogin()
        {

            var conventionsHandicapApi = new ConventionsHandicapApi();

            var httpClient = conventionsHandicapApi.Server.CreateClient();

            var conventionHandicapDbContext = conventionsHandicapApi.Services.GetService<ConventionHandicapDbContext>();

            var body = "{\"workspaceId\": \"91181DDC-6AE5-4CA1-B07C-623B876EB670\",\"userName\": \"thomas.raynal2@gmail.com\",\"password\": \"pwd\"}";

            var httpResponseMessage = await httpClient.PostAsync("v1/login", new StringContent(body, Encoding.UTF8, "application/json"));

            var content = await httpResponseMessage.Content.ReadAsStringAsync();


        }
    }
}