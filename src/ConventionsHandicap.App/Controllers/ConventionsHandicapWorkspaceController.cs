using ConventionsHandicap.Controller.Dto;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Services;
using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Controllers.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using ConventionsHandicap.Model.Contracts;
using Anabasis.Api;

namespace ConventionsHandicap.Controller
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/v1/workspaces")]
    public class ConventionsHandicapWorkspaceController : ControllerBase
    {

        private readonly UserManager<ConventionsHandicapUser> _userManager;
        private readonly IConventionsHandicapWorkspaceService _workspaceService;

        public ConventionsHandicapWorkspaceController(IConventionsHandicapWorkspaceService workspaceService, UserManager<ConventionsHandicapUser> userManager)
        {
            _userManager = userManager;
            _workspaceService = workspaceService;
        }


        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(IConventionsHandicapWorkspace[]), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAllMyWorkspaces")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllMyWorkspaces()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var allWorkspaces = await _workspaceService.GetAllMyWorkspacesAsync(currentUser);

            return Ok(allWorkspaces);

        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(IConventionsHandicapWorkspace), (int)HttpStatusCode.OK)]
        [SwaggerOperation("CreateWorkspace")]
        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<IActionResult> CreateWorkspace([FromBody] CreateWorkspaceDto createWorkspaceDto)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var workspace = await _workspaceService.CreateWorkspaceAsync(currentUser, createWorkspaceDto);

            return Ok(workspace);

        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(IConventionsHandicapWorkspace), (int)HttpStatusCode.OK)]
        [SwaggerOperation("UpdateWorkspace")]
        [Authorize(Roles = "Administrator")]
        [HttpPatch("{workspaceId}")]
        public async Task<IActionResult> UpdateWorkspace([FromRoute] Guid workspaceId, [FromBody] UpdateWorkspaceDto updateWorkspaceDto)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var workspace = await _workspaceService.UpdateWorkspaceAsync(currentUser, workspaceId, updateWorkspaceDto);

            return Ok(workspace);

        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [SwaggerOperation("DeleteWorkspace")]
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{workspaceId}")]
        public async Task<IActionResult> DeleteWorkspace([FromRoute] Guid workspaceId)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

             await _workspaceService.DeleteWorkspaceAsync(currentUser, workspaceId);

            return NoContent();

        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(IConventionsHandicapWorkspace), (int)HttpStatusCode.NoContent)]
        [SwaggerOperation("GetWorkspace")]
        [Authorize]
        [HttpGet("{workspaceId}")]
        public async Task<IActionResult> GetWorkspace(Guid workspaceId)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var currentUserRoleOnWorkspace = await _workspaceService.GetUserRoleForWorkpaceAsync(currentUser, workspaceId);

            if (currentUserRoleOnWorkspace.IsNone())
            {
                throw new ConventionsHandicapUnauthorizedException($"User {currentUser.Id} cannot access workspace {workspaceId}");
            }

            var workspace = await _workspaceService.GetOneWorkspaceByIdAsync(currentUser, workspaceId);

            if (null == workspace)
            {
                throw new ConventionsHandicapNotFoundException($"Workspace {workspaceId} does not exist");
            }

            return Ok(workspace);
        }
    }
}
