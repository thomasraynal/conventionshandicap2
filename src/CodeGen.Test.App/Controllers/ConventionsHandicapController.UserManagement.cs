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
        protected override Task<ConfirmMailResponseBuilder> ConfirmMailInternalAsync(string EmailEmail, string TokenToken)
        {
            return base.ConfirmMailInternalAsync(EmailEmail, TokenToken);
        }

        protected override Task<ForgotPasswordResponseBuilder> ForgotPasswordInternalAsync(ForgotPasswordDto requestBody)
        {
            return base.ForgotPasswordInternalAsync(requestBody);
        }

        protected override Task<LoginResponseBuilder> LoginInternalAsync(ConventionsHandicapLoginDto requestBody)
        {
            return base.LoginInternalAsync(requestBody);
        }

        protected override Task<RegisterResponseBuilder> RegisterInternalAsync(RegistrationDto requestBody)
        {
            return base.RegisterInternalAsync(requestBody);
        }

        protected override Task<ResetPasswordResponseBuilder> ResetPasswordInternalAsync(ResetPasswordDto requestBody)
        {
            return base.ResetPasswordInternalAsync(requestBody);
        }
    }
}