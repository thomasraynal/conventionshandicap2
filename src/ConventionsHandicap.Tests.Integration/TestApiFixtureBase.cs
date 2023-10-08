using Anabasis.Common.Shared;
using Anabasis.Identity.Dto;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Anabasis.Identity.Shared;
using Microsoft.EntityFrameworkCore;
using Anabasis.Common;

namespace ConventionsHandicap.Tests.Integration
{
    public abstract class TestApiFixtureBase
    {
        public static readonly string RootUserPassword = "057051c5-aa4e-48b1-9c72-a883e4019b0d";
        public static readonly string RootUserName = "thomas.raynal2@gmail.com";

        public static readonly Guid CertificateDemandFeatureId = Guid.Parse("62e4fe1e-1552-4390-ba29-cdb4c5d67e27");
        public static readonly Guid CapHandiCapWorkspaceId = Guid.Parse("13509813-bf9c-45e5-b377-546ad20c8a99");

#nullable disable

        protected ConventionsHandicapApi ConventionsHandicapApi;
        protected Guid RootAdminUserId;

#nullable enable

        private async Task EnsureWorkspaceIsCreatedAsync()
        {
            var serviceProvider = ConventionsHandicapApi.Services;

            var serviceScopeFactory = serviceProvider.GetService<IServiceScopeFactory>();

            using (var scope = serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var workspace = new ConventionsHandicapWorkspace()
                    {
                        Name = "Cap Handi Cap",
                        Id = CapHandiCapWorkspaceId
                    };

                    var feature = new ConventionsHandicapFeature()
                    {
                        Id = CertificateDemandFeatureId,
                        Name = "CertficateDemand"
                    };

                    feature.Workspaces.Add(workspace);
                    workspace.Features.Add(feature);

                    conventionHandicapDbContext.ConventionsHandicapWorkspaces.Add(workspace);

                    await conventionHandicapDbContext.SaveChangesAsync();
                }

            }
        }
        private async Task EnsureAdminUserIsCreatedAsync()
        {

            var serviceProvider = ConventionsHandicapApi.Services;

            var userManager = serviceProvider.GetRequiredService<UserManager<ConventionsHandicapUser>>();

            var roleManager = serviceProvider.GetRequiredService<RoleManager<ConventionsHandicapIdentityRole>>();

            var userId = GuidUtility.Create(GuidUtility.UrlNamespace, RootUserName);

            var conventionsHandicapUser = await userManager.FindByEmailAsync(RootUserName);

            if (conventionsHandicapUser != null)
            {
                return;
            }

            conventionsHandicapUser = new ConventionsHandicapUser()
            {
                UserName = RootUserName,
                Email = RootUserName,
                UserTemporaryPassword = RootUserPassword
            };

            var identityResult = await userManager.CreateAsync(conventionsHandicapUser);

            if (!identityResult.Succeeded)
            {
                throw new InvalidOperationException($"Error during user creation {identityResult.FlattenErrors()}");
            }

            conventionsHandicapUser = await userManager.FindByEmailAsync(RootUserName);

            identityResult = await userManager.AddPasswordAsync(conventionsHandicapUser, RootUserPassword);

            if (!identityResult.Succeeded)
            {
                throw new InvalidOperationException($"Error during role creation {identityResult.FlattenErrors()}");
            }

            var role = ConventionsHandicapIdentityRole.GetRoleName(ConventionsHandicapUserRole.Administrator, null);

            var doesRoleExist = await roleManager.RoleExistsAsync(role);

            if (!doesRoleExist)
            {
                identityResult = await roleManager.CreateAsync(new ConventionsHandicapIdentityRole(ConventionsHandicapUserRole.Administrator, null));

                if (!identityResult.Succeeded)
                {
                    throw new InvalidOperationException($"Error during role creation {identityResult.FlattenErrors()}");
                }

            }

            var isUserInRole = await userManager.IsInRoleAsync(conventionsHandicapUser, role);

            if (!isUserInRole)
            {

                identityResult = await userManager.AddToRoleAsync(conventionsHandicapUser, $"{ConventionsHandicapUserRole.Administrator}");

                if (!identityResult.Succeeded)
                {
                    throw new InvalidOperationException($"Error during role creation {identityResult.FlattenErrors()}");
                }

            }

        }
        protected async Task<Guid> GetAdminUserIdAsync()
        {
            var serviceProvider = ConventionsHandicapApi.Services;

            var serviceScopeFactory = serviceProvider.GetService<IServiceScopeFactory>();

            using (var scope = serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var user = await conventionHandicapDbContext.ConventionsHandicapUsers.FirstAsync();

                    return user.Id;
                }
            }
        }
        protected async Task<HttpClient> GetHttpClientWithAuthenticationHeaderAsync()
        {
            var httpClient = ConventionsHandicapApi.Server.CreateClient();

            var bearerToken = await GetAdminUserBearerTokenAsync();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            return httpClient;

        }
        protected async Task<string> GetAdminUserBearerTokenAsync()
        {
            using var httpClient = ConventionsHandicapApi.Server.CreateClient();

            var loginDto = new ConventionsHandicapLoginDto()
            {
                Password = RootUserPassword,
                Username = RootUserName,
                WorkspaceId = CapHandiCapWorkspaceId
            };

            var httpResponseMessage = await httpClient.PostAsync("v1/login", new StringContent(loginDto.ToJson(), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.OK, httpResponseMessage.StatusCode);

            var contentBody = await httpResponseMessage.Content.ReadAsStringAsync();

            var bearerTokenUserLoginResponse = contentBody.JsonTo<BearerTokenUserLoginResponse>();

            return bearerTokenUserLoginResponse.BearerToken;
        }

        [OneTimeSetUp]
        public async Task Setup()
        {
            ConventionsHandicapApi = new ConventionsHandicapApi();

            await EnsureAdminUserIsCreatedAsync();
            await EnsureWorkspaceIsCreatedAsync();

            RootAdminUserId = await GetAdminUserIdAsync();

            OnOneTimeSetup();
        }

        protected virtual void OnOneTimeSetup() { }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            await ConventionsHandicapApi.DisposeAsync();

            OnOneTimeTearDown();
        }

        protected virtual void OnOneTimeTearDown() { }
    }
}
