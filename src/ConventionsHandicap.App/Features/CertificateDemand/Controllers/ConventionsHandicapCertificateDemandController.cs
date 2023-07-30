using ConventionsHandicap.Contracts;
using ConventionsHandicap.Controller.Dto;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Services;
using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Features.CertificateDemand.Contracts;
using ConventionsHandicap.App.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ConventionsHandicap.App.Features.CertificateDemand.Controllers.Dto;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Anabasis.Api;

namespace ConventionsHandicap
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/v1/features/certificates/demands")]
    public class ConventionsHandicapCertificateDemandController : ControllerBase
    {

        private readonly IConventionsHandicapCertificateDemandService _certificateDemandService;
        private readonly IConventionsHandicapWorkspaceService _conventionsHandicapWorkspaceService;
        private readonly IConventionsHandicapCertificateDemandMailService _mailService;
        private readonly UserManager<ConventionsHandicapUser> _userManager;

        public ConventionsHandicapCertificateDemandController(
            IConventionsHandicapWorkspaceService conventionsHandicapWorkspaceService,
            IConventionsHandicapCertificateDemandService certificateDemandService,
            IConventionsHandicapCertificateDemandMailService mailService,
            UserManager<ConventionsHandicapUser> userManager)
        {
            _certificateDemandService = certificateDemandService;
            _conventionsHandicapWorkspaceService = conventionsHandicapWorkspaceService;
            _mailService = mailService;
            _userManager = userManager;
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(CertificateDemandDto[]), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAllCertificateDemands")]
        [HttpGet()]
        public async Task<IActionResult> GetAllCertificateDemandsAsync([FromQuery][Required] Guid workspaceId)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, workspaceId);

            if (currentUserRoleOnWorkspace.IsAdministrator() || currentUserRoleOnWorkspace.IsManager())
            {
                return Ok(await _certificateDemandService.GetAllCertificateDemandsByWorkspaceAsync(currentUser, workspaceId));
            }

            return Ok(await _certificateDemandService.GetAllMyCertificateDemandsByWorkspaceAsync(currentUser, workspaceId));

        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [SwaggerOperation("DeleteCertificateDemand")]
        [HttpDelete()]
        public async Task<IActionResult> DeleteCertificateDemandAsync([FromRoute] DeleteCertificateDemandDto deleteCertificateDemandDto)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, deleteCertificateDemandDto.WorkspaceId);

            var certificateDemandOwnerId = await _certificateDemandService.GetCertificateDemandOwnerIdAsync(currentUser, deleteCertificateDemandDto.CertificateDemandId);

            if (!currentUserRoleOnWorkspace.IsAdministrator() && !currentUserRoleOnWorkspace.IsManager() && (certificateDemandOwnerId !=  currentUser.Id))
            {
                throw new ConventionsHandicapUnauthorizedException($"User {currentUser.Id} is not authorized to delete demand {deleteCertificateDemandDto.CertificateDemandId}");
            }

            await _certificateDemandService.DeleteCertificateDemandAsync(currentUser, deleteCertificateDemandDto.CertificateDemandId);

            return NoContent();
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(CertificateDemandDto), (int)HttpStatusCode.OK)]
        [SwaggerOperation("CreateCertificateDemand")]
        [HttpPut()]
        public async Task<IActionResult> CreateCertificateDemandAsync([FromBody] CreateCertificateDemandDto createCertificateDemandDto)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var certificateDemand = await _certificateDemandService.CreateCertificateDemandAsync(currentUser, createCertificateDemandDto);

            return Ok(certificateDemand);
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(CertificateDemandDto), (int)HttpStatusCode.OK)]
        [SwaggerOperation("UpdateCertificateDemand")]
        [HttpPatch()]
        public async Task<IActionResult> UpdateCertificateDemandAsync([FromBody] UpdateCertificateDemandDto updateCertificateDemandDto)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, updateCertificateDemandDto.WorkspaceId.Value);

            var certificateDemandOwnerId = await _certificateDemandService.GetCertificateDemandOwnerIdAsync(currentUser, updateCertificateDemandDto.CertificateDemandId.Value);

            if (!currentUserRoleOnWorkspace.IsAdministrator() && !currentUserRoleOnWorkspace.IsManager() && (certificateDemandOwnerId != currentUser.Id))
            {
                throw new ConventionsHandicapUnauthorizedException($"User {currentUser.Id} is not authorized to update demand {updateCertificateDemandDto.CertificateDemandId}");
            }

            var (certificateDemand, hasCertificateDemandStatusChanged) = await _certificateDemandService.UpdateCertificateDemandAsync(currentUser, updateCertificateDemandDto);

            if (hasCertificateDemandStatusChanged)
            {

                var certficateDemandUser = await _userManager.FindByIdAsync($"{certificateDemandOwnerId}");

                await _mailService.SendEmailToCertificateDemandOwnerAsync(ConventionsHandicapUserAdmin.Self, certficateDemandUser.Email, new ConventionsHandicapCertificateDemandSendMailRequest()
                {
                    IsHtml = true,
                    BodyText = $"<h2 style=\"color: #2e6c80;\">Attestation pour {certificateDemand.ChildLastName} {certificateDemand.ChildFirstName}:</h2> <p>Status: {certificateDemand.CertificateDemandStatus}</p> <p>Rendez-vous sur le site pour consulter votre demande : <a href=\"https://conventionshandicap.fr\">https://conventionshandicap.fr</a></p> <p>&nbsp;</p>",
                    CertificateDemandId = certificateDemand.Id,
                    SubjectText = "Votre demande d'attestation a changée de status",
                });

            }

            return Ok(certificateDemand);
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(CertificateDemandDto), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetCertificateDemand")]
        [HttpGet("{certificateDemandId}")]
        public async Task<IActionResult> GetCertificateDemandAsync([FromRoute][Required] Guid certificateDemandId, [FromQuery][Required] Guid workspaceId)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, workspaceId);

            var certificateDemandOwnerId = await _certificateDemandService.GetCertificateDemandOwnerIdAsync(currentUser, certificateDemandId);

            if (!currentUserRoleOnWorkspace.IsAdministrator() && !currentUserRoleOnWorkspace.IsManager() && (certificateDemandOwnerId != currentUser.Id))
            {
                throw new ConventionsHandicapUnauthorizedException($"User {currentUser.Id} is not authorized to get demand {certificateDemandId}");
            }


            return Ok(await _certificateDemandService.GetOneCertificateDemandAsync(currentUser, certificateDemandId));
        }

        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponseMessage), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(CertificateDemandDto), (int)HttpStatusCode.OK)]
        [SwaggerOperation("SaveFile")]
        [HttpPost("{certificateDemandId}/file/{metadataCode}")]
        public async Task<IActionResult> SaveFileAsync(IFormFile file, [FromRoute][Required] Guid certificateDemandId, [FromRoute][Required] string metadataCode, [FromQuery][Required] Guid workspaceId)
        {

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, workspaceId);

            var certificateDemandOwnerId = await _certificateDemandService.GetCertificateDemandOwnerIdAsync(currentUser, certificateDemandId);

            if (!currentUserRoleOnWorkspace.IsAdministrator() && !currentUserRoleOnWorkspace.IsManager() && (certificateDemandOwnerId != currentUser.Id))
            {
                throw new ConventionsHandicapUnauthorizedException($"User {currentUser.Id} is not authorized to update demand {certificateDemandId}");
            }

            var currentCertificateDemand = await _certificateDemandService.GetOneCertificateDemandAsync(currentUser, certificateDemandId);

            if(null == currentCertificateDemand)
            {
                throw new ConventionsHandicapNotFoundException($"Demand {certificateDemandId} does not exist");
            }

            var updatedCertificateDemand = await _certificateDemandService.SaveFileAsync(currentUser, certificateDemandId, metadataCode, file);

            if (currentCertificateDemand.CertificateDemandStatus != updatedCertificateDemand.CertificateDemandStatus)
            {
                var certficateDemandUser = await _userManager.FindByIdAsync($"{certificateDemandOwnerId}");

                await _mailService.SendEmailToCertificateDemandOwnerAsync(ConventionsHandicapUserAdmin.Self, certficateDemandUser.Email, new ConventionsHandicapCertificateDemandSendMailRequest()
                {
                    IsHtml = true,
                    BodyText = $"<h2 style=\"color: #2e6c80;\">Attestation pour {updatedCertificateDemand.ChildLastName} {updatedCertificateDemand.ChildFirstName}:</h2> <p>Status: {updatedCertificateDemand.CertificateDemandStatus}</p> <p>Rendez-vous sur le site pour consulter votre demande : <a href=\"https://conventionshandicap.fr\">https://conventionshandicap.fr</a></p> <p>&nbsp;</p>",
                    CertificateDemandId = certificateDemandId,
                    SubjectText = "Votre demande d'attestation a changée de status",
                });
            }

            return Ok(updatedCertificateDemand);
        }
    }
}
