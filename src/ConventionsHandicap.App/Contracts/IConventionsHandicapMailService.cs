using ConventionsHandicap.Contracts;
using ConventionsHandicap.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Contracts
{
    public interface IConventionsHandicapMailService
    {
        Task SendEmailFromConventionsHandicap(ConventionsHandicapUser conventionsHandicapUser, ConventionsHandicapSendMailFromConventionsHandicapRequest sendMailRequest);
        Task SendEmailToConventionsHandicap(ConventionsHandicapUser conventionsHandicapUser, ConventionsHandicapSendMailToConventionsHandicapRequest sendMailRequest);
    }
}
