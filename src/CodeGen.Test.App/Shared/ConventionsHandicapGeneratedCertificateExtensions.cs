using ConventionsHandicap.Model.Features.CertificateDemand;
using ConventionsHandicap.Model;

namespace ConventionsHandicap.App.Features.CertificateDemand.Shared
{
    public static class ConventionsHandicapCertificateTemplateExtensions
    {
        public static CertificateTemplateDto ToCertificateTemplateDto(this ConventionsHandicapCertificateTemplate conventionsHandicapCertificateTemplate)
        {
            return new CertificateTemplateDto(
                conventionsHandicapCertificateTemplate.Id,
                conventionsHandicapCertificateTemplate.AcademyName,
                conventionsHandicapCertificateTemplate.DepartmentName,
                conventionsHandicapCertificateTemplate.FriendlyName
                );
        }
    }
}
