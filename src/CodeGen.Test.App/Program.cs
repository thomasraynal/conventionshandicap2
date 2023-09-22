﻿using Anabasis.Api;
using ConventionsHandicap.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using ConventionsHandicap.App;

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
                   ServicesSetup.ConfigureServiceCollection(anabasisAppContext, serviceCollection, configurationRoot);
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