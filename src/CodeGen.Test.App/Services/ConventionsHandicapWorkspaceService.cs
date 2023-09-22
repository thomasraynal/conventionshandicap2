using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Contracts;
using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Shared.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace ConventionsHandicap.Services
{
    public class ConventionsHandicapWorkspaceService : IConventionsHandicapWorkspaceService
    {
        private readonly UserManager<ConventionsHandicapUser> _userManager;
        private readonly RoleManager<ConventionsHandicapIdentityRole> _roleManager;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ConventionsHandicapWorkspaceService(UserManager<ConventionsHandicapUser> userManager,
            RoleManager<ConventionsHandicapIdentityRole> roleManager,
            IServiceScopeFactory serviceScopeFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<IConventionsHandicapWorkspace> CreateWorkspaceAsync(IConventionsHandicapUser currentUser, CreateWorkspaceDto createWorkspaceDto)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {

                    if (null == currentUser)
                    {
                        throw new ConventionsHandicapUnauthorizedException($"Unable to get current user");
                    }

                    if (null == createWorkspaceDto.Name)
                    {
                        throw new ConventionsHandicapUnauthorizedException($"Workspace Name should not be null");
                    }

                    var doesWorkspaceAlreadyExist = conventionHandicapDbContext.ConventionsHandicapWorkspaces.Any(workspace => workspace.Name == createWorkspaceDto.Name);

                    if (doesWorkspaceAlreadyExist)
                    {
                        throw new ConventionsHandicapUnauthorizedException($"Workspace {createWorkspaceDto.Name} already exist");
                    }

                    if (!(await _userManager.IsAdministratorAsync(currentUser as ConventionsHandicapUser)))
                    {
                        throw new ConventionsHandicapUnauthorizedException($"User {currentUser.UserId} cannot create or modify a workspace");
                    }

                    var workspace = new ConventionsHandicapWorkspace()
                    {
                        Logo = createWorkspaceDto.Logo == null ? null : new Uri(createWorkspaceDto.Logo),
                        Id = Guid.NewGuid(),
                        Name = createWorkspaceDto.Name
                    };

                    await conventionHandicapDbContext.ConventionsHandicapWorkspaces.AddAsync(workspace);

                    await conventionHandicapDbContext.SaveChangesAsync();

                    return await GetOneWorkspaceByIdAsync(currentUser, workspace.Id);

                }
            }
        }

        public async Task DeleteWorkspaceAsync(IConventionsHandicapUser currentUser, Guid workspaceId)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {

                    var conventionsHandicapWorkspace = await conventionHandicapDbContext.ConventionsHandicapWorkspaces.FirstOrDefaultAsync(conventionsHandicapWorkspace => conventionsHandicapWorkspace.Id == workspaceId);

                    if (null == conventionsHandicapWorkspace)
                    {
                        throw new ConventionsHandicapNotFoundException($"Workspace {workspaceId} does not exist");
                    }

                    conventionHandicapDbContext.ConventionsHandicapWorkspaces.Remove(conventionsHandicapWorkspace);

                    await conventionHandicapDbContext.SaveChangesAsync();
                }
            }
        }


        public async Task<IConventionsHandicapWorkspace[]> GetAllMyWorkspacesAsync(IConventionsHandicapUser currentUser)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    return await conventionHandicapDbContext.ConventionsHandicapWorkspaces.Include(car => car.Features).ToArrayAsync();
                }
            }
        }

        public async Task<IConventionsHandicapWorkspace?> GetOneWorkspaceByIdAsync(IConventionsHandicapUser currentUser, Guid workspaceId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    return await conventionHandicapDbContext.ConventionsHandicapWorkspaces.Include(car => car.Features).FirstOrDefaultAsync(workspace => workspace.Id == workspaceId);
                }
            }
        }

        public async Task<IConventionsHandicapWorkspace?> GetOneWorkspaceByNameAsync(IConventionsHandicapUser currentUser, string workspaceName)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    return await conventionHandicapDbContext.ConventionsHandicapWorkspaces.Include(car => car.Features).FirstOrDefaultAsync(workspace => workspace.Name == workspaceName);
                }
            }
        }

        public async Task<ConventionsHandicapUserRole> GetUserRoleForWorkpaceAsync(IConventionsHandicapUser currentUser, Guid workspaceId)
        {
            var userRoleNames = await _userManager.GetRolesAsync(currentUser as ConventionsHandicapUser);
            var userRoles = await _roleManager.GetConventionsHandicapIdentityRoles(userRoleNames);

            var highestRoleInWorkspaceOrNull = userRoles.Where(userRole => userRole.WorkspaceId == workspaceId || userRole.UserRole.IsAdministrator()).OrderByDescending(userRole => userRole.UserRole).FirstOrDefault();

            if (null == highestRoleInWorkspaceOrNull)
            {
                return ConventionsHandicapUserRole.None;
            }

            return highestRoleInWorkspaceOrNull.UserRole;
        }

        public async Task<IConventionsHandicapWorkspace> UpdateWorkspaceAsync(IConventionsHandicapUser currentUser, Guid workspaceId, UpdateWorkspaceDto updateWorkspaceDto)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var workspace = await conventionHandicapDbContext.ConventionsHandicapWorkspaces.Include(conventionsHandicapWorkspace => conventionsHandicapWorkspace.Features).FirstOrDefaultAsync(workspace => workspace.Id == workspaceId);

                    if (null == workspace)
                    {
                        throw new ConventionsHandicapNotFoundException($"Workspace {workspaceId} does not exist");
                    }

                    var doesWorkspaceNameExist = await conventionHandicapDbContext.ConventionsHandicapWorkspaces.AnyAsync(workspace => workspace.Name == updateWorkspaceDto.Name);

                    if (!doesWorkspaceNameExist)
                    {
                        throw new ConventionsHandicapBadRequestException($"Workspace {updateWorkspaceDto.Name} already exist");
                    }

                    if (null != updateWorkspaceDto.Features)
                    {
                        var conventionsHandicapFeatures = new List<ConventionsHandicapFeature>();

                        foreach (var featureId in updateWorkspaceDto.Features)
                        {
                            var conventionsHandicapFeature = await conventionHandicapDbContext.ConventionsHandicapFeatures.FirstOrDefaultAsync(conventionsHandicapFeature => conventionsHandicapFeature.Id == featureId);

                            if (null == conventionsHandicapFeature)
                            {
                                throw new ConventionsHandicapNotFoundException($"Feature {featureId} does not exist");
                            }

                            conventionsHandicapFeatures.Add(conventionsHandicapFeature);
                        }


                        workspace.Features = conventionsHandicapFeatures;
                    }

                    if (null != updateWorkspaceDto.Name)
                    {
                        workspace.Name = updateWorkspaceDto.Name;
                    }

                    if (null != updateWorkspaceDto.Logo)
                    {
                        workspace.Logo = updateWorkspaceDto.Logo == null ? null : new Uri(updateWorkspaceDto.Logo);
                    }

                    conventionHandicapDbContext.ConventionsHandicapWorkspaces.Update(workspace);

                    await conventionHandicapDbContext.SaveChangesAsync();

                    workspace = await conventionHandicapDbContext.ConventionsHandicapWorkspaces.Include(conventionsHandicapWorkspace=> conventionsHandicapWorkspace.Features).FirstAsync(workspace => workspace.Id == workspaceId);

                    return workspace;
                }
            }
        }
    }
}

