using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Controllers.Dto
{
    public class ConventionsHandicapCertificateDemandSendMailRequest
    {
        public ConventionsHandicapCertificateDemandSendMailRequest()
        {
        }

        public ConventionsHandicapCertificateDemandSendMailRequest(Guid workspaceId, Guid? certificateDemandId, string subjectText, string bodyText, bool isHtml)
        {
            WorkspaceId = workspaceId;
            CertificateDemandId = certificateDemandId;
            SubjectText = subjectText;
            BodyText = bodyText;
            IsHtml = isHtml;
        }
        public Guid WorkspaceId { get; set; }
        public Guid? CertificateDemandId { get; set; }
        public string SubjectText { get; set; }
        public string BodyText { get; set; }
        public bool IsHtml { get; set; }
    }
}
