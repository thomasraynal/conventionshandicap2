using Anabasis.Api;
using ConventionsHandicap;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model.Contracts;
using ConventionsHandicap.Model;
using ConventionsHandicap.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ConventionsHandicap.Shared;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Drawing;

namespace ConventionsHandicap
{
    public partial class ConventionsHandicapController
    {

        protected async override Task<GetWorkspacesResponseBuilder> GetWorkspacesInternalAsync()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var allWorkspaces = await _workspaceService.GetAllMyWorkspacesAsync(currentUser);

            return GetWorkspacesResponseBuilder.Build200(allWorkspaces);

        }

        protected async override Task<PutWorkspaceResponseBuilder> PutWorkspaceInternalAsync(CreateWorkspaceDto createWorkspaceDto)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var workspace = await _workspaceService.CreateWorkspaceAsync(currentUser, createWorkspaceDto);

            return PutWorkspaceResponseBuilder.Build200(workspace);
        }

        protected async override Task<UpdateWorkspaceResponseBuilder> UpdateWorkspaceInternalAsync(Guid workspaceId, UpdateWorkspaceDto updateWorkspaceDto)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var workspace = await _workspaceService.UpdateWorkspaceAsync(currentUser, workspaceId, updateWorkspaceDto);

            return UpdateWorkspaceResponseBuilder.Build200(workspace);
        }

        protected async override Task<DeleteWorkspaceResponseBuilder> DeleteWorkspaceInternalAsync(Guid workspaceId)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            await _workspaceService.DeleteWorkspaceAsync(currentUser, workspaceId);

            return DeleteWorkspaceResponseBuilder.Build204();
        }


        protected async override Task<GetWorkspaceResponseBuilder> GetWorkspaceInternalAsync(Guid workspaceId)
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

            return GetWorkspaceResponseBuilder.Build200(workspace);
        }
    }
}
