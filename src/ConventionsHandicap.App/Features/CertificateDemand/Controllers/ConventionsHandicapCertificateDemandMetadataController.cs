using Anabasis.Api;
using ConventionsHandicap.App.Features.CertificateDemand.Contracts;
using ConventionsHandicap.App.Features.CertificateDemand.Controllers.Dto;
using ConventionsHandicap.Model.Features.CertificateDemand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ConventionsHandicap
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/v1/features/certificates/demands/medatada")]
    public class ConventionsHandicapCertificateDemandMetadataController : ControllerBase
    {
        private readonly IConventionsHandicapMetadataService _conventionsHandicapMetadataService;

        public ConventionsHandicapCertificateDemandMetadataController(IConventionsHandicapMetadataService conventionsHandicapMetadataService)
        {
            _conventionsHandicapMetadataService = conventionsHandicapMetadataService;
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ConventionsHandicapCertificateMetadata[]), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetMetadata")]
        [HttpGet()]
        public IActionResult GetMetadata()
        {
            return Ok(_conventionsHandicapMetadataService.GetMetadatas());
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ConventionsHandicapCertificateMetadata[]), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetMetadataByAcademy")]
        [HttpGet("{academyId}")]
        public IActionResult GetMetadataByAcademy(string academyId)
        {
            return Ok(_conventionsHandicapMetadataService.GetMetadatasByAcademy(academyId));
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ConventionsHandicapCertificateMetadata[]), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetMetadataByAcademyAndDepartment")]
        [HttpGet("{academyId}/{departmentId}")]
        public IActionResult GetMetadataByAcademyAndDepartment(string academyId, string departmentId)
        {
            return Ok(_conventionsHandicapMetadataService.GetMetadatasByAcademyAndDepartment(academyId, departmentId));
        }

    }
}
