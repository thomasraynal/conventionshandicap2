
using Anabasis.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ConventionsHandicap.Model;

using ConventionsHandicap.EntityFramework;

namespace ConventionsHandicap
{

public abstract partial class ConventionsHandicapApiControllerBase:ControllerBase
{






/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="401"></response>


[Route("/v1/referential/academies", Name = "GetAcademies")]
[HttpGet]
[SwaggerResponse(200,type: typeof( Academy[]),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/referential/academies")]
[SwaggerOperation("GetAcademies")]

public async Task<IActionResult>
    GetAcademiesAsync(

    )


    {
    var responseBuilder = await GetAcademiesInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetAcademiesResponseBuilder>
        GetAcademiesInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class GetAcademiesResponseBuilder : ResponseBuilder<GetAcademiesResponseBuilder>
            {
            [JsonConstructor]
            private GetAcademiesResponseBuilder() { }

            

     
            

             public static GetAcademiesResponseBuilder Build200
            (
 Academy
[]
 content
)

            {
            return new GetAcademiesResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetAcademiesResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetAcademiesResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="academyName">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/referential/academies/{academyName}", Name = "GetAcademy")]
[HttpGet]
[SwaggerResponse(200,type: typeof(Academy),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/referential/academies/{academyName}")]
[SwaggerOperation("GetAcademy")]

public async Task<IActionResult>
    GetAcademyAsync(
      string
  academyName 
    
    
    
    
    )


    {
    var responseBuilder = await GetAcademyInternalAsync(academyName);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetAcademyResponseBuilder>
        GetAcademyInternalAsync( string
  academyName )
        {
        throw new NotImplementedException();
        }

        public partial class GetAcademyResponseBuilder : ResponseBuilder<GetAcademyResponseBuilder>
            {
            [JsonConstructor]
            private GetAcademyResponseBuilder() { }

            

     
            

             public static GetAcademyResponseBuilder Build200
            (
Academy
 content
)

            {
            return new GetAcademyResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetAcademyResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetAcademyResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static GetAcademyResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new GetAcademyResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="workspaceId">
///
///</param>
/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands", Name = "GetCertificateDemands")]
[HttpGet]
[SwaggerResponse(200,type: typeof( CertificateDemandDto[]),Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands")]
[SwaggerOperation("GetCertificateDemands")]

public async Task<IActionResult>
    GetCertificateDemandsAsync(
    
    
    
     Guid
  workspaceId 
    
    )


    {
    var responseBuilder = await GetCertificateDemandsInternalAsync(workspaceId);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetCertificateDemandsResponseBuilder>
        GetCertificateDemandsInternalAsync( Guid
  workspaceId )
        {
        throw new NotImplementedException();
        }

        public partial class GetCertificateDemandsResponseBuilder : ResponseBuilder<GetCertificateDemandsResponseBuilder>
            {
            [JsonConstructor]
            private GetCertificateDemandsResponseBuilder() { }

            

     
            

             public static GetCertificateDemandsResponseBuilder Build200
            (
 CertificateDemandDto
[]
 content
)

            {
            return new GetCertificateDemandsResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetCertificateDemandsResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new GetCertificateDemandsResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static GetCertificateDemandsResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetCertificateDemandsResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static GetCertificateDemandsResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new GetCertificateDemandsResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }














/// <summary>
    /// 
///</summary>

///
///<param name="CertificateDemandId">
///
///</param>
///
///<param name="WorkspaceId">
///
///</param>
/// <response code="204"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands", Name = "DeleteCertificateDemand")]
[HttpDelete]
[SwaggerResponse(204,Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands")]
[SwaggerOperation("DeleteCertificateDemand")]

public async Task<IActionResult>
    DeleteCertificateDemandAsync(
      Guid
  CertificateDemandId 
    
    
    
    ,       Guid
  WorkspaceId 
    
    
    
    
    )


    {
    var responseBuilder = await DeleteCertificateDemandInternalAsync(CertificateDemandId, WorkspaceId);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<DeleteCertificateDemandResponseBuilder>
        DeleteCertificateDemandInternalAsync( Guid
  CertificateDemandId,   Guid
  WorkspaceId )
        {
        throw new NotImplementedException();
        }

        public partial class DeleteCertificateDemandResponseBuilder : ResponseBuilder<DeleteCertificateDemandResponseBuilder>
            {
            [JsonConstructor]
            private DeleteCertificateDemandResponseBuilder() { }

            

     
            

             public static DeleteCertificateDemandResponseBuilder Build204
            (
)

            {
            return new DeleteCertificateDemandResponseBuilder()
      
            .WithStatusCode(204);
            } 

            

            
                
     
            

            

            

            public static DeleteCertificateDemandResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new DeleteCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static DeleteCertificateDemandResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new DeleteCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static DeleteCertificateDemandResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new DeleteCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }














/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands", Name = "CreateCertificateDemand")]
[HttpPut]
[SwaggerResponse(200,type: typeof(CertificateDemandDto),Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands")]
[SwaggerOperation("CreateCertificateDemand")]

public async Task<IActionResult>
    CreateCertificateDemandAsync(

    
    CreateCertificateDemandDto
 requestBody
    )


    {
    var responseBuilder = await CreateCertificateDemandInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<CreateCertificateDemandResponseBuilder>
        CreateCertificateDemandInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class CreateCertificateDemandResponseBuilder : ResponseBuilder<CreateCertificateDemandResponseBuilder>
            {
            [JsonConstructor]
            private CreateCertificateDemandResponseBuilder() { }

            

     
            

             public static CreateCertificateDemandResponseBuilder Build200
            (
CertificateDemandDto
 content
)

            {
            return new CreateCertificateDemandResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static CreateCertificateDemandResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new CreateCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static CreateCertificateDemandResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new CreateCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static CreateCertificateDemandResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new CreateCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }














/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands", Name = "UpdateCertificateDemand")]
[HttpPatch]
[SwaggerResponse(200,type: typeof(CertificateDemandDto),Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands")]
[SwaggerOperation("UpdateCertificateDemand")]

public async Task<IActionResult>
    UpdateCertificateDemandAsync(

    
    UpdateCertificateDemandDto
 requestBody
    )


    {
    var responseBuilder = await UpdateCertificateDemandInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<UpdateCertificateDemandResponseBuilder>
        UpdateCertificateDemandInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class UpdateCertificateDemandResponseBuilder : ResponseBuilder<UpdateCertificateDemandResponseBuilder>
            {
            [JsonConstructor]
            private UpdateCertificateDemandResponseBuilder() { }

            

     
            

             public static UpdateCertificateDemandResponseBuilder Build200
            (
CertificateDemandDto
 content
)

            {
            return new UpdateCertificateDemandResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static UpdateCertificateDemandResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new UpdateCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static UpdateCertificateDemandResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new UpdateCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static UpdateCertificateDemandResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new UpdateCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="certificateDemandId">
///
///</param>
///
///<param name="workspaceId">
///
///</param>
/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands/{certificateDemandId}", Name = "GetCertificateDemand")]
[HttpGet]
[SwaggerResponse(200,type: typeof(CertificateDemandDto),Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands/{certificateDemandId}")]
[SwaggerOperation("GetCertificateDemand")]

public async Task<IActionResult>
    GetCertificateDemandAsync(
      Guid
  certificateDemandId 
    
    
    
    ,     
    
    
     Guid
  workspaceId 
    
    )


    {
    var responseBuilder = await GetCertificateDemandInternalAsync(certificateDemandId, workspaceId);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetCertificateDemandResponseBuilder>
        GetCertificateDemandInternalAsync( Guid
  certificateDemandId,   Guid
  workspaceId )
        {
        throw new NotImplementedException();
        }

        public partial class GetCertificateDemandResponseBuilder : ResponseBuilder<GetCertificateDemandResponseBuilder>
            {
            [JsonConstructor]
            private GetCertificateDemandResponseBuilder() { }

            

     
            

             public static GetCertificateDemandResponseBuilder Build200
            (
CertificateDemandDto
 content
)

            {
            return new GetCertificateDemandResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetCertificateDemandResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new GetCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static GetCertificateDemandResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static GetCertificateDemandResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new GetCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="certificateDemandId">
///
///</param>
///
///<param name="metadataCode">
///
///</param>
///
///<param name="workspaceId">
///
///</param>
/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands/{certificateDemandId}/file/{metadataCode}", Name = "AddFileToCertificateDemand")]
[HttpPost]
[SwaggerResponse(200,type: typeof(CertificateDemandDto),Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands/{certificateDemandId}/file/{metadataCode}")]
[SwaggerOperation("AddFileToCertificateDemand")]

public async Task<IActionResult>
    AddFileToCertificateDemandAsync(
      Guid
  certificateDemandId 
    
    
    
    ,       string
  metadataCode 
    
    
    
    ,     
    
    
     Guid
  workspaceId 
    
    ,
    IFormFile
 requestBody
    )


    {
    var responseBuilder = await AddFileToCertificateDemandInternalAsync(certificateDemandId, metadataCode, workspaceId);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<AddFileToCertificateDemandResponseBuilder>
        AddFileToCertificateDemandInternalAsync( Guid
  certificateDemandId,   string
  metadataCode,   Guid
  workspaceId )
        {
        throw new NotImplementedException();
        }

        public partial class AddFileToCertificateDemandResponseBuilder : ResponseBuilder<AddFileToCertificateDemandResponseBuilder>
            {
            [JsonConstructor]
            private AddFileToCertificateDemandResponseBuilder() { }

            

     
            

             public static AddFileToCertificateDemandResponseBuilder Build200
            (
CertificateDemandDto
 content
)

            {
            return new AddFileToCertificateDemandResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static AddFileToCertificateDemandResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new AddFileToCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static AddFileToCertificateDemandResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new AddFileToCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static AddFileToCertificateDemandResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new AddFileToCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

/// <response code="202"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands/mail", Name = "SendMailForCertificateDemand")]
[HttpPost]
[SwaggerResponse(202,Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands/mail")]
[SwaggerOperation("SendMailForCertificateDemand")]

public async Task<IActionResult>
    SendMailForCertificateDemandAsync(

    
    ConventionsHandicapCertificateDemandSendMailRequest
 requestBody
    )


    {
    var responseBuilder = await SendMailForCertificateDemandInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<SendMailForCertificateDemandResponseBuilder>
        SendMailForCertificateDemandInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class SendMailForCertificateDemandResponseBuilder : ResponseBuilder<SendMailForCertificateDemandResponseBuilder>
            {
            [JsonConstructor]
            private SendMailForCertificateDemandResponseBuilder() { }

            

     
            

             public static SendMailForCertificateDemandResponseBuilder Build202
            (
)

            {
            return new SendMailForCertificateDemandResponseBuilder()
      
            .WithStatusCode(202);
            } 

            

            
                
     
            

            

            

            public static SendMailForCertificateDemandResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new SendMailForCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static SendMailForCertificateDemandResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new SendMailForCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static SendMailForCertificateDemandResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new SendMailForCertificateDemandResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="401"></response>


[Route("/v1/features/certificates/demands/medatada", Name = "GetAllCertificateDemandMetadata")]
[HttpGet]
[SwaggerResponse(200,type: typeof( ConventionsHandicapCertificateMetadata[]),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands/medatada")]
[SwaggerOperation("GetAllCertificateDemandMetadata")]

public async Task<IActionResult>
    GetAllCertificateDemandMetadataAsync(

    )


    {
    var responseBuilder = await GetAllCertificateDemandMetadataInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetAllCertificateDemandMetadataResponseBuilder>
        GetAllCertificateDemandMetadataInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class GetAllCertificateDemandMetadataResponseBuilder : ResponseBuilder<GetAllCertificateDemandMetadataResponseBuilder>
            {
            [JsonConstructor]
            private GetAllCertificateDemandMetadataResponseBuilder() { }

            

     
            

             public static GetAllCertificateDemandMetadataResponseBuilder Build200
            (
 ConventionsHandicapCertificateMetadata
[]
 content
)

            {
            return new GetAllCertificateDemandMetadataResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetAllCertificateDemandMetadataResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetAllCertificateDemandMetadataResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="academyId">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands/medatada/{academyId}", Name = "GetCertificateDemandMetadataForAcademy")]
[HttpGet]
[SwaggerResponse(200,type: typeof( ConventionsHandicapCertificateMetadata[]),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands/medatada/{academyId}")]
[SwaggerOperation("GetCertificateDemandMetadataForAcademy")]

public async Task<IActionResult>
    GetCertificateDemandMetadataForAcademyAsync(
      string
  academyId 
    
    
    
    
    )


    {
    var responseBuilder = await GetCertificateDemandMetadataForAcademyInternalAsync(academyId);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetCertificateDemandMetadataForAcademyResponseBuilder>
        GetCertificateDemandMetadataForAcademyInternalAsync( string
  academyId )
        {
        throw new NotImplementedException();
        }

        public partial class GetCertificateDemandMetadataForAcademyResponseBuilder : ResponseBuilder<GetCertificateDemandMetadataForAcademyResponseBuilder>
            {
            [JsonConstructor]
            private GetCertificateDemandMetadataForAcademyResponseBuilder() { }

            

     
            

             public static GetCertificateDemandMetadataForAcademyResponseBuilder Build200
            (
 ConventionsHandicapCertificateMetadata
[]
 content
)

            {
            return new GetCertificateDemandMetadataForAcademyResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetCertificateDemandMetadataForAcademyResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetCertificateDemandMetadataForAcademyResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static GetCertificateDemandMetadataForAcademyResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new GetCertificateDemandMetadataForAcademyResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="academyId">
///
///</param>
///
///<param name="departmentId">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands/medatada/{academyId}/{departmentId}", Name = "GetCertificateDemandMetadataForAcademyAndDepartment")]
[HttpGet]
[SwaggerResponse(200,type: typeof( ConventionsHandicapCertificateMetadata[]),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands/medatada/{academyId}/{departmentId}")]
[SwaggerOperation("GetCertificateDemandMetadataForAcademyAndDepartment")]

public async Task<IActionResult>
    GetCertificateDemandMetadataForAcademyAndDepartmentAsync(
      string
  academyId 
    
    
    
    ,       string
  departmentId 
    
    
    
    
    )


    {
    var responseBuilder = await GetCertificateDemandMetadataForAcademyAndDepartmentInternalAsync(academyId, departmentId);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetCertificateDemandMetadataForAcademyAndDepartmentResponseBuilder>
        GetCertificateDemandMetadataForAcademyAndDepartmentInternalAsync( string
  academyId,   string
  departmentId )
        {
        throw new NotImplementedException();
        }

        public partial class GetCertificateDemandMetadataForAcademyAndDepartmentResponseBuilder : ResponseBuilder<GetCertificateDemandMetadataForAcademyAndDepartmentResponseBuilder>
            {
            [JsonConstructor]
            private GetCertificateDemandMetadataForAcademyAndDepartmentResponseBuilder() { }

            

     
            

             public static GetCertificateDemandMetadataForAcademyAndDepartmentResponseBuilder Build200
            (
 ConventionsHandicapCertificateMetadata
[]
 content
)

            {
            return new GetCertificateDemandMetadataForAcademyAndDepartmentResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetCertificateDemandMetadataForAcademyAndDepartmentResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetCertificateDemandMetadataForAcademyAndDepartmentResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static GetCertificateDemandMetadataForAcademyAndDepartmentResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new GetCertificateDemandMetadataForAcademyAndDepartmentResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="certificateDemandId">
///
///</param>
///
///<param name="certificateTemplateId">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands/template/generate/{certificateDemandId}/{certificateTemplateId}", Name = "GetCertificateDemandTemplate")]
[HttpGet]
[SwaggerResponse(200,type: typeof(string),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands/template/generate/{certificateDemandId}/{certificateTemplateId}")]
[SwaggerOperation("GetCertificateDemandTemplate")]

public async Task<IActionResult>
    GetCertificateDemandTemplateAsync(
      Guid
  certificateDemandId 
    
    
    
    ,       Guid
  certificateTemplateId 
    
    
    
    
    )


    {
    var responseBuilder = await GetCertificateDemandTemplateInternalAsync(certificateDemandId, certificateTemplateId);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetCertificateDemandTemplateResponseBuilder>
        GetCertificateDemandTemplateInternalAsync( Guid
  certificateDemandId,   Guid
  certificateTemplateId )
        {
        throw new NotImplementedException();
        }

        public partial class GetCertificateDemandTemplateResponseBuilder : ResponseBuilder<GetCertificateDemandTemplateResponseBuilder>
            {
            [JsonConstructor]
            private GetCertificateDemandTemplateResponseBuilder() { }

            

     
            

             public static GetCertificateDemandTemplateResponseBuilder Build200
            (
string
 content
)

            {
            return new GetCertificateDemandTemplateResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetCertificateDemandTemplateResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetCertificateDemandTemplateResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static GetCertificateDemandTemplateResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new GetCertificateDemandTemplateResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands/template", Name = "GetCertificateDemandTemplates")]
[HttpGet]
[SwaggerResponse(200,type: typeof(CertificateTemplateDto),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands/template")]
[SwaggerOperation("GetCertificateDemandTemplates")]

public async Task<IActionResult>
    GetCertificateDemandTemplatesAsync(

    )


    {
    var responseBuilder = await GetCertificateDemandTemplatesInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetCertificateDemandTemplatesResponseBuilder>
        GetCertificateDemandTemplatesInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class GetCertificateDemandTemplatesResponseBuilder : ResponseBuilder<GetCertificateDemandTemplatesResponseBuilder>
            {
            [JsonConstructor]
            private GetCertificateDemandTemplatesResponseBuilder() { }

            

     
            

             public static GetCertificateDemandTemplatesResponseBuilder Build200
            (
CertificateTemplateDto
 content
)

            {
            return new GetCertificateDemandTemplatesResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetCertificateDemandTemplatesResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetCertificateDemandTemplatesResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static GetCertificateDemandTemplatesResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new GetCertificateDemandTemplatesResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="academy">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands/template/{academy}", Name = "GetCertificateDemandTemplatesForAcademy")]
[HttpGet]
[SwaggerResponse(200,type: typeof( CertificateTemplateDto[]),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands/template/{academy}")]
[SwaggerOperation("GetCertificateDemandTemplatesForAcademy")]

public async Task<IActionResult>
    GetCertificateDemandTemplatesForAcademyAsync(
      string
  academy 
    
    
    
    
    )


    {
    var responseBuilder = await GetCertificateDemandTemplatesForAcademyInternalAsync(academy);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetCertificateDemandTemplatesForAcademyResponseBuilder>
        GetCertificateDemandTemplatesForAcademyInternalAsync( string
  academy )
        {
        throw new NotImplementedException();
        }

        public partial class GetCertificateDemandTemplatesForAcademyResponseBuilder : ResponseBuilder<GetCertificateDemandTemplatesForAcademyResponseBuilder>
            {
            [JsonConstructor]
            private GetCertificateDemandTemplatesForAcademyResponseBuilder() { }

            

     
            

             public static GetCertificateDemandTemplatesForAcademyResponseBuilder Build200
            (
 CertificateTemplateDto
[]
 content
)

            {
            return new GetCertificateDemandTemplatesForAcademyResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetCertificateDemandTemplatesForAcademyResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetCertificateDemandTemplatesForAcademyResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static GetCertificateDemandTemplatesForAcademyResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new GetCertificateDemandTemplatesForAcademyResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="academy">
///
///</param>
///
///<param name="department">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/certificates/demands/template/{academy}/{department}", Name = "GetCertificateDemandTemplatesForAcademyAndDepartment")]
[HttpGet]
[SwaggerResponse(200,type: typeof( CertificateTemplateDto[]),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/certificates/demands/template/{academy}/{department}")]
[SwaggerOperation("GetCertificateDemandTemplatesForAcademyAndDepartment")]

public async Task<IActionResult>
    GetCertificateDemandTemplatesForAcademyAndDepartmentAsync(
      string
  academy 
    
    
    
    ,       string
  department 
    
    
    
    
    )


    {
    var responseBuilder = await GetCertificateDemandTemplatesForAcademyAndDepartmentInternalAsync(academy, department);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetCertificateDemandTemplatesForAcademyAndDepartmentResponseBuilder>
        GetCertificateDemandTemplatesForAcademyAndDepartmentInternalAsync( string
  academy,   string
  department )
        {
        throw new NotImplementedException();
        }

        public partial class GetCertificateDemandTemplatesForAcademyAndDepartmentResponseBuilder : ResponseBuilder<GetCertificateDemandTemplatesForAcademyAndDepartmentResponseBuilder>
            {
            [JsonConstructor]
            private GetCertificateDemandTemplatesForAcademyAndDepartmentResponseBuilder() { }

            

     
            

             public static GetCertificateDemandTemplatesForAcademyAndDepartmentResponseBuilder Build200
            (
 CertificateTemplateDto
[]
 content
)

            {
            return new GetCertificateDemandTemplatesForAcademyAndDepartmentResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetCertificateDemandTemplatesForAcademyAndDepartmentResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetCertificateDemandTemplatesForAcademyAndDepartmentResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static GetCertificateDemandTemplatesForAcademyAndDepartmentResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new GetCertificateDemandTemplatesForAcademyAndDepartmentResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="workspaceId">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>


[Route("/v1/features", Name = "GetFeatures")]
[HttpGet]
[SwaggerResponse(200,type: typeof( ConventionsHandicapFeature[]),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features")]
[SwaggerOperation("GetFeatures")]

public async Task<IActionResult>
    GetFeaturesAsync(
    
    
    
     Guid
  workspaceId 
    
    )


    {
    var responseBuilder = await GetFeaturesInternalAsync(workspaceId);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetFeaturesResponseBuilder>
        GetFeaturesInternalAsync( Guid
  workspaceId )
        {
        throw new NotImplementedException();
        }

        public partial class GetFeaturesResponseBuilder : ResponseBuilder<GetFeaturesResponseBuilder>
            {
            [JsonConstructor]
            private GetFeaturesResponseBuilder() { }

            

     
            

             public static GetFeaturesResponseBuilder Build200
            (
 ConventionsHandicapFeature
[]
 content
)

            {
            return new GetFeaturesResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetFeaturesResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetFeaturesResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="featureId">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/features/{featureId}", Name = "GetFeatureById")]
[HttpGet]
[SwaggerResponse(200,type: typeof(ConventionsHandicapFeature),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/features/{featureId}")]
[SwaggerOperation("GetFeatureById")]

public async Task<IActionResult>
    GetFeatureByIdAsync(
      Guid
  featureId 
    
    
    
    
    )


    {
    var responseBuilder = await GetFeatureByIdInternalAsync(featureId);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetFeatureByIdResponseBuilder>
        GetFeatureByIdInternalAsync( Guid
  featureId )
        {
        throw new NotImplementedException();
        }

        public partial class GetFeatureByIdResponseBuilder : ResponseBuilder<GetFeatureByIdResponseBuilder>
            {
            [JsonConstructor]
            private GetFeatureByIdResponseBuilder() { }

            

     
            

             public static GetFeatureByIdResponseBuilder Build200
            (
ConventionsHandicapFeature
 content
)

            {
            return new GetFeatureByIdResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetFeatureByIdResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetFeatureByIdResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static GetFeatureByIdResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new GetFeatureByIdResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

/// <response code="202"></response>
/// <response code="400"></response>
/// <response code="401"></response>


[Route("/v1/mail", Name = "SendMail")]
[HttpPost]
[SwaggerResponse(202,Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/mail")]
[SwaggerOperation("SendMail")]

public async Task<IActionResult>
    SendMailAsync(

    
    ConventionsHandicapSendMailToConventionHandicapDto
 requestBody
    )


    {
    var responseBuilder = await SendMailInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<SendMailResponseBuilder>
        SendMailInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class SendMailResponseBuilder : ResponseBuilder<SendMailResponseBuilder>
            {
            [JsonConstructor]
            private SendMailResponseBuilder() { }

            

     
            

             public static SendMailResponseBuilder Build202
            (
)

            {
            return new SendMailResponseBuilder()
      
            .WithStatusCode(202);
            } 

            

            
                
     
            

            

            

            public static SendMailResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new SendMailResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static SendMailResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new SendMailResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
                    }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="401"></response>


[Route("/v1/users", Name = "GetUsers")]
[HttpGet]
[SwaggerResponse(200,type: typeof( UserDto[]),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/users")]
[SwaggerOperation("GetUsers")]

public async Task<IActionResult>
    GetUsersAsync(

    )


    {
    var responseBuilder = await GetUsersInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetUsersResponseBuilder>
        GetUsersInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class GetUsersResponseBuilder : ResponseBuilder<GetUsersResponseBuilder>
            {
            [JsonConstructor]
            private GetUsersResponseBuilder() { }

            

     
            

             public static GetUsersResponseBuilder Build200
            (
 UserDto
[]
 content
)

            {
            return new GetUsersResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetUsersResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetUsersResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
                    }














/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/users", Name = "UpdateUser")]
[HttpPatch]
[SwaggerResponse(200,type: typeof(UserDto),Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/users")]
[SwaggerOperation("UpdateUser")]

public async Task<IActionResult>
    UpdateUserAsync(

    
    UpdateUserRequest
 requestBody
    )


    {
    var responseBuilder = await UpdateUserInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<UpdateUserResponseBuilder>
        UpdateUserInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class UpdateUserResponseBuilder : ResponseBuilder<UpdateUserResponseBuilder>
            {
            [JsonConstructor]
            private UpdateUserResponseBuilder() { }

            

     
            

             public static UpdateUserResponseBuilder Build200
            (
UserDto
 content
)

            {
            return new UpdateUserResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static UpdateUserResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new UpdateUserResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static UpdateUserResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new UpdateUserResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static UpdateUserResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new UpdateUserResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }














/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>


[Route("/v1/users", Name = "CreateUser")]
[HttpPut]
[SwaggerResponse(200,type: typeof(UserDto),Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/users")]
[SwaggerOperation("CreateUser")]

public async Task<IActionResult>
    CreateUserAsync(

    
    CreateUserRequest
 requestBody
    )


    {
    var responseBuilder = await CreateUserInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<CreateUserResponseBuilder>
        CreateUserInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class CreateUserResponseBuilder : ResponseBuilder<CreateUserResponseBuilder>
            {
            [JsonConstructor]
            private CreateUserResponseBuilder() { }

            

     
            

             public static CreateUserResponseBuilder Build200
            (
UserDto
 content
)

            {
            return new CreateUserResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static CreateUserResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new CreateUserResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static CreateUserResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new CreateUserResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
                    }














/// <summary>
    /// 
///</summary>

/// <response code="204"></response>
/// <response code="400"></response>
/// <response code="401"></response>


[Route("/v1/users", Name = "DeleteUser")]
[HttpDelete]
[SwaggerResponse(204,Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/users")]
[SwaggerOperation("DeleteUser")]

public async Task<IActionResult>
    DeleteUserAsync(

    
    DeleteUserRequest
 requestBody
    )


    {
    var responseBuilder = await DeleteUserInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<DeleteUserResponseBuilder>
        DeleteUserInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class DeleteUserResponseBuilder : ResponseBuilder<DeleteUserResponseBuilder>
            {
            [JsonConstructor]
            private DeleteUserResponseBuilder() { }

            

     
            

             public static DeleteUserResponseBuilder Build204
            (
)

            {
            return new DeleteUserResponseBuilder()
      
            .WithStatusCode(204);
            } 

            

            
                
     
            

            

            

            public static DeleteUserResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new DeleteUserResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static DeleteUserResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new DeleteUserResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
                    }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/users/current", Name = "GetCurrentUser")]
[HttpGet]
[SwaggerResponse(200,type: typeof(UserDto),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/users/current")]
[SwaggerOperation("GetCurrentUser")]

public async Task<IActionResult>
    GetCurrentUserAsync(

    )


    {
    var responseBuilder = await GetCurrentUserInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetCurrentUserResponseBuilder>
        GetCurrentUserInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class GetCurrentUserResponseBuilder : ResponseBuilder<GetCurrentUserResponseBuilder>
            {
            [JsonConstructor]
            private GetCurrentUserResponseBuilder() { }

            

     
            

             public static GetCurrentUserResponseBuilder Build200
            (
UserDto
 content
)

            {
            return new GetCurrentUserResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetCurrentUserResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetCurrentUserResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static GetCurrentUserResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new GetCurrentUserResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>


[Route("/v1/login", Name = "Login")]
[HttpPost]
[SwaggerResponse(200,Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/login")]
[SwaggerOperation("Login")]

public async Task<IActionResult>
    LoginAsync(

    
    ConventionsHandicapLoginDto
 requestBody
    )


    {
    var responseBuilder = await LoginInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<LoginResponseBuilder>
        LoginInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class LoginResponseBuilder : ResponseBuilder<LoginResponseBuilder>
            {
            [JsonConstructor]
            private LoginResponseBuilder() { }

            

     
            

             public static LoginResponseBuilder Build200
            (
)

            {
            return new LoginResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static LoginResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new LoginResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
                    }















/// <summary>
    /// 
///</summary>

/// <response code="201"></response>
/// <response code="400"></response>


[Route("/v1/register", Name = "Register")]
[HttpPost]
[SwaggerResponse(201,Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/register")]
[SwaggerOperation("Register")]

public async Task<IActionResult>
    RegisterAsync(

    
    RegistrationDto
 requestBody
    )


    {
    var responseBuilder = await RegisterInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<RegisterResponseBuilder>
        RegisterInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class RegisterResponseBuilder : ResponseBuilder<RegisterResponseBuilder>
            {
            [JsonConstructor]
            private RegisterResponseBuilder() { }

            

     
            

             public static RegisterResponseBuilder Build201
            (
)

            {
            return new RegisterResponseBuilder()
      
            .WithStatusCode(201);
            } 

            

            
                
     
            

            

            

            public static RegisterResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new RegisterResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="Email">
///
///</param>
///
///<param name="Token">
///
///</param>
/// <response code="200"></response>
/// <response code="400"></response>


[Route("/v1/confirm", Name = "ConfirmMail")]
[HttpGet]
[SwaggerResponse(200,Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/confirm")]
[SwaggerOperation("ConfirmMail")]

public async Task<IActionResult>
    ConfirmMailAsync(
    
    
    
     string
  Email 
    ,     
    
    
     string
  Token 
    
    )


    {
    var responseBuilder = await ConfirmMailInternalAsync(Email, Token);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<ConfirmMailResponseBuilder>
        ConfirmMailInternalAsync( string
  Email,   string
  Token )
        {
        throw new NotImplementedException();
        }

        public partial class ConfirmMailResponseBuilder : ResponseBuilder<ConfirmMailResponseBuilder>
            {
            [JsonConstructor]
            private ConfirmMailResponseBuilder() { }

            

     
            

             public static ConfirmMailResponseBuilder Build200
            (
)

            {
            return new ConfirmMailResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static ConfirmMailResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new ConfirmMailResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
                    }















/// <summary>
    /// 
///</summary>

/// <response code="204"></response>
/// <response code="400"></response>


[Route("/v1/forgot", Name = "ForgotPassword")]
[HttpPost]
[SwaggerResponse(204,Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/forgot")]
[SwaggerOperation("ForgotPassword")]

public async Task<IActionResult>
    ForgotPasswordAsync(

    
    ForgotPasswordDto
 requestBody
    )


    {
    var responseBuilder = await ForgotPasswordInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<ForgotPasswordResponseBuilder>
        ForgotPasswordInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class ForgotPasswordResponseBuilder : ResponseBuilder<ForgotPasswordResponseBuilder>
            {
            [JsonConstructor]
            private ForgotPasswordResponseBuilder() { }

            

     
            

             public static ForgotPasswordResponseBuilder Build204
            (
)

            {
            return new ForgotPasswordResponseBuilder()
      
            .WithStatusCode(204);
            } 

            

            
                
     
            

            

            

            public static ForgotPasswordResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new ForgotPasswordResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
                    }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>


[Route("/v1/reset", Name = "ResetPassword")]
[HttpPost]
[SwaggerResponse(200,Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/reset")]
[SwaggerOperation("ResetPassword")]

public async Task<IActionResult>
    ResetPasswordAsync(

    
    ResetPasswordDto
 requestBody
    )


    {
    var responseBuilder = await ResetPasswordInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<ResetPasswordResponseBuilder>
        ResetPasswordInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class ResetPasswordResponseBuilder : ResponseBuilder<ResetPasswordResponseBuilder>
            {
            [JsonConstructor]
            private ResetPasswordResponseBuilder() { }

            

     
            

             public static ResetPasswordResponseBuilder Build200
            (
)

            {
            return new ResetPasswordResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static ResetPasswordResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new ResetPasswordResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
                    }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="401"></response>


[Route("/v1/workspaces", Name = "GetWorkspaces")]
[HttpGet]
[SwaggerResponse(200,type: typeof( ConventionsHandicapWorkspace[]),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/workspaces")]
[SwaggerOperation("GetWorkspaces")]

public async Task<IActionResult>
    GetWorkspacesAsync(

    )


    {
    var responseBuilder = await GetWorkspacesInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetWorkspacesResponseBuilder>
        GetWorkspacesInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class GetWorkspacesResponseBuilder : ResponseBuilder<GetWorkspacesResponseBuilder>
            {
            [JsonConstructor]
            private GetWorkspacesResponseBuilder() { }

            

     
            

             public static GetWorkspacesResponseBuilder Build200
            (
 ConventionsHandicapWorkspace
[]
 content
)

            {
            return new GetWorkspacesResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetWorkspacesResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetWorkspacesResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
                    }














/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>


[Route("/v1/workspaces", Name = "PutWorkspace")]
[HttpPut]
[SwaggerResponse(200,type: typeof(ConventionsHandicapWorkspace),Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/workspaces")]
[SwaggerOperation("PutWorkspace")]

public async Task<IActionResult>
    PutWorkspaceAsync(

    
    CreateWorkspaceDto
 requestBody
    )


    {
    var responseBuilder = await PutWorkspaceInternalAsync();

    return responseBuilder.BuildResult();

    }

    protected virtual Task<PutWorkspaceResponseBuilder>
        PutWorkspaceInternalAsync()
        {
        throw new NotImplementedException();
        }

        public partial class PutWorkspaceResponseBuilder : ResponseBuilder<PutWorkspaceResponseBuilder>
            {
            [JsonConstructor]
            private PutWorkspaceResponseBuilder() { }

            

     
            

             public static PutWorkspaceResponseBuilder Build200
            (
ConventionsHandicapWorkspace
 content
)

            {
            return new PutWorkspaceResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static PutWorkspaceResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new PutWorkspaceResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static PutWorkspaceResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new PutWorkspaceResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
                    }















/// <summary>
    /// 
///</summary>

///
///<param name="workspaceId">
///
///</param>
/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/workspaces/{workspaceId}", Name = "UpdateWorkspace")]
[HttpPatch]
[SwaggerResponse(200,type: typeof(ConventionsHandicapWorkspace),Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/workspaces/{workspaceId}")]
[SwaggerOperation("UpdateWorkspace")]

public async Task<IActionResult>
    UpdateWorkspaceAsync(
      Guid
  workspaceId 
    
    
    
    
    ,
    UpdateWorkspaceDto
 requestBody
    )


    {
    var responseBuilder = await UpdateWorkspaceInternalAsync(workspaceId);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<UpdateWorkspaceResponseBuilder>
        UpdateWorkspaceInternalAsync( Guid
  workspaceId )
        {
        throw new NotImplementedException();
        }

        public partial class UpdateWorkspaceResponseBuilder : ResponseBuilder<UpdateWorkspaceResponseBuilder>
            {
            [JsonConstructor]
            private UpdateWorkspaceResponseBuilder() { }

            

     
            

             public static UpdateWorkspaceResponseBuilder Build200
            (
ConventionsHandicapWorkspace
 content
)

            {
            return new UpdateWorkspaceResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static UpdateWorkspaceResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new UpdateWorkspaceResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static UpdateWorkspaceResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new UpdateWorkspaceResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static UpdateWorkspaceResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new UpdateWorkspaceResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }














/// <summary>
    /// 
///</summary>

///
///<param name="workspaceId">
///
///</param>
/// <response code="204"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/workspaces/{workspaceId}", Name = "DeleteWorkspace")]
[HttpDelete]
[SwaggerResponse(204,Description = "")]
[SwaggerResponse(400,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/workspaces/{workspaceId}")]
[SwaggerOperation("DeleteWorkspace")]

public async Task<IActionResult>
    DeleteWorkspaceAsync(
      Guid
  workspaceId 
    
    
    
    
    )


    {
    var responseBuilder = await DeleteWorkspaceInternalAsync(workspaceId);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<DeleteWorkspaceResponseBuilder>
        DeleteWorkspaceInternalAsync( Guid
  workspaceId )
        {
        throw new NotImplementedException();
        }

        public partial class DeleteWorkspaceResponseBuilder : ResponseBuilder<DeleteWorkspaceResponseBuilder>
            {
            [JsonConstructor]
            private DeleteWorkspaceResponseBuilder() { }

            

     
            

             public static DeleteWorkspaceResponseBuilder Build204
            (
)

            {
            return new DeleteWorkspaceResponseBuilder()
      
            .WithStatusCode(204);
            } 

            

            
                
     
            

            

            

            public static DeleteWorkspaceResponseBuilder Build400(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });

                return new DeleteWorkspaceResponseBuilder()
                .WithContent(content)
                .WithStatusCode(400);
                }

                
     
            

            

            

            public static DeleteWorkspaceResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new DeleteWorkspaceResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static DeleteWorkspaceResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new DeleteWorkspaceResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }














/// <summary>
    /// 
///</summary>

///
///<param name="workspaceId">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>


[Route("/v1/workspaces/{workspaceId}", Name = "GetWorkspace")]
[HttpGet]
[SwaggerResponse(200,type: typeof(ConventionsHandicapWorkspace),Description = "")]
[SwaggerResponse(401,type: typeof(ErrorResponseMessage),Description = "")]
[SwaggerResponse(404,type: typeof(ErrorResponseMessage),Description = "")]
[ApiExplorerSettings(GroupName = "/v1/workspaces/{workspaceId}")]
[SwaggerOperation("GetWorkspace")]

public async Task<IActionResult>
    GetWorkspaceAsync(
      Guid
  workspaceId 
    
    
    
    
    )


    {
    var responseBuilder = await GetWorkspaceInternalAsync(workspaceId);

    return responseBuilder.BuildResult();

    }

    protected virtual Task<GetWorkspaceResponseBuilder>
        GetWorkspaceInternalAsync( Guid
  workspaceId )
        {
        throw new NotImplementedException();
        }

        public partial class GetWorkspaceResponseBuilder : ResponseBuilder<GetWorkspaceResponseBuilder>
            {
            [JsonConstructor]
            private GetWorkspaceResponseBuilder() { }

            

     
            

             public static GetWorkspaceResponseBuilder Build200
            (
ConventionsHandicapWorkspace
 content
)

            {
            return new GetWorkspaceResponseBuilder()
      
            .WithStatusCode(200);
            } 

            

            
                
     
            

            

            

            public static GetWorkspaceResponseBuilder Build401(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });

                return new GetWorkspaceResponseBuilder()
                .WithContent(content)
                .WithStatusCode(401);
                }

                
     
            

            

            

            public static GetWorkspaceResponseBuilder Build404(string errorMessage = "", Dictionary<string,object>
                arguments=null)
                {

                var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });

                return new GetWorkspaceResponseBuilder()
                .WithContent(content)
                .WithStatusCode(404);
                }

                
                    }











                    }
                    }

