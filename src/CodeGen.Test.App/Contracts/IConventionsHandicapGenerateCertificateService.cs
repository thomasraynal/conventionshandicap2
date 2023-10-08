using ConventionsHandicap.App.Features.CertificateDemand.Shared;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model.Features.CertificateDemand;
using System;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Contracts
{
    public interface IConventionsHandicapGenerateCertificateService
    {
        Task<ConventionsHandicapGeneratedCertificate> GenerateCertificateAsync(ConventionsHandicapUser currentUser, Guid projectId, Guid certificateTemplateId);
        Task<ConventionsHandicapCertificateTemplate[]> GetCertificatesAsync();
        Task<ConventionsHandicapCertificateTemplate[]> GetCertificateTemplatesByAcademyAndDepartmentAsync(string academy, string department);
        Task<ConventionsHandicapCertificateTemplate[]> GetCertificatesTemplatesByAcademyAsync(string academy);
    }
}
