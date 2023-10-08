using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Contracts
{
    public interface IConventionsHandicapCertificateDemandMailService
    {
        Task SendEmailToCertificateDemandOwnerAsync(ConventionsHandicapUser currentUser, string certificateDemandOwnerMail, ConventionsHandicapCertificateDemandSendMailRequest sendMailRequest);
    }
}
