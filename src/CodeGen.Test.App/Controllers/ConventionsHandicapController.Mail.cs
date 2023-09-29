using ConventionsHandicap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap
{
    public partial class ConventionsHandicapController
    {
        protected override Task<SendMailResponseBuilder> SendMailInternalAsync(ConventionsHandicapSendMailToConventionHandicapDto requestBody)
        {
            return base.SendMailInternalAsync(requestBody);
        }
    }
}
