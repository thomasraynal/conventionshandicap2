using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Contracts
{
    public class ConventionsHandicapSendMailRequest
    {
        public ConventionsHandicapSendMailRequest()
        {
        }

        public ConventionsHandicapSendMailRequest(Guid? userId, Guid workspaceId, bool isMailToUser, string subjectText, string bodyText, bool isHtml)
        {
            UserId = userId;
            WorkspaceId = workspaceId;
            IsMailToUser = isMailToUser;
            SubjectText = subjectText;
            BodyText = bodyText;
            IsHtml = isHtml;
        }

        public Guid? UserId { get; set; }
        public Guid WorkspaceId { get; set; }
        public bool IsMailToUser { get; set; }
        public string SubjectText { get; set; }
        public string BodyText { get; set; }
        public bool IsHtml { get; set; }
    }
}
