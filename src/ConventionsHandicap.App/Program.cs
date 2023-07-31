﻿using Anabasis.Api;
using Anabasis.Identity;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Services;
using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Contracts;
using ConventionsHandicap.App.Features.CertificateDemand.Contracts;
using ConventionsHandicap.App.Features.CertificateDemand.Services;
using ConventionsHandicap.App.Features.CertificateDemand.Shared;
using ConventionsHandicap.App.Services;
using ConventionsHandicap.App.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace ConventionsHandicap.Tests.App
{

    internal class Program
    {
        static void Main(string[] _)
        {
            var apiPort = int.Parse(Environment.GetEnvironmentVariable("PORT") ?? "80");

            WebAppBuilder.Create<Program>(
               apiPort: apiPort,
               useAuthorization: true,
#if DEBUG
                 useCors: true,
#else
                  useCors: false,
#endif
               useSwaggerUI: true,
               configureServiceCollection: (anabasisAppContext, serviceCollection, configurationRoot) =>
               {

                   var conventionsHandicapConfiguration = serviceCollection.WithConfiguration<ConventionsHandicapConfigurationOptions>(configurationRoot);

                   serviceCollection.AddSingleton(conventionsHandicapConfiguration);

                   serviceCollection.AddTransient<IJwtTokenService<ConventionsHandicapUser>, ConventionsHandicapTokenService>();
                   serviceCollection.AddTransient<IUserMailService, ConventionsHandicapUserMailService>();
                   serviceCollection.AddTransient<IConventionsHandicapWorkspaceService, ConventionsHandicapWorkspaceService>();
                   serviceCollection.AddTransient<IConventionsHandicapReferentialService, ConventionsHandicapReferentialService>();
                   serviceCollection.AddTransient<IConventionsHandicapMetadataService, ConventionsHandicapMetadataService>();
                   serviceCollection.AddTransient<IConventionsHandicapCertificateDemandService, ConventionsHandicapCertificateDemandService>();
                   serviceCollection.AddTransient<IConventionsHandicapCertificateDemandMailService, ConventionsHandicapCertificateDemandMailService>();
                   serviceCollection.AddTransient<IConventionHandicapMetadataFileStorage, ConventionHandicapMetadataFileStorage>();
                   serviceCollection.AddTransient<IConventionsHandicapGenerateCertificateService, ConventionsHandicapGenerateCertificateService>();
                   serviceCollection.AddTransient<IConventionHandicapMetadataFileStorage, ConventionHandicapMetadataFileStorage>();
                   serviceCollection.AddTransient<IConventionsHandicapFeaturesService, ConventionsHandicapFeaturesService>();
                   serviceCollection.AddTransient<IConventionsHandicapMailService, ConventionsHandicapMailService>();
                   serviceCollection.AddTransient<IConventionsHandicapCertificateDemandMailService, ConventionsHandicapCertificateDemandMailService>();

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

               },
               configureSwaggerGen: (swaggerGenOptions) =>
               {
                   swaggerGenOptions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                   {
                       Description = $@"JWT Authorization header using the Bearer scheme. 
                       Example: 'Bearer 12345abcdef'",
                       Name = "Authorization",
                       In = ParameterLocation.Header,
                       Type = SecuritySchemeType.ApiKey,
                       Scheme = "Bearer"
                   });

                   swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });
               },
               configureJson: (mvcNewtonsoftJsonOptionsExtensions) =>
               {
                   mvcNewtonsoftJsonOptionsExtensions.SerializerSettings.Converters.Add(new PropertyArrayDtoJsonConverter());
                   //mvcNewtonsoftJsonOptionsExtensions.SerializerSettings.Converters.Add(new ConventionHandicapUserTableStorageJsonConverter());
               },
               configureMiddlewares: (anabasisAppContext, app) =>
               {
                   app.UseFileServer();
               },
               configureApplicationBuilder: (anabasisAppContext, app) =>
               {
               })
               .Build()
               .Run();
        }
    }
}