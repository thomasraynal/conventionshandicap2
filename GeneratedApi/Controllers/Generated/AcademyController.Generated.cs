using Anabasis.Api;
using ConventionsHandicap.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GeneratedApi.Controllers.Generated
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/v1/referential")]
    public class AcademyController : ControllerBase
    {


        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Academy[]), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAcademies")]
        [HttpGet("academies")]
        public async Task<IActionResult> GetAcademiesAsync()
        {
            //var academies = await _conventionsHandicapReferentialService.GetAcademiesAsync();

            //return Ok(academies);

            throw new NotImplementedException();
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Academy), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetOneAcademy")]
        [HttpGet("academies/{academyName}")]
        public async Task<IActionResult> GetOneAcademyAsync(string academyName)
        {
            //var academy = await _conventionsHandicapReferentialService.GetAcademyAsync(academyName);

            //return Ok(academy);

            throw new NotImplementedException();
        }
    }
}
