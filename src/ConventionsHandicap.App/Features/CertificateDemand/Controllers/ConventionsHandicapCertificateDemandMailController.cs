using Anabasis.Api;
using ConventionsHandicap.App.Contracts;
using ConventionsHandicap.App.Features.CertificateDemand.Contracts;
using ConventionsHandicap.App.Features.CertificateDemand.Controllers.Dto;
using ConventionsHandicap.App.Features.CertificateDemand.Services;
using ConventionsHandicap.Contracts;
using ConventionsHandicap.Controller.Dto;
using ConventionsHandicap.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/v1/features/certificates/demands/mail")]
    public class ConventionsHandicapCertificateDemandMailController : ControllerBase
    {
        private readonly IConventionsHandicapCertificateDemandMailService _conventionsHandicapCertificateDemandMailService;
        private readonly IConventionsHandicapCertificateDemandService _conventionsHandicapCertificateDemandService;
        private readonly UserManager<ConventionsHandicapUser> _userManager;

        public ConventionsHandicapCertificateDemandMailController(IConventionsHandicapCertificateDemandMailService conventionsHandicapCertificateDemandMailService,
            IConventionsHandicapCertificateDemandService conventionsHandicapCertificateDemandService,
            UserManager<ConventionsHandicapUser> userManager)
        {
            _conventionsHandicapCertificateDemandMailService = conventionsHandicapCertificateDemandMailService;
            _conventionsHandicapCertificateDemandService = conventionsHandicapCertificateDemandService;

            _userManager = userManager;
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [SwaggerOperation("SendMailToCertificateOwner")]
        [HttpPost()]
        public async Task<IActionResult> SendMailToCertificateOwner([FromBody] ConventionsHandicapCertificateDemandSendMailRequest sendMailRequest)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var certificateDemandOwnerId = await _conventionsHandicapCertificateDemandService.GetCertificateDemandOwnerIdAsync(currentUser, sendMailRequest.CertificateDemandId.Value);

            var certificateOwner = await _userManager.FindByIdAsync($"{certificateDemandOwnerId}");

            await _conventionsHandicapCertificateDemandMailService.SendEmailToCertificateDemandOwner(currentUser, certificateOwner.Email, sendMailRequest);

            return Accepted();
        }
    }
}
