using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Features.CertificateDemand;
using System.Linq;

namespace ConventionsHandicap.App.Features.CertificateDemand.Shared
{
    public static class ConventionsHandicapCertificateDemandExtensions
    {
        public static CertificateDemandDto ToCertificateDemandDto(this ConventionsHandicapCertificateDemand conventionsHandicapCertificateDemand)
        {
            return new CertificateDemandDto(conventionsHandicapCertificateDemand.Id,
                        conventionsHandicapCertificateDemand.AcademyName,
                        conventionsHandicapCertificateDemand.DepartmentName,
                        conventionsHandicapCertificateDemand.ChildFirstName,
                        conventionsHandicapCertificateDemand.ChildLastName,
                        conventionsHandicapCertificateDemand.ChildDateOfBirth,
                        conventionsHandicapCertificateDemand.WorkspaceId,
                        conventionsHandicapCertificateDemand.CertificateDemandStatus,
                        conventionsHandicapCertificateDemand.UserId,
                        conventionsHandicapCertificateDemand.CertificateTemplates?.Select(template => template.Id).ToArray(),
                        conventionsHandicapCertificateDemand.Properties?.Select(metadata => new Property(metadata.Code, metadata.Value)).ToArray());
        }
    }
}
