using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model.Features.CertificateDemand
{
    public class ConventionsHandicapCertificateGenerationDemand
    {
        public ConventionsHandicapCertificateTemplate CertificateTemplate { get; set; }
        public FileInfo CertificateFileInfo { get; set; }
        public ConventionsHandicapCertificateMetadataValue[] CertificateDemandMedataValues { get; set; }

        public string GetFileName()
        {
            return $"{CertificateTemplate.TemplateName}_{Guid.NewGuid()}.docx";
        }
    }
}
