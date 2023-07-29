using ConventionsHandicap.Controller.Dto;
using ConventionsHandicap.Model;
using ConventionsHandicap.App.Features.CertificateDemand.Controllers.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Contracts
{
    public interface IConventionsHandicapCertificateDemandService
    {
        Task<CertificateDemandDto?> GetOneCertificateDemandAsync(IConventionsHandicapUser conventionsHandicapUser, Guid certificateDemandId);
        Task<(CertificateDemandDto certificateDemand, bool hasCertificateDemandStatusChanged)> UpdateCertificateDemandAsync(IConventionsHandicapUser conventionsHandicapUser, UpdateCertificateDemandDto updateCertificateDemandDto);
        Task<Guid> GetCertificateDemandOwnerIdAsync(IConventionsHandicapUser conventionsHandicapUser, Guid certificateDemandId);
        Task DeleteCertificateDemandAsync(IConventionsHandicapUser conventionsHandicapUser, Guid certificateDemandId);
        Task<CertificateDemandDto[]> GetAllMyCertificateDemandsByWorkspaceAsync(IConventionsHandicapUser conventionsHandicapUser, Guid workspaceId);
        Task<CertificateDemandDto[]> GetAllCertificateDemandsByWorkspaceAsync(IConventionsHandicapUser conventionsHandicapUser, Guid workspaceId);
        Task<CertificateDemandDto?> CreateCertificateDemandAsync(IConventionsHandicapUser conventionsHandicapUser, CreateCertificateDemandDto createCertificateDemandDto);
        Task<CertificateDemandDto?> SaveFileAsync(IConventionsHandicapUser conventionsHandicapUser, Guid certificateDemandId, string metadataCode, IFormFile file);
    }
}
