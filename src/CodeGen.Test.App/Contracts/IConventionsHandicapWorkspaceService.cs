using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Contracts;
using System;
using System.Threading.Tasks;

namespace ConventionsHandicap.Services
{
    public interface IConventionsHandicapWorkspaceService
    {
        Task<ConventionsHandicapUserRole> GetUserRoleForWorkpaceAsync(IConventionsHandicapUser currentUser, Guid workspaceId);
        Task<IConventionsHandicapWorkspace> UpdateWorkspaceAsync(IConventionsHandicapUser currentUser, Guid workspaceId, UpdateWorkspaceDto udateWorkspaceDto);
        Task<IConventionsHandicapWorkspace> CreateWorkspaceAsync(IConventionsHandicapUser currentUser, CreateWorkspaceDto createWorkspaceDto);
        Task<IConventionsHandicapWorkspace[]> GetAllMyWorkspacesAsync(IConventionsHandicapUser currentUser);
        Task<IConventionsHandicapWorkspace?> GetOneWorkspaceByIdAsync(IConventionsHandicapUser currentUser, Guid workspaceId);
        Task<IConventionsHandicapWorkspace?> GetOneWorkspaceByNameAsync(IConventionsHandicapUser currentUser, string workspaceName);
        Task DeleteWorkspaceAsync(IConventionsHandicapUser currentUser, Guid workspaceId);
    }
}