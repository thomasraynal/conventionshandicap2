using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model.Features.CertificateDemand
{
    public class ConventionsHandicapCertificateMetadataValue
    {
        public ConventionsHandicapCertificateMetadataValue()
        {
        }

        public ConventionsHandicapCertificateMetadataValue(string code, string? value)
        {
            Code = code;
            Value = value;
        }

        public string Code { get; set; }
        public string? Value { get; set; }

        [ForeignKey("CertificateDemandId")]
        public Guid CertificateDemandId { get; set; }
        public ConventionsHandicapCertificateDemand CertificateDemand { get; set; }
    }
}
