using Anabasis.Api;
using ConventionsHandicap.App.Contracts;
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
        public async Task<IActionResult> SendMailToConventionHandicapAsync([FromBody] ConventionsHandicapSendMailRequest sendMailRequest)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            await _mailService.SendEmailToConventionsHandicap(currentUser, sendMailRequest);

            return Accepted();
        }
    }
}
