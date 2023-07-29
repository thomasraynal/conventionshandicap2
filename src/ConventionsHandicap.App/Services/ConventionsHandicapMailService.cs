using ConventionsHandicap.App.Contracts;
using ConventionsHandicap.App.Shared;
using ConventionsHandicap.Contracts;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Services
{
    public class ConventionsHandicapMailService: MailServiceBase, IConventionsHandicapMailService
    {
        public ConventionsHandicapMailService(ConventionsHandicapConfigurationOptions conventionsHandicapConfigurationOptions) : base(conventionsHandicapConfigurationOptions)
        {
        }

        public async Task SendEmailToConventionsHandicap(ConventionsHandicapUser conventionsHandicapUser, ConventionsHandicapSendMailRequest sendMailRequest)
        {

            var conventionsHandicapMailMessage = new ConventionsHandicapMailMessage(ConventionsHandicapConfigurationOptions.ConventionsHandicapMail,
              sendMailRequest.SubjectText,
              sendMailRequest.BodyText, conventionsHandicapUser);

            await SendEmailAsync(conventionsHandicapMailMessage, sendMailRequest.IsHtml);
        }
    }
}
