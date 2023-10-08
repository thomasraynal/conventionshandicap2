using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model
{
    public partial class CertificateTemplateDto
    {
        public CertificateTemplateDto(Guid id, string academyName, string departmentName, string friendlyName)
        {
            Id = id;
            Academy = academyName;
            Department= departmentName;
            FriendlyName = friendlyName;
        }
    }
}
