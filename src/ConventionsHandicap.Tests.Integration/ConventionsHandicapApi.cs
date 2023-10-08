using Anabasis.Common;
using Anabasis.Common.Configuration;
using Anabasis.Identity;
using ConventionsHandicap.App;
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
using NSubstitute;
using NSubstitute.Extensions;
using System;
using System.IO;

namespace ConventionsHandicap.Tests.Integration
{
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

                serviceCollection.AddTransient((_) => Substitute.For<IUserMailService>());

                ServicesSetup.ConfigureServiceCollection(appContext, serviceCollection, configuration.ConfigurationRoot);

                serviceCollection.AddControllers()
                .AddNewtonsoftJson(options =>
                {

                    var jsonSerializerSettings = options.SerializerSettings;
                    var defaultJsonSerializerSettings = Json.GetDefaultJsonSerializerSettings();

                    jsonSerializerSettings.ReferenceLoopHandling = defaultJsonSerializerSettings.ReferenceLoopHandling;
                    jsonSerializerSettings.NullValueHandling = defaultJsonSerializerSettings.NullValueHandling;
                    jsonSerializerSettings.DateTimeZoneHandling = defaultJsonSerializerSettings.DateTimeZoneHandling;
                    jsonSerializerSettings.Formatting = defaultJsonSerializerSettings.Formatting;
                    jsonSerializerSettings.DateFormatHandling = defaultJsonSerializerSettings.DateFormatHandling;

                    jsonSerializerSettings.Converters = defaultJsonSerializerSettings.Converters;

                    jsonSerializerSettings.StringEscapeHandling = defaultJsonSerializerSettings.StringEscapeHandling;

                    Json.SetDefaultJsonSerializerSettings(jsonSerializerSettings);

                });

                serviceCollection.AddMvc().AddApplicationPart(typeof(ConventionsHandicapController).Assembly);

            });


            return base.CreateHost(builder);
        }
    }
}
