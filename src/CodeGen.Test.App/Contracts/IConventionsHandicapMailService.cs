﻿using ConventionsHandicap.Contracts;
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
        Task SendEmailFromConventionsHandicapAsync(ConventionsHandicapUser conventionsHandicapUser, ConventionsHandicapSendMailFromConventionsHandicapRequest sendMailRequest);
        Task SendEmailToConventionsHandicapAsync(ConventionsHandicapUser conventionsHandicapUser, ConventionsHandicapSendMailToConventionsHandicapRequest sendMailRequest);
    }
}
