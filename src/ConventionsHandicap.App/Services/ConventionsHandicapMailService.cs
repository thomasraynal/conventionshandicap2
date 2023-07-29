using ConventionsHandicap.App.Contracts;
using ConventionsHandicap.App.Shared;
using ConventionsHandicap.Contracts;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Services
{
    public class ConventionsHandicapMailService: MailServiceBase, IConventionsHandicapMailService
    {
        public ConventionsHandicapMailService(ConventionsHandicapConfigurationOptions conventionsHandicapConfigurationOptions) : base(conventionsHandicapConfigurationOptions)
        {
        }

        public async Task SendEmailFromConventionsHandicap(ConventionsHandicapUser conventionsHandicapUser, ConventionsHandicapSendMailFromConventionsHandicapRequest sendMailRequest)
        {
            var conventionsHandicapMailMessage = new ConventionsHandicapMailMessage(conventionsHandicapUser.Email,
              sendMailRequest.SubjectText,
              sendMailRequest.BodyText);

            await SendEmailAsync(conventionsHandicapMailMessage, sendMailRequest.IsHtml);
        }

        public async Task SendEmailToConventionsHandicap(ConventionsHandicapUser conventionsHandicapUser, ConventionsHandicapSendMailToConventionsHandicapRequest sendMailRequest)
        {
            var conventionsHandicapMailMessage = new ConventionsHandicapMailMessage(ConventionsHandicapConfigurationOptions.ConventionsHandicapMail,
              sendMailRequest.SubjectText,
              sendMailRequest.BodyText);

            await SendEmailAsync(conventionsHandicapMailMessage, sendMailRequest.IsHtml);
        }

    }
}
