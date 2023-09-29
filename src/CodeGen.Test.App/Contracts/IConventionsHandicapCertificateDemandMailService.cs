using Anabasis.Identity;
using ConventionsHandicap.App.Features.CertificateDemand.Controllers.Dto;
using ConventionsHandicap.EntityFramework;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Contracts
{
    public interface IConventionsHandicapCertificateDemandMailService
    {
        Task SendEmailToCertificateDemandOwnerAsync(ConventionsHandicapUser currentUser, string certificateDemandOwnerMail, ConventionsHandicapCertificateDemandSendMailRequest sendMailRequest);
    }
}
