using Anabasis.Identity;
using Anabasis.Identity.Dto;
using ConventionsHandicap.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Anabasis.Common;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Anabasis.Identity.Shared;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Controller.Dto;
using ConventionsHandicap.Services;
using Microsoft.Extensions.DependencyInjection;
using ConventionsHandicap.Model;
using ConventionsHandicap.App.Shared.Extensions;
using System.Security.Claims;
using System.Collections.Generic;

namespace ConventionsHandicap.Controller
{
    [ApiController]
    [Produces("application/json")]
    [Route("/v1")]
    public class ConventionsHandicapUserManagementController : BaseUserManagementController<RegistrationDto, ConventionsHandicapLoginDto, BearerTokenUserLoginResponse, ConventionsHandicapUser>
    {
        private readonly IJwtTokenService<ConventionsHandicapUser> _tokenService;
        private readonly IConventionsHandicapWorkspaceService _workspaceService;
        private readonly UserManager<ConventionsHandicapUser> _userManager;

        public ConventionsHandicapUserManagementController(IJwtTokenService<ConventionsHandicapUser> tokenService,
            IUserMailService passwordResetMailService,
            IConventionsHandicapWorkspaceService workspaceService,
            UserManager<ConventionsHandicapUser> userManager,
            IServiceScopeFactory serviceScopeFactory) : base(passwordResetMailService, userManager)
        {
            _tokenService = tokenService;
            _workspaceService = workspaceService;
            _userManager = userManager;
        }

        protected override async Task<ConventionsHandicapUser> CreateUser(RegistrationDto registrationDto)
        {
            throw new NotImplementedException();
        }

        protected async override Task<BearerTokenUserLoginResponse> GetLoginResponse(ConventionsHandicapLoginDto conventionsHandicapLoginDto, ConventionsHandicapUser currentUser)
        {

            if (null == conventionsHandicapLoginDto.WorkspaceId)
            {
                throw new ConventionsHandicapBadRequestException("WorkspaceId should not be null");
            }

            var userRole = await _workspaceService.GetUserRoleForWorkpaceAsync(currentUser, conventionsHandicapLoginDto.WorkspaceId.Value);

            if (userRole.IsNone())
            {
                throw new ConventionsHandicapUnauthorizedException($"User {currentUser.Id} is not authorized on workspace {conventionsHandicapLoginDto.WorkspaceId}");
            }

            var additionalClaims = new List<Claim>();

            var isAdministrator = await _userManager.IsAdministratorAsync(currentUser);

            if (isAdministrator)
            {
                additionalClaims.Add(new Claim(ClaimTypes.Role, $"{ConventionsHandicapUserRole.Administrator}"));
            }

            var (token, expirationUtcDate) = _tokenService.CreateToken(currentUser, additionalClaims.ToArray());

            var bearerTokenUserLoginResponse = new BearerTokenUserLoginResponse()
            {
                BearerToken = token,
                ExpirationUtcDate = expirationUtcDate
            };

            return bearerTokenUserLoginResponse;
        }
    }
}
