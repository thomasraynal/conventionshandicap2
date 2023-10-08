using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Features.CertificateDemand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Shared
{
    public class ConventionsHandicapCertificateAcademyMetadata : ConventionsHandicapCertificateMetadata
    {

        public ConventionsHandicapCertificateAcademyMetadata(string academy, string department, ConventionsHandicapCertificateMetadata metadata) : base(metadata.Code, metadata.Label, metadata.Information, metadata.Group, metadata.DataType, metadata.MetadataType)
        {
            Academy = academy;
            Department = department;
        }

        public ConventionsHandicapCertificateAcademyMetadata(string code, string label, string information, string group, string type, string metadataType, string academy, string department) : base(code, label, information, group, type, metadataType)
        {
            Academy = academy;
            Department = department;
        }

        public string Academy { get; }
        public string Department { get; }
    }

}
