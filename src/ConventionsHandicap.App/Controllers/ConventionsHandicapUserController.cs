using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Anabasis.Common.Shared;
using Anabasis.Identity.Shared;
using System.Linq;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Contracts;
using ConventionsHandicap.Shared;
using ConventionsHandicap.Model;
using ConventionsHandicap.Controller.Dto;
using System.Web;
using ConventionsHandicap.Services;
using ConventionsHandicap.App.Features.CertificateDemand.Contracts;
using ConventionsHandicap.App.Features.CertificateDemand.Controllers.Dto;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using MailKit;
using Anabasis.Api;
using ConventionsHandicap.App.Shared.Extensions;
using ConventionsHandicap.App.Controllers.Dto;
using ConventionsHandicap.App.Contracts;

namespace ConventionsHandicap.Controller
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/v1/users")]
    public class ConventionsHandicapUserController : ControllerBase
    {

        private readonly UserManager<ConventionsHandicapUser> _userManager;
        private readonly RoleManager<ConventionsHandicapIdentityRole> _roleManager;
        private readonly IConventionsHandicapMailService _mailService;
        private readonly IConventionsHandicapWorkspaceService _conventionsHandicapWorkspaceService;
        private readonly ConventionsHandicapConfigurationOptions _conventionsHandicapConfigurationOptions;

        public ConventionsHandicapUserController(
            ConventionsHandicapConfigurationOptions conventionsHandicapConfigurationOptions,
            IConventionsHandicapMailService mailService, 
            IConventionsHandicapWorkspaceService conventionsHandicapWorkspaceService, 
            UserManager<ConventionsHandicapUser> userManager,
            RoleManager<ConventionsHandicapIdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mailService = mailService;
            _conventionsHandicapWorkspaceService = conventionsHandicapWorkspaceService;
            _conventionsHandicapConfigurationOptions = conventionsHandicapConfigurationOptions;
        }


        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(UserDto[]), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAllUsers")]
        [Authorize(Roles = "Manager,Administrator")]
        [HttpGet()]
        public IActionResult GetAllUsers()
        {
            return Ok(_userManager.Users.Select(user=> user.ToUserDto()).ToArray());
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetCurrentUser")]
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            return Ok(currentUser.ToUserDto());
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        [SwaggerOperation("UpdateUser")]
        [HttpPatch()]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest updateUserRequest)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

     
            if (null == currentUser)
            {
                throw new ConventionsHandicapUnauthorizedException($"Unable to get current user");
            }

            if (null == updateUserRequest.WorkspaceId)
            {
                throw new ConventionsHandicapBadRequestException($"WorkspaceId should not be null");
            }

            if (null == updateUserRequest.UserRole)
            {
                throw new ConventionsHandicapBadRequestException($"UserRole should not be null");
            }

            var workspaceId = updateUserRequest.WorkspaceId.Value;

            var workspace = await _conventionsHandicapWorkspaceService.GetOneWorkspaceByIdAsync(currentUser, workspaceId);

            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, workspaceId);

            if (currentUserRoleOnWorkspace.IsUser() || currentUserRoleOnWorkspace.IsNone())
            {
                throw new ConventionsHandicapUnauthorizedException($"User {currentUser.Id} cannot create or modify a user");
            }

            var conventionsHandicapUser = await _userManager.FindByIdAsync($"{updateUserRequest.UserId}");

            if (null == conventionsHandicapUser)
            {
                throw new ConventionsHandicapNotFoundException($"User with id {updateUserRequest.UserId} does not exist");
            }

            var hasEmailChanged = false;

            if (null != updateUserRequest.UserEmail)
            {
                conventionsHandicapUser.UserName = updateUserRequest.UserEmail;
                conventionsHandicapUser.Email = updateUserRequest.UserEmail;

                hasEmailChanged = updateUserRequest.UserEmail != updateUserRequest.UserEmail;
            }

            IdentityResult identityResult;

            if (null != updateUserRequest.UserRole)
            {
                var userRoleKey = workspace.GetWorkspaceUserRoleKey(updateUserRequest.UserRole.Value);

                var isAlreadyInRole = await _userManager.IsInRoleAsync(conventionsHandicapUser, userRoleKey);

                var userRole = ConventionsHandicapIdentityRole.GetRoleName(updateUserRequest.UserRole.Value, updateUserRequest.WorkspaceId);

                var doesRoleExist = await _roleManager.RoleExistsAsync(userRole);

                if (!doesRoleExist)
                {
                    identityResult = await _roleManager.CreateAsync(new ConventionsHandicapIdentityRole(updateUserRequest.UserRole.Value, updateUserRequest.WorkspaceId));

                    if (!identityResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Error during role creation {identityResult.FlattenErrors()}");
                    }

                }

                if (!isAlreadyInRole)
                {
                    await _userManager.AddToRoleAsync(conventionsHandicapUser, userRoleKey);
                }
            }

            identityResult = await _userManager.UpdateAsync(conventionsHandicapUser);

            if (!identityResult.Succeeded)
            {
                throw new InvalidOperationException($"An issue occured during the user update - {identityResult.FlattenErrors()}");
            }

            if (hasEmailChanged)
            {
                var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(conventionsHandicapUser);

                var httpEncodedToken = HttpUtility.UrlEncode(emailConfirmationToken);

                conventionsHandicapUser = await _userManager.FindByIdAsync($"{updateUserRequest.UserId}");

                await _mailService.SendEmailFromConventionsHandicap(conventionsHandicapUser,
                    new ConventionsHandicapSendMailFromConventionsHandicapRequest(
                        isHtml: true,
                        conventionsHandicapUser: conventionsHandicapUser,
                        workspaceId: workspaceId,
                        subjectText: "Modification de votre compte ConventionsHandicap",
                        bodyText: $"<h2 style=\"color: #2e6c80;\">" +
                        $"Vos identifiant ConventionsHandicap:" +
                        $"</h2> " +
                        $"<p>Identifiant: {conventionsHandicapUser.UserEmail}</p> " +
                        $"<p>Confirmer votre mail: {_conventionsHandicapConfigurationOptions.ConventionsHandicapUri}/confirm?email={conventionsHandicapUser.Email}&token={httpEncodedToken}</p> " +
                        $"<p>Rendez-vous sur le site pour faire votre demande: <a href=\"https://conventionshandicap.fr\">https://conventionshandicap.fr</a></p> <p>&nbsp;</p>"
                    ));
            }

        

            return Ok(conventionsHandicapUser.ToUserDto());
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        [SwaggerOperation("CreateUser")]
        [HttpPut()]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (null == createUserRequest.WorkspaceId)
            {
                throw new ConventionsHandicapBadRequestException($"WorkspaceId should not be null");
            }

            if (null == createUserRequest.UserRole)
            {
                throw new ConventionsHandicapBadRequestException($"UserRole should not be null");
            }

            if (null == createUserRequest.UserEmail)
            {
                throw new ConventionsHandicapBadRequestException($"UserEmail should not be null");
            }

            var workspaceId = createUserRequest.WorkspaceId.Value;

            var workspace = await _conventionsHandicapWorkspaceService.GetOneWorkspaceByIdAsync(currentUser, workspaceId);

            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, workspaceId);

            if (currentUserRoleOnWorkspace.IsUser() || currentUserRoleOnWorkspace.IsNone())
            {
                throw new ConventionsHandicapUnauthorizedException($"User {currentUser.Id} cannot create or modify a user");
            }

            var conventionsHandicapUser = await _userManager.FindByEmailAsync(createUserRequest.UserEmail);

            if (null != conventionsHandicapUser)
            {
                throw new ConventionsHandicapBadRequestException($"User with email {createUserRequest.UserEmail} already exist");
            }
            else
            {

                var userId = GuidUtility.Create(GuidUtility.UrlNamespace, createUserRequest.UserEmail);

                var tempPassword = Password.Generate(8, 2);

                conventionsHandicapUser = new ConventionsHandicapUser()
                {
                    Id = userId,
                    UserName = createUserRequest.UserEmail,
                    Email = createUserRequest.UserEmail,
                    UserTemporaryPassword = tempPassword
                };

                var identityResult = await _userManager.CreateAsync(conventionsHandicapUser);

                if (!identityResult.Succeeded)
                {
                    throw new InvalidOperationException($"Error during user creation {identityResult.FlattenErrors()}");
                }

                conventionsHandicapUser = await _userManager.FindByEmailAsync(createUserRequest.UserEmail);

                identityResult = await _userManager.AddPasswordAsync(conventionsHandicapUser, tempPassword);

                if (!identityResult.Succeeded)
                {
                    throw new InvalidOperationException($"Error during role creation {identityResult.FlattenErrors()}");
                }

                var userRole = ConventionsHandicapIdentityRole.GetRoleName(createUserRequest.UserRole.Value, createUserRequest.WorkspaceId);

                var doesRoleExist = await _roleManager.RoleExistsAsync(userRole);

                if (!doesRoleExist)
                {
                    identityResult = await _roleManager.CreateAsync(new ConventionsHandicapIdentityRole(createUserRequest.UserRole.Value, createUserRequest.WorkspaceId));

                    if (!identityResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Error during role creation {identityResult.FlattenErrors()}");
                    }

                }

                identityResult = await _userManager.AddToRoleAsync(conventionsHandicapUser, workspace.GetWorkspaceUserRoleKey(createUserRequest.UserRole.Value));

                if (!identityResult.Succeeded)
                {
                    throw new InvalidOperationException($"Error during role creation {identityResult.FlattenErrors()}");
                }

                conventionsHandicapUser = await _userManager.FindByIdAsync($"{userId}");

                var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(conventionsHandicapUser);

                var httpEncodedToken = HttpUtility.UrlEncode(emailConfirmationToken);

                await _mailService.SendEmailFromConventionsHandicap(currentUser,
                    new ConventionsHandicapSendMailFromConventionsHandicapRequest(
                        isHtml: true,
                        workspaceId: workspaceId,
                        conventionsHandicapUser: conventionsHandicapUser,
                        subjectText: "Création de votre compte ConventionsHandicap",
                        bodyText: $"<h2 style=\"color: #2e6c80;\">" +
                        $"Vos identifiant ConventionsHandicap:" +
                        $"</h2> " +
                        $"<p>Identifiant: {conventionsHandicapUser.UserEmail}</p> " +
                        $"<p>Mot de passe: {conventionsHandicapUser.UserTemporaryPassword}</p> " +
                        $"<p>Confirmer votre mail: {_conventionsHandicapConfigurationOptions.ConventionsHandicapUri}/confirm?email={conventionsHandicapUser.Email}&token={httpEncodedToken}</p> " +
                        $"<p>Rendez-vous sur le site pour faire votre demande: <a href=\"https://conventionshandicap.fr\">https://conventionshandicap.fr</a></p> <p>&nbsp;</p>"
                    ));

            }

            return Ok(conventionsHandicapUser.ToUserDto());
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [SwaggerOperation("DeleteUser")]
        [HttpDelete()]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest deleteUserRequest)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (null == deleteUserRequest.WorkspaceId)
            {
                throw new ConventionsHandicapBadRequestException($"WorkspaceId should not be null");
            }

            var workspaceId = deleteUserRequest.WorkspaceId.Value;

            var workspace = await _conventionsHandicapWorkspaceService.GetOneWorkspaceByIdAsync(currentUser, workspaceId);

            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, workspaceId);

            if (currentUserRoleOnWorkspace.IsUser() || currentUserRoleOnWorkspace.IsNone())
            {
                throw new ConventionsHandicapUnauthorizedException($"User {currentUser.Id} cannot create or modify a user");
            }

            var conventionsHandicapUser = await _userManager.FindByIdAsync($"{deleteUserRequest.UserId}");

            if (null == conventionsHandicapUser)
            {
                throw new ConventionsHandicapNotFoundException($"User {deleteUserRequest.UserId} does not exist");
            }

            var identityResult = await _userManager.DeleteAsync(conventionsHandicapUser);

            if (!identityResult.Succeeded)
            {
                throw new InvalidOperationException($"Error during user deletion {identityResult.FlattenErrors()}");
            }

            return NoContent();
        }

    }
}
