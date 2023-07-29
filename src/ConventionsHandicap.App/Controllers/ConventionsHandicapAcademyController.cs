using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Contracts;
using ConventionsHandicap.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using ConventionsHandicap.Model;
using System.ComponentModel;
using Anabasis.Api;

namespace ConventionsHandicap
{

    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/v1/referential")]
    public class AcademyController : ControllerBase
    {
        private readonly IConventionsHandicapReferentialService _conventionsHandicapReferentialService;

        public AcademyController(IConventionsHandicapReferentialService conventionsHandicapReferentialService)
        {
            _conventionsHandicapReferentialService = conventionsHandicapReferentialService;
        }
        
        [ProducesResponseType(typeof(ErrorResponseMessage),(int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Academy[]), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAcademies")]
        [HttpGet("academies")]
        public async Task<IActionResult> GetAcademiesAsync()
        {
            var academies = await _conventionsHandicapReferentialService.GetAcademiesAsync();

            return Ok(academies);
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Academy), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetOneAcademy")]
        [HttpGet("academies/{academyName}")]
        public async Task<IActionResult> GetOneAcademyAsync(string academyName)
        {
            var academy = await _conventionsHandicapReferentialService.GetAcademyAsync(academyName);

            return Ok(academy);
        }
    }
}
