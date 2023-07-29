using ConventionsHandicap.Model.Features.CertificateDemand;
using ConventionsHandicap.App.Features.CertificateDemand.Controllers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Shared
{
    public static class ConventionsHandicapCertificateTemplateExtensions
    {
        public static CertificateTemplateDto ToCertificateDemandDto(this ConventionsHandicapCertificateTemplate conventionsHandicapCertificateTemplate)
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
