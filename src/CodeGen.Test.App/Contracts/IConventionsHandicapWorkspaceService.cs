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
        Task<ConventionsHandicapWorkspace> UpdateWorkspaceAsync(IConventionsHandicapUser currentUser, Guid workspaceId, UpdateWorkspaceDto udateWorkspaceDto);
        Task<ConventionsHandicapWorkspace> CreateWorkspaceAsync(IConventionsHandicapUser currentUser, CreateWorkspaceDto createWorkspaceDto);
        Task<ConventionsHandicapWorkspace[]> GetAllMyWorkspacesAsync(IConventionsHandicapUser currentUser);
        Task<ConventionsHandicapWorkspace?> GetOneWorkspaceByIdAsync(IConventionsHandicapUser currentUser, Guid workspaceId);
        Task<ConventionsHandicapWorkspace?> GetOneWorkspaceByNameAsync(IConventionsHandicapUser currentUser, string workspaceName);
        Task DeleteWorkspaceAsync(IConventionsHandicapUser currentUser, Guid workspaceId);
    }
}