using ConventionsHandicap.Model.Features.CertificateDemand;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Shared
{
    public class ConventionsHandicapGeneratedCertificate
    {
        public ConventionsHandicapCertificateTemplate CertificateTemplate { get; set; }
        public FileInfo CertificateFileInfo { get; set; }
        public ConventionsHandicapCertificateMetadataValue[] MedataValues { get; set; }

        public string GetFileName()
        {
            return $"{CertificateTemplate.TemplateName}_{Guid.NewGuid()}.docx";
        }

        public void Delete()
        {
            File.Delete(CertificateFileInfo.FullName);
        }
    }
}
