using Anabasis.Api;
using ConventionsHandicap.App.Contracts;
using ConventionsHandicap.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/v1/features")]
    public class ConventionsHandicapFeatureController : ControllerBase
    {
        private readonly IConventionsHandicapFeaturesService _conventionsHandicapFeaturesService;

        public ConventionsHandicapFeatureController(IConventionsHandicapFeaturesService conventionsHandicapFeaturesService)
        {
            _conventionsHandicapFeaturesService = conventionsHandicapFeaturesService;
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ConventionsHandicapFeature[]), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetFeatures")]
        [HttpGet()]
        public async Task<IActionResult> GetFeaturesAsync([FromQuery] Guid? workspaceId)
        {
            ConventionsHandicapFeature[] conventionsHandicapFeatures;

            if(null != workspaceId)
            {
                conventionsHandicapFeatures = await _conventionsHandicapFeaturesService.GetConventionsHandicapFeatureByWorkspaceAsync(workspaceId.Value);
            }
            else
            {
                conventionsHandicapFeatures = await _conventionsHandicapFeaturesService.GetConventionsAllHandicapFeatureAsync();
            }

            return Ok(conventionsHandicapFeatures);
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ConventionsHandicapFeature), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetFeature")]
        [HttpGet("{featureId}")]
        public async Task<IActionResult> GetFeatureByIdAsync(Guid featureId)
        {
            var feature = await _conventionsHandicapFeaturesService.GetConventionsOneHandicapFeatureAsync(featureId);

            return Ok(feature);
        }
    }
}
