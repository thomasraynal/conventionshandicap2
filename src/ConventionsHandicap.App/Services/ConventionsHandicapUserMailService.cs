using Anabasis.Identity;
using ConventionsHandicap.Model;
using ConventionsHandicap.App.Shared;
using System;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Services
{
    public class ConventionsHandicapUserMailService : MailServiceBase, IUserMailService
    {
        public ConventionsHandicapUserMailService(ConventionsHandicapConfigurationOptions conventionsHandicapConfigurationOptions) : base(conventionsHandicapConfigurationOptions)
        {
        }

        public async Task SendEmailConfirmationToken(string email, string token)
        {
            var bodyContent = 
                "Cliquez sur le lien pour confirmer votre email:" +
            Environment.NewLine +
                $"{ConventionsHandicapConfigurationOptions.ConventionsHandicapUri}/confirm?email={email}&token={token}";

            var cpnventionsHandicapMailMessage = new ConventionsHandicapMailMessage(email,
               "ConventionsHandicap - Veuillez confirmer votre mail",
               bodyContent);

            await SendEmailAsync(cpnventionsHandicapMailMessage, false);
        }

        public Task SendEmailPasswordReset(string email, string token)
        {
            throw new NotImplementedException();

            //var bodyContent =
            //    "Cliquez sur le lien pour chnager votre mot de pass:" +
            //Environment.NewLine +
            //    $"{ConventionsHandicapConfigurationOptions.ConventionsHandicapUri}/reset?email={email}&token={token}";

            //var cpnventionsHandicapMailMessage = new ConventionsHandicapMailMessage(email,
            //   "ConventionsHandicap - Veuillez confirmer votre mail",
            //   bodyContent);

            //await SendEmailAsync(cpnventionsHandicapMailMessage, false);
        }

    }
}
