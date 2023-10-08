using Anabasis.Api;
using Anabasis.Common;
using Anabasis.Identity.Dto;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Shared;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace ConventionsHandicap.Tests.Integration
{

    [TestFixture]
    public class TestUsersApiFixture: TestApiFixtureBase
    {
       
        [Test]
        public async Task ShouldLoginWithAdminAndSucceed()
        {

            using var httpClient = await GetHttpClientWithAuthenticationHeaderAsync();

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

            Assert.NotNull(bearerTokenUserLoginResponse);
            Assert.NotNull(bearerTokenUserLoginResponse.BearerToken);
            Assert.AreNotEqual(default(DateTime), bearerTokenUserLoginResponse.ExpirationUtcDate);

        }
        [Test]
        public async Task ShouldLoginWithAdminAndFail()
        {

            using var httpClient = await GetHttpClientWithAuthenticationHeaderAsync();

            var loginDto = new ConventionsHandicapLoginDto()
            {
                Password = "wrong",
                Username = RootUserName,
                WorkspaceId = CapHandiCapWorkspaceId
            };

            var httpResponseMessage = await httpClient.PostAsync("v1/login", new StringContent(loginDto.ToJson(), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.Unauthorized, httpResponseMessage.StatusCode);

            var contentBody = await httpResponseMessage.Content.ReadAsStringAsync();

            var errorResponseMessage = contentBody.JsonTo<ErrorResponseMessage>();

            Assert.NotNull(errorResponseMessage);
            Assert.IsNotEmpty(errorResponseMessage.Errors);


        }

        [Test]
        public async Task ShouldCreateUserAndSucceed()
        {
            using var httpClient = await GetHttpClientWithAuthenticationHeaderAsync();

            var createUserRequest = new CreateUserRequest()
            {
                UserRole = ConventionsHandicapUserRole.User,
                UserEmail = "newUser@gmail.com",               
                WorkspaceId = CapHandiCapWorkspaceId
            };

            var httpResponseMessage = await httpClient.PutAsync("v1/users", new StringContent(createUserRequest.ToJson(), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.OK, httpResponseMessage.StatusCode);

            var contentBody = await httpResponseMessage.Content.ReadAsStringAsync();

            var userDto = contentBody.JsonTo<UserDto>();

            Assert.NotNull(userDto);
            Assert.False(userDto.MailConfirmed);
            Assert.NotNull(userDto.Email);
            Assert.AreNotEqual(default(Guid), userDto.Id);
        }

        [Test]
        public async Task ShouldCreateUserAndFail()
        {
            using var httpClient = await GetHttpClientWithAuthenticationHeaderAsync();

            var createUserRequest = new CreateUserRequest()
            {
                UserRole = ConventionsHandicapUserRole.User,
                UserEmail = "thomas.raynal2@gmail.com",
                WorkspaceId = CapHandiCapWorkspaceId
            };

            Assert.ThrowsAsync<ConventionsHandicapBadRequestException>(async () =>
            {
                await httpClient.PutAsync("v1/users", new StringContent(createUserRequest.ToJson(), Encoding.UTF8, "application/json"));
            });

        }

        [Test]
        public async Task ShouldUpdateUserAndSucceed()
        {
            using var httpClient = await GetHttpClientWithAuthenticationHeaderAsync();

            var createUserRequest = new UpdateUserRequest()
            {
                UserRole = ConventionsHandicapUserRole.Manager,
                UserEmail = "thomas.raynal2@gmail.com",
                WorkspaceId = CapHandiCapWorkspaceId,
                UserId = RootAdminUserId
            };

            var httpResponseMessage = await httpClient.PatchAsync("v1/users", new StringContent(createUserRequest.ToJson(), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.OK, httpResponseMessage.StatusCode);

            var contentBody = await httpResponseMessage.Content.ReadAsStringAsync();

            var userDto = contentBody.JsonTo<UserDto> ();

            Assert.NotNull(userDto);
            Assert.False(userDto.MailConfirmed);
            Assert.NotNull(userDto.Email);
            Assert.AreNotEqual(default(Guid), userDto.Id);
        }

        [Test]
        public async Task ShouldUpdateUserAndFail()
        {
            using var httpClient = await GetHttpClientWithAuthenticationHeaderAsync();

            var createUserRequest = new UpdateUserRequest()
            {
                UserId = Guid.NewGuid(),
                UserRole = ConventionsHandicapUserRole.Manager,
                UserEmail = "thomas.raynal2@gmail.com",
                WorkspaceId = CapHandiCapWorkspaceId
            };

            Assert.ThrowsAsync<ConventionsHandicapNotFoundException>(async () =>
            {
                var result  = await httpClient.PatchAsync("v1/users", new StringContent(createUserRequest.ToJson(), Encoding.UTF8, "application/json"));
            });
        }


        [Test]
        public async Task ShouldDeleteUserAndSucceed()
        {
            using var httpClient = await GetHttpClientWithAuthenticationHeaderAsync();

            var createUserRequest = new CreateUserRequest()
            {
                UserRole = ConventionsHandicapUserRole.User,
                UserEmail = "newUser2@gmail.com",
                WorkspaceId = CapHandiCapWorkspaceId
            };

            var httpResponseMessage = await httpClient.PutAsync("v1/users", new StringContent(createUserRequest.ToJson(), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.OK, httpResponseMessage.StatusCode);

            var contentBody = await httpResponseMessage.Content.ReadAsStringAsync();

            var userDto = contentBody.JsonTo<UserDto>();

            var deleteUserRequest = new DeleteUserRequest()
            {
                WorkspaceId = CapHandiCapWorkspaceId,
                UserId = userDto.Id
            };

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, "v1/users")
            {
                Content = new StringContent(deleteUserRequest.ToJson(), Encoding.UTF8, "application/json")
            };

            var deleteUserHttpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            Assert.AreEqual(HttpStatusCode.NoContent, deleteUserHttpResponseMessage.StatusCode);

        }

        [Test]
        public async Task ShouldDeleteUserAndFail()
        {
            using var httpClient = await GetHttpClientWithAuthenticationHeaderAsync();


            var deleteUserRequest = new DeleteUserRequest()
            {
                WorkspaceId = CapHandiCapWorkspaceId,
                UserId = Guid.NewGuid()
            };

            Assert.ThrowsAsync<ConventionsHandicapNotFoundException>(async () =>
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, "v1/users")
                {
                    Content = new StringContent(deleteUserRequest.ToJson(), Encoding.UTF8, "application/json")
                };

                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            });
        }

    }
}