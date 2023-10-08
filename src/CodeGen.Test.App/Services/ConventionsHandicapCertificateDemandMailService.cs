using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Services;
using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Features.CertificateDemand.Contracts;
using ConventionsHandicap.App.Services;
using ConventionsHandicap.App.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Services
{

    public class ConventionsHandicapCertificateDemandMailService : MailServiceBase, IConventionsHandicapCertificateDemandMailService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly UserManager<ConventionsHandicapUser> _userManager;
        private readonly IConventionsHandicapWorkspaceService _conventionsHandicapWorkspaceService;

        public ConventionsHandicapCertificateDemandMailService(IServiceScopeFactory serviceScopeFactory,
            IConventionsHandicapWorkspaceService conventionsHandicapWorkspaceService,
            ConventionsHandicapConfigurationOptions conventionsHandicapConfigurationOptions,
            UserManager<ConventionsHandicapUser> userManager): base(conventionsHandicapConfigurationOptions)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _userManager = userManager;
            _conventionsHandicapWorkspaceService = conventionsHandicapWorkspaceService;
        }

        public async Task SendEmailToCertificateDemandOwnerAsync(ConventionsHandicapUser currentUser, string certificateDemandOwnerMail, ConventionsHandicapCertificateDemandSendMailRequest sendMailRequest)
        {
            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, sendMailRequest.WorkspaceId);

            if (currentUserRoleOnWorkspace.IsUser())
            {
                throw new ConventionsHandicapUnauthorizedException("User is not authorized to send mail");
            }

            var conventionsHandicapMailMessage = new ConventionsHandicapMailMessage(certificateDemandOwnerMail,
                sendMailRequest.SubjectText,
                sendMailRequest.BodyText);

            await SendEmailAsync(conventionsHandicapMailMessage, sendMailRequest.IsHtml);
        }



    }
}

