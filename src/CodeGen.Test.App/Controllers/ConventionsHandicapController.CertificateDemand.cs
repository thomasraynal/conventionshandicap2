using ConventionsHandicap.App.Shared;
using ConventionsHandicap.Model;
using ConventionsHandicap.Shared;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap
{
    public partial class ConventionsHandicapController
    {
        protected async override Task<AddFileToCertificateDemandResponseBuilder> AddFileToCertificateDemandInternalAsync(Guid certificateDemandId, string metadataCode, Guid workspaceId, IFormFile file)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, workspaceId);

            var certificateDemandOwnerId = await _certificateDemandService.GetCertificateDemandOwnerIdAsync(currentUser, certificateDemandId);

            if (!currentUserRoleOnWorkspace.IsAdministrator() && !currentUserRoleOnWorkspace.IsManager() && (certificateDemandOwnerId != currentUser.Id))
            {
                throw new ConventionsHandicapUnauthorizedException($"User {currentUser.Id} is not authorized to update demand {certificateDemandId}");
            }

            var currentCertificateDemand = await _certificateDemandService.GetOneCertificateDemandAsync(currentUser, certificateDemandId);

            if (null == currentCertificateDemand)
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

        protected async override Task<CreateCertificateDemandResponseBuilder> CreateCertificateDemandInternalAsync(CreateCertificateDemandDto requestBody)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var certificateDemand = await _certificateDemandService.CreateCertificateDemandAsync(currentUser, createCertificateDemandDto);

            return Ok(certificateDemand);
        }

        protected async override Task<DeleteCertificateDemandResponseBuilder> DeleteCertificateDemandInternalAsync(Guid CertificateDemandIdCertificateDemandId, Guid WorkspaceIdWorkspaceId)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, deleteCertificateDemandDto.WorkspaceId);

            var certificateDemandOwnerId = await _certificateDemandService.GetCertificateDemandOwnerIdAsync(currentUser, deleteCertificateDemandDto.CertificateDemandId);

            if (!currentUserRoleOnWorkspace.IsAdministrator() && !currentUserRoleOnWorkspace.IsManager() && (certificateDemandOwnerId != currentUser.Id))
            {
                throw new ConventionsHandicapUnauthorizedException($"User {currentUser.Id} is not authorized to delete demand {deleteCertificateDemandDto.CertificateDemandId}");
            }

            await _certificateDemandService.DeleteCertificateDemandAsync(currentUser, deleteCertificateDemandDto.CertificateDemandId);

            return NoContent();
        }

        protected async override Task<GetAllCertificateDemandMetadataResponseBuilder> GetAllCertificateDemandMetadataInternalAsync()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, workspaceId);

            if (currentUserRoleOnWorkspace.IsAdministrator() || currentUserRoleOnWorkspace.IsManager())
            {
                return Ok(await _certificateDemandService.GetAllCertificateDemandsByWorkspaceAsync(currentUser, workspaceId));
            }

            return Ok(await _certificateDemandService.GetAllMyCertificateDemandsByWorkspaceAsync(currentUser, workspaceId));
        }

        protected async override Task<GetCertificateDemandResponseBuilder> GetCertificateDemandInternalAsync(Guid certificateDemandIdcertificateDemandId, Guid workspaceIdworkspaceId)
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

        protected override Task<GetCertificateDemandMetadataForAcademyAndDepartmentResponseBuilder> GetCertificateDemandMetadataForAcademyAndDepartmentInternalAsync(string academyIdacademyId, string departmentIddepartmentId)
        {
            return Ok(_conventionsHandicapMetadataService.GetMetadatasByAcademyAndDepartment(academyId, departmentId));
        }

        protected override Task<GetCertificateDemandMetadataForAcademyResponseBuilder> GetCertificateDemandMetadataForAcademyInternalAsync(string academyIdacademyId)
        {
            return Ok(_conventionsHandicapMetadataService.GetMetadatasByAcademy(academyId));
        }

        protected async override Task<GetCertificateDemandsResponseBuilder> GetCertificateDemandsInternalAsync(Guid workspaceIdworkspaceId)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var currentUserRoleOnWorkspace = await _conventionsHandicapWorkspaceService.GetUserRoleForWorkpaceAsync(currentUser, workspaceId);

            if (currentUserRoleOnWorkspace.IsAdministrator() || currentUserRoleOnWorkspace.IsManager())
            {
                return Ok(await _certificateDemandService.GetAllCertificateDemandsByWorkspaceAsync(currentUser, workspaceId));
            }

            return Ok(await _certificateDemandService.GetAllMyCertificateDemandsByWorkspaceAsync(currentUser, workspaceId));
        }

        protected async override Task<GenerateCertificateResponseBuilder> GenerateCertificateInternalAsync(Guid certificateDemandIdcertificateDemandId, Guid certificateTemplateIdcertificateTemplateId)
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

        protected async override Task<GetCertificateDemandTemplatesForAcademyAndDepartmentResponseBuilder> GetCertificateDemandTemplatesForAcademyAndDepartmentInternalAsync(string academyacademy, string departmentdepartment)
        {
            var certificates = await _certificateService.GetCertificateTemplatesByAcademyAndDepartmentAsync(academy, department);

            return Ok(certificates.Select(certificate => certificate.ToCertificateDemandDto()));
        }

        protected async override Task<GetCertificateDemandTemplatesForAcademyResponseBuilder> GetCertificateDemandTemplatesForAcademyInternalAsync(string academyacademy)
        {
            var certificates = await _certificateService.GetCertificatesTemplatesByAcademyAsync(academy);

            return Ok(certificates.Select(certificate => certificate.ToCertificateDemandDto()));
        }

        protected async override Task<GetCertificateDemandTemplatesResponseBuilder> GetCertificateDemandTemplatesInternalAsync()
        {
            var certificates = await _certificateService.GetCertificatesAsync();

            return Ok(certificates.Select(certificate => certificate.ToCertificateDemandDto()));
        }

        protected async override Task<SendMailForCertificateDemandResponseBuilder> SendMailForCertificateDemandInternalAsync(ConventionsHandicapCertificateDemandSendMailRequest requestBody)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var certificateDemandOwnerId = await _conventionsHandicapCertificateDemandService.GetCertificateDemandOwnerIdAsync(currentUser, sendMailRequest.CertificateDemandId.Value);

            var certificateOwner = await _userManager.FindByIdAsync($"{certificateDemandOwnerId}");

            await _conventionsHandicapCertificateDemandMailService.SendEmailToCertificateDemandOwnerAsync(currentUser, certificateOwner.Email, sendMailRequest);

            return Accepted();
        }

        protected async override Task<UpdateCertificateDemandResponseBuilder> UpdateCertificateDemandInternalAsync(UpdateCertificateDemandDto requestBody)
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

    }

}
