using Anabasis.Api;
using Anabasis.Common;
using Anabasis.Identity;
using ConventionsHandicap.App.Contracts;
using ConventionsHandicap.App.Services;
using ConventionsHandicap.App.Shared;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace ConventionsHandicap.App
{
    public static class ServicesSetup
    {
        public static void ConfigureServiceCollection(AnabasisAppContext anabasisAppContext, IServiceCollection serviceCollection, IConfigurationRoot? configurationRoot)
        {
          
            var conventionsHandicapConfiguration = serviceCollection.WithConfiguration<ConventionsHandicapConfigurationOptions>(configurationRoot);

            serviceCollection.AddSingleton(conventionsHandicapConfiguration);

            serviceCollection.AddTransient<IJwtTokenService<ConventionsHandicapUser>, ConventionsHandicapTokenService>();
            serviceCollection.AddTransient<IUserMailService, ConventionsHandicapUserMailService>();
            serviceCollection.AddTransient<IConventionsHandicapWorkspaceService, ConventionsHandicapWorkspaceService>();
            serviceCollection.AddTransient<IConventionsHandicapReferentialService, ConventionsHandicapReferentialService>();
            //serviceCollection.AddTransient<IConventionsHandicapMetadataService, ConventionsHandicapMetadataService>();
            //serviceCollection.AddTransient<IConventionsHandicapCertificateDemandService, ConventionsHandicapCertificateDemandService>();
            //serviceCollection.AddTransient<IConventionsHandicapCertificateDemandMailService, ConventionsHandicapCertificateDemandMailService>();
            //serviceCollection.AddTransient<IConventionHandicapMetadataFileStorage, ConventionHandicapMetadataFileStorage>();
            //serviceCollection.AddTransient<IConventionsHandicapGenerateCertificateService, ConventionsHandicapGenerateCertificateService>();
            //serviceCollection.AddTransient<IConventionHandicapMetadataFileStorage, ConventionHandicapMetadataFileStorage>();
            serviceCollection.AddTransient<IConventionsHandicapFeaturesService, ConventionsHandicapFeaturesService>();
            serviceCollection.AddTransient<IConventionsHandicapMailService, ConventionsHandicapMailService>();
            //serviceCollection.AddTransient<IConventionsHandicapCertificateDemandMailService, ConventionsHandicapCertificateDemandMailService>();

            serviceCollection.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            });

            serviceCollection.AddDbContext<ConventionHandicapDbContext>(options => options.UseSqlServer(conventionsHandicapConfiguration.SqlServerDbConnectionString));

            serviceCollection
            .AddIdentity<ConventionsHandicapUser, ConventionsHandicapIdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<ConventionsHandicapIdentityRole>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ConventionHandicapDbContext>();

            serviceCollection.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true; ;
                options.User.RequireUniqueEmail = true;
            });

            serviceCollection
                        .AddAuthentication(authenticationOptions =>
                        {
                            authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                            authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                            authenticationOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                        })
                        .AddJwtBearer(jwtBearerOptions =>
                        {
                            jwtBearerOptions.SaveToken = true;
                            jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                            {
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Consts.JwtKey)),
                                ValidateIssuerSigningKey = true,
                                ValidateIssuer = false,
                                ValidateAudience = false,
                                ValidateLifetime = true,
                                ClockSkew = TimeSpan.Zero
                            };
                        });


            serviceCollection.AddAuthorization();
        }
    }
}
