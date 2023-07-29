using Anabasis.Api;
using ConventionsHandicap.App.Contracts;
using ConventionsHandicap.App.Controllers.Dto;
using ConventionsHandicap.Contracts;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/v1/mail")]
    public class ConventionsHandicapMailController : ControllerBase
    {
        private readonly IConventionsHandicapMailService _mailService;
        private readonly UserManager<ConventionsHandicapUser> _userManager;

        public ConventionsHandicapMailController(IConventionsHandicapMailService mailService, UserManager<ConventionsHandicapUser> userManager)
        {
            _mailService = mailService;
            _userManager = userManager;
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [SwaggerOperation("SendMailToConventionHandicap")]
        [HttpPost()]
        public async Task<IActionResult> SendMailToConventionHandicapAsync([FromBody] ConventionsHandicapSendMailToConventionHandicapDto sendMailRequest)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var sendMailToCapHandicapRequest = new ConventionsHandicapSendMailToConventionsHandicapRequest()
            {
                BodyText = sendMailRequest.BodyText,
                ConventionsHandicapUser = currentUser,
                IsHtml = false,
                SubjectText = sendMailRequest.SubjectText,
                WorkspaceId = sendMailRequest.WorkspaceId.Value
            };

            await _mailService.SendEmailToConventionsHandicap(currentUser, sendMailToCapHandicapRequest);

            return Accepted();
        }
    }
}
