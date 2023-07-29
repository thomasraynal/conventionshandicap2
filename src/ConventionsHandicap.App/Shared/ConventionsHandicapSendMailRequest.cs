using ConventionsHandicap.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Contracts
{
    public class ConventionsHandicapSendMailToConventionsHandicapRequest
    {
        public ConventionsHandicapSendMailToConventionsHandicapRequest()
        {
        }

        public ConventionsHandicapSendMailToConventionsHandicapRequest(Guid workspaceId, ConventionsHandicapUser conventionsHandicapUser, string subjectText, string bodyText, bool isHtml)
        {
            ConventionsHandicapUser = conventionsHandicapUser;
            WorkspaceId = workspaceId;
            SubjectText = subjectText;
            BodyText = bodyText;
            IsHtml = isHtml;
        }

        public ConventionsHandicapUser ConventionsHandicapUser { get; set; }
        public Guid WorkspaceId { get; set; }
        public string SubjectText { get; set; }
        public string BodyText { get; set; }
        public bool IsHtml { get; set; }
    }

    public class ConventionsHandicapSendMailFromConventionsHandicapRequest
    {
        public ConventionsHandicapSendMailFromConventionsHandicapRequest()
        {
        }

        public ConventionsHandicapSendMailFromConventionsHandicapRequest(Guid workspaceId, ConventionsHandicapUser conventionsHandicapUser, string subjectText, string bodyText, bool isHtml)
        {
            ConventionsHandicapUser = conventionsHandicapUser;
            WorkspaceId = workspaceId;
            SubjectText = subjectText;
            BodyText = bodyText;
            IsHtml = isHtml;
        }

        public ConventionsHandicapUser ConventionsHandicapUser { get; set; }
        public Guid WorkspaceId { get; set; }
        public string SubjectText { get; set; }
        public string BodyText { get; set; }
        public bool IsHtml { get; set; }
    }
}
