using ConventionsHandicap.Controller.Dto;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Features.CertificateDemand;
using ConventionsHandicap.Services;
using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Features.CertificateDemand.Contracts;
using ConventionsHandicap.App.Features.CertificateDemand.Controllers.Dto;
using ConventionsHandicap.App.Features.CertificateDemand.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pipelines.Sockets.Unofficial.Arenas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Services
{
    public class ConventionsHandicapCertificateDemandService : IConventionsHandicapCertificateDemandService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConventionsHandicapMetadataService _conventionsHandicapMetadataService;
        private readonly IConventionsHandicapWorkspaceService _conventionsHandicapWorkspaceService;
        private readonly IConventionHandicapMetadataFileStorage _conventionHandicapMetadataFileStorage;

        public ConventionsHandicapCertificateDemandService(IServiceScopeFactory serviceScopeFactory, 
            IConventionsHandicapWorkspaceService conventionsHandicapWorkspaceService, 
            IConventionsHandicapMetadataService conventionsHandicapMetadataService, 
            IConventionHandicapMetadataFileStorage conventionHandicapMetadataFileStorage)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _conventionsHandicapMetadataService = conventionsHandicapMetadataService;
            _conventionsHandicapWorkspaceService = conventionsHandicapWorkspaceService;
            _conventionHandicapMetadataFileStorage = conventionHandicapMetadataFileStorage;
        }

        public async Task<CertificateDemandDto?> CreateCertificateDemandAsync(IConventionsHandicapUser currentUser, CreateCertificateDemandDto createCertificateDemandDto)
        {

            var certificateDemandId = Guid.NewGuid();

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {

                    if (null == createCertificateDemandDto.ChildDateOfBirth)
                    {
                        throw new ConventionsHandicapBadRequestException($"ChildDateOfBirth is not set");
                    }

                    var academy = await conventionHandicapDbContext.Academies.Include(academy => academy.Departments).FirstOrDefaultAsync(academy => academy.Name == createCertificateDemandDto.Academy);

                    if (null == academy)
                    {
                        throw new ConventionsHandicapBadRequestException($"Academy {createCertificateDemandDto.Academy} does not exist");
                    }

                    var department = academy.Departments.FirstOrDefault(academy => academy.Name == createCertificateDemandDto.Department);

                    if (null == department)
                    {
                        throw new ConventionsHandicapBadRequestException($"Department {createCertificateDemandDto.Department} does not exist");
                    }

                    var workspace = await conventionHandicapDbContext.ConventionsHandicapWorkspaces.FirstOrDefaultAsync(workspace => workspace.Id == createCertificateDemandDto.WorkspaceId);

                    if (null == workspace)
                    {
                        throw new ConventionsHandicapBadRequestException($"Workspace {createCertificateDemandDto.WorkspaceId} does not exist");
                    }

                    var certificateDemandTemplates = new List<ConventionsHandicapCertificateTemplate>();

                    foreach (var certificate in createCertificateDemandDto.Certificates)
                    {
                        var template = await conventionHandicapDbContext.ConventionsHandicapCertificateTemplates.FirstOrDefaultAsync(template => template.Id == certificate);

                        if (null == template)
                        {
                            throw new ConventionsHandicapBadRequestException($"Workspace {createCertificateDemandDto.WorkspaceId} does not exist");
                        }

                        if ((template.Academy.Name != academy.Name) || (!academy.Departments.Any(department => department.Name == createCertificateDemandDto.Department)))
                        {
                            throw new ConventionsHandicapBadRequestException($"Template {certificate} does not belong to {createCertificateDemandDto.Academy}/{createCertificateDemandDto.Department}");
                        }

                        certificateDemandTemplates.Add(template);
                    }

                    var metadataValues = _conventionsHandicapMetadataService.GetMetadataValues(createCertificateDemandDto.Academy,
                        createCertificateDemandDto.Department,
                        createCertificateDemandDto.Properties);

                    var conventionsHandicapCertificateDemand = new ConventionsHandicapCertificateDemand(
                        id: certificateDemandId,
                        academy: academy,
                        department: department,
                        childLastName: createCertificateDemandDto.ChildLastName,
                        childFirstName: createCertificateDemandDto.ChildFirstName,
                        childDateOfBirth: createCertificateDemandDto.ChildDateOfBirth.Value,
                        workspace: workspace,
                        certificateDemandStatus: ConventionsHandicapCertificateDemandStatus.ToComplete,
                        user: currentUser as ConventionsHandicapUser,
                        certificateTemplates: certificateDemandTemplates.ToArray(),
                        properties: metadataValues

                        );

                    conventionHandicapDbContext.ConventionsHandicapCertificateDemands.Add(conventionsHandicapCertificateDemand);

                    await conventionHandicapDbContext.SaveChangesAsync();

                    return await GetOneCertificateDemandAsync(currentUser, certificateDemandId);

                }

            }
        }

        public async Task DeleteCertificateDemandAsync(IConventionsHandicapUser currentUser, Guid certificateDemandId)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var conventionsHandicapCertificateDemand = await conventionHandicapDbContext.ConventionsHandicapCertificateDemands.FirstOrDefaultAsync();

                    if (null == conventionsHandicapCertificateDemand)
                    {
                        throw new ConventionsHandicapNotFoundException($"Demand {certificateDemandId} does not exist");
                    }

                    conventionHandicapDbContext.ConventionsHandicapCertificateDemands.Remove(conventionsHandicapCertificateDemand);

                    await conventionHandicapDbContext.SaveChangesAsync();
                }
            }
        }

        public async Task<CertificateDemandDto[]> GetAllCertificateDemandsByWorkspaceAsync(IConventionsHandicapUser currentUser, Guid workspaceId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var conventionsHandicapCertificateDemands = await conventionHandicapDbContext.ConventionsHandicapCertificateDemands
                            .Where(demand => demand.Workspace.Id == workspaceId)
                            .Include(demand => demand.CertificateTemplates)
                            .Include(demand => demand.Properties)
                            .OrderBy(demand => demand.ChildLastName).ToArrayAsync();

                    return conventionsHandicapCertificateDemands.Select(conventionsHandicapCertificateDemand => conventionsHandicapCertificateDemand.ToCertificateDemandDto()).ToArray();
                }

            }
        }

        public async Task<CertificateDemandDto[]> GetAllMyCertificateDemandsByWorkspaceAsync(IConventionsHandicapUser currentUser, Guid workspaceId)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var conventionsHandicapCertificateDemands = await conventionHandicapDbContext.ConventionsHandicapCertificateDemands
                            .Where(demand => demand.Workspace.Id == workspaceId && demand.UserId == currentUser.UserId)
                            .Include(demand => demand.CertificateTemplates)
                            .Include(demand => demand.Properties)
                            .OrderBy(demand => demand.ChildLastName).ToArrayAsync();

                    return conventionsHandicapCertificateDemands.Select(conventionsHandicapCertificateDemand => conventionsHandicapCertificateDemand.ToCertificateDemandDto()).ToArray();
                }

            }
        }

        public async Task<Guid> GetCertificateDemandOwnerIdAsync(IConventionsHandicapUser currentUser, Guid certificateDemandId)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var conventionsHandicapCertificateDemand = await conventionHandicapDbContext.ConventionsHandicapCertificateDemands.FirstOrDefaultAsync(demand => demand.Id == certificateDemandId);

                    if (null == conventionsHandicapCertificateDemand)
                    {
                        throw new ConventionsHandicapNotFoundException($"{certificateDemandId} does not exist");
                    }

                    return conventionsHandicapCertificateDemand.UserId;
                }
            }
        }

        public async Task<CertificateDemandDto?> GetOneCertificateDemandAsync(IConventionsHandicapUser conventionsHandicapUser, Guid certificateDemandId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var conventionsHandicapCertificateDemand = await conventionHandicapDbContext.ConventionsHandicapCertificateDemands
                            .Where(demand => demand.Id == certificateDemandId)
                            .Include(demand => demand.CertificateTemplates)
                            .Include(demand => demand.Properties)
                            .FirstOrDefaultAsync();

                    if (null == conventionsHandicapCertificateDemand)
                    {
                        return null;
                    }

                    return conventionsHandicapCertificateDemand.ToCertificateDemandDto();
                }

            }
        }

        public async Task<CertificateDemandDto?> SaveFileAsync(IConventionsHandicapUser currentUser, Guid certificateDemandId, string metadataName, IFormFile file)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var conventionsHandicapCertificateDemand = await conventionHandicapDbContext.ConventionsHandicapCertificateDemands
                            .Where(demand => demand.Id == certificateDemandId)
                            .Include(demand => demand.CertificateTemplates)
                            .Include(demand => demand.Properties)
                            .FirstOrDefaultAsync();

                    if (null == conventionsHandicapCertificateDemand)
                    {
                        throw new ConventionsHandicapNotFoundException($"Demand {certificateDemandId} does not exist");
                    }

                    _conventionsHandicapMetadataService.EnsureMetadataCodeExist(metadataName);

                    var fileUri = await _conventionHandicapMetadataFileStorage.SaveFileAsync(certificateDemandId, metadataName, file);

                    var existingMetadaValue = conventionsHandicapCertificateDemand.Properties.FirstOrDefault(property => property.Code == metadataName);

                    if (null != existingMetadaValue)
                    {
                        existingMetadaValue.Value = fileUri.AbsoluteUri;
                    }
                    else
                    {
                        conventionsHandicapCertificateDemand.Properties.Add(new ConventionsHandicapCertificateMetadataValue(metadataName, fileUri.AbsoluteUri));
                    }

                    await conventionHandicapDbContext.SaveChangesAsync();

                    return await GetOneCertificateDemandAsync(currentUser, certificateDemandId);

                }
            }

        }


        public async Task<(CertificateDemandDto certificateDemand, bool hasCertificateDemandStatusChanged)> UpdateCertificateDemandAsync(IConventionsHandicapUser currentUser, UpdateCertificateDemandDto updateCertificateDemandDto)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var currentConventionsHandicapCertificateDemand = await conventionHandicapDbContext.ConventionsHandicapCertificateDemands
                            .Where(demand => demand.Id == updateCertificateDemandDto.CertificateDemandId)
                            .Include(demand => demand.CertificateTemplates)
                            .Include(demand => demand.Properties)
                            .FirstOrDefaultAsync();

                    var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, updateCertificateDemandDto.WorkspaceId.Value);


                    if (null == currentConventionsHandicapCertificateDemand)
                    {
                        throw new ConventionsHandicapNotFoundException($"Demand {updateCertificateDemandDto.CertificateDemandId} does not exist");
                    }

                    if (null == updateCertificateDemandDto.ChildDateOfBirth)
                    {
                        throw new ConventionsHandicapBadRequestException($"ChildDateOfBirth is not set");
                    }

                    var academy = await conventionHandicapDbContext.Academies.Include(academy => academy.Departments).FirstOrDefaultAsync(academy => academy.Name == updateCertificateDemandDto.Academy);

                    if (null == academy)
                    {
                        throw new ConventionsHandicapBadRequestException($"Academy {updateCertificateDemandDto.Academy} does not exist");
                    }

                    var department = academy.Departments.FirstOrDefault(academy => academy.Name == updateCertificateDemandDto.Department);

                    if (null == department)
                    {
                        throw new ConventionsHandicapBadRequestException($"Department {updateCertificateDemandDto.Department} does not exist");
                    }

                    var workspace = await conventionHandicapDbContext.ConventionsHandicapWorkspaces.FirstOrDefaultAsync(workspace => workspace.Id == updateCertificateDemandDto.WorkspaceId);

                    if (null == workspace)
                    {
                        throw new ConventionsHandicapBadRequestException($"Workspace {updateCertificateDemandDto.WorkspaceId} does not exist");
                    }

                    var certificateDemandTemplates = new List<ConventionsHandicapCertificateTemplate>();

                    foreach (var certificate in updateCertificateDemandDto.Certificates)
                    {
                        var template = await conventionHandicapDbContext.ConventionsHandicapCertificateTemplates.FirstOrDefaultAsync(template => template.Id == certificate);

                        if (null == template)
                        {
                            throw new ConventionsHandicapBadRequestException($"Workspace {updateCertificateDemandDto.WorkspaceId} does not exist");
                        }

                        if ((template.Academy.Name != academy.Name) || (!academy.Departments.Any(department => department.Name == updateCertificateDemandDto.Department)))
                        {
                            throw new ConventionsHandicapBadRequestException($"Template {certificate} does not belong to {updateCertificateDemandDto.Academy}/{updateCertificateDemandDto.Department}");
                        }

                        certificateDemandTemplates.Add(template);
                    }

                    var newMetadataValues = _conventionsHandicapMetadataService.GetMetadataValues(updateCertificateDemandDto.Academy,
                        updateCertificateDemandDto.Department,
                        updateCertificateDemandDto.Properties);

                    foreach (var newMetadataValue in newMetadataValues)
                    {
                        var existingMetadataValue = currentConventionsHandicapCertificateDemand.Properties.FirstOrDefault(metadata => metadata.Code == newMetadataValue.Code);

                        if (null != existingMetadataValue)
                        {
                            existingMetadataValue.Value = newMetadataValue.Value;
                        }
                        else
                        {
                            currentConventionsHandicapCertificateDemand.Properties.Add(newMetadataValue);
                        }
                    }

                    var oldProjectStatus = currentConventionsHandicapCertificateDemand.CertificateDemandStatus;
                    var newProjectStatus = oldProjectStatus;

                    var isCompleted = currentConventionsHandicapCertificateDemand.Properties.All(metadataValue => null != metadataValue.Value);

                    if (updateCertificateDemandDto.CertificateDemandStatus != oldProjectStatus)
                    {

                        if (currentUserRoleOnWorkspace.IsUser() && currentUser.UserId != currentConventionsHandicapCertificateDemand.UserId)
                        {
                            throw new ConventionsHandicapUnauthorizedException($"User {currentConventionsHandicapCertificateDemand.UserId} is not an admin");
                        }

                        newProjectStatus = updateCertificateDemandDto.CertificateDemandStatus;
                    }
                    else
                    {
                        if (isCompleted && oldProjectStatus != ConventionsHandicapCertificateDemandStatus.Validated)
                        {
                            newProjectStatus = ConventionsHandicapCertificateDemandStatus.ToValidate;
                        }

                        if (!isCompleted && oldProjectStatus != ConventionsHandicapCertificateDemandStatus.Validated)
                        {
                            newProjectStatus = ConventionsHandicapCertificateDemandStatus.ToComplete;
                        }

                    }

                    currentConventionsHandicapCertificateDemand.Academy = academy;
                    currentConventionsHandicapCertificateDemand.Department = department;
                    currentConventionsHandicapCertificateDemand.ChildDateOfBirth = updateCertificateDemandDto.ChildDateOfBirth.Value;
                    currentConventionsHandicapCertificateDemand.ChildFirstName = updateCertificateDemandDto.ChildFirstName;
                    currentConventionsHandicapCertificateDemand.ChildLastName = updateCertificateDemandDto.ChildLastName;
                    currentConventionsHandicapCertificateDemand.CertificateDemandStatus= newProjectStatus;
                    currentConventionsHandicapCertificateDemand.CertificateTemplates = certificateDemandTemplates;

                    conventionHandicapDbContext.ConventionsHandicapCertificateDemands.Update(currentConventionsHandicapCertificateDemand);

                    await conventionHandicapDbContext.SaveChangesAsync();

                    var newConventionsHandicapCertificateDemand = await GetOneCertificateDemandAsync(currentUser, updateCertificateDemandDto.CertificateDemandId.Value);

                    return (newConventionsHandicapCertificateDemand, false);

                }

            }
        }
    }
}
