using Anabasis.Identity;
using ConventionsHandicap.Model;
using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var bodyContent = "Cliquez sur le lien pour confirmer votre email:" +
            Environment.NewLine +
                              $"{ConventionsHandicapConfigurationOptions.ConventionsHandicapUri}/confirm?email={email}&token={token}";

            var cpnventionsHandicapMailMessage = new ConventionsHandicapMailMessage(email,
               "Veuillez confirmer votre mail",
               bodyContent,
               null);

            await SendEmailAsync(cpnventionsHandicapMailMessage, false);
        }

        public Task SendEmailPasswordReset(string email, string token)
        {
            throw new NotImplementedException();
        }

    }
}
