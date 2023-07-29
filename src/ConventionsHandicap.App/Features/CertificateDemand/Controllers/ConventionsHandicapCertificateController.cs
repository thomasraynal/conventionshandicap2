using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Features.CertificateDemand.Contracts;
using ConventionsHandicap.App.Features.CertificateDemand.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using ConventionsHandicap.Model.Contracts;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.IO;
using ConventionsHandicap.App.Features.CertificateDemand.Controllers.Dto;
using Anabasis.Api;

namespace ConventionsHandicap.Controller
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/v1/features/certificates/demands/template")]
    public class ConventionsHandicapCertificateDemandTemplateController : ControllerBase
    {
        private readonly IConventionsHandicapGenerateCertificateService _certificateService;
        private readonly UserManager<ConventionsHandicapUser> _userManager;

        public ConventionsHandicapCertificateDemandTemplateController(IConventionsHandicapGenerateCertificateService certificateService, 
            UserManager<ConventionsHandicapUser> userManager)
        {
            _certificateService = certificateService;
            _userManager = userManager;
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GenerateCertificate")]
        [HttpGet("generate/{certificateDemandId}/{certificateTemplateId}")]
        public async Task<IActionResult> GenerateCertificate([FromRoute] Guid certificateDemandId, [FromRoute] Guid certificateTemplateId)
        {

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (null == currentUser)
            {
                throw new ConventionsHandicapNotFoundException($"User not found");
            }

            var generatedertificate = await _certificateService.GenerateCertificateAsync(currentUser, certificateDemandId, certificateTemplateId);

            var contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            var fileName = generatedertificate.GetFileName();

            return File(System.IO.File.ReadAllBytes(generatedertificate.CertificateFileInfo.FullName), contentType, fileName);

        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(CertificateTemplateDto), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetCertificateTemplates")]
        [HttpGet()]
        public async Task<IActionResult> GetCertificateTemplatesAsync()
        {
            var certificates = await _certificateService.GetCertificatesAsync();

            return Ok(certificates.Select(certificate => certificate.ToCertificateDemandDto()));
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(CertificateTemplateDto[]), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetCertificateTemplatesByAcademy")]
        [HttpGet("{academy}")]
        public async Task<IActionResult> GetCertificateTemplatesByAcademyAsync([FromRoute] string academy)
        {
            var certificates = await _certificateService.GetCertificatesTemplatesByAcademyAsync(academy);

            return Ok(certificates.Select(certificate => certificate.ToCertificateDemandDto()));
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(CertificateTemplateDto[]), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetCertificateTemplatesByAcademyAndDepartment")]
        [HttpGet("{academy}/{department}")]
        public async Task<IActionResult> GetCertificateTemplatesByAcademyAndDepartmentAsync([FromRoute] string academy, [FromRoute] string department)
        {
            var certificates = await _certificateService.GetCertificateTemplatesByAcademyAndDepartmentAsync(academy, department);

            return Ok(certificates.Select(certificate => certificate.ToCertificateDemandDto()));
        }
    }
}
