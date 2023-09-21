using ConventionsHandicap.Model;
using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Shared;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Services
{
    public abstract class MailServiceBase
    {
  
        protected MailServiceBase(ConventionsHandicapConfigurationOptions conventionsHandicapConfigurationOptions)
        {
            ConventionsHandicapConfigurationOptions = conventionsHandicapConfigurationOptions;
        }

        public ConventionsHandicapConfigurationOptions ConventionsHandicapConfigurationOptions { get; }

        public async Task SendEmailAsync(ConventionsHandicapMailMessage message, bool isHtml)
        {
            var mailMessage = CreateEmailMessage(message, isHtml);

#if DEBUG
            return;
#endif

            using var client = new SmtpClient(new ProtocolLogger(Console.OpenStandardOutput()));
            try
            {
                await client.ConnectAsync(ConventionsHandicapConfigurationOptions.MailgunConfiguration.SmtpServer, ConventionsHandicapConfigurationOptions.MailgunConfiguration.Port, false);

                await client.AuthenticateAsync(ConventionsHandicapConfigurationOptions.MailgunConfiguration.UserName, ConventionsHandicapConfigurationOptions.MailgunConfiguration.Password);

                await client.SendAsync(mailMessage);
            }
            catch
            {
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);

                client.Dispose();
            }
        }

        private MimeMessage CreateEmailMessage(ConventionsHandicapMailMessage message, bool isHtml)
        {

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("ConventionsHandicap", ConventionsHandicapConfigurationOptions.ConventionsHandicapMail));
            emailMessage.To.Add(message.To);
            emailMessage.Subject = message.Subject;

            var bodyContent = message.Content;

            var bodyBuilder = isHtml ? new BodyBuilder { HtmlBody = bodyContent } : new BodyBuilder { TextBody = bodyContent };

            emailMessage.Body = bodyBuilder.ToMessageBody();

            return emailMessage;

        }

    }
}
