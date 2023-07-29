using ConventionsHandicap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Controllers.Dto
{
    public class CertificateTemplateDto
    {
        public CertificateTemplateDto(Guid id, string academy, string department, string templateName)
        {
            Id = id;
            Academy = academy;
            Department = department;
            TemplateName = templateName;
        }

        public Guid Id { get; set; }
        public string Academy { get; set; }
        public string Department { get; set; }
        public string TemplateName { get; set; }
        public string FriendlyName => TemplateName;
    }
}
