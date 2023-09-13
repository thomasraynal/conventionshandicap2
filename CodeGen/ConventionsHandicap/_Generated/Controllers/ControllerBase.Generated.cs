
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


namespace 
{

public abstract partial class ControllerBase:ControllerBase
{






/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="401"></response>
[Route("/v1/referential/academies", Name = "")]
[HttpGet]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="academyName">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/referential/academies/{academyName}", Name = "")]
[HttpGet]
public async Task<IActionResult>Async(academyName)

    {
     var responseBuilder = await InternalAsync(academyName);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( academyName )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="workspaceId">
///
///</param>
/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands", Name = "")]
[HttpGet]
public async Task<IActionResult>Async(workspaceId)

    {
     var responseBuilder = await InternalAsync(workspaceId);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( workspaceId )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }














/// <summary>
    /// 
///</summary>

///<param name="CertificateDemandId">
///
///</param>
///<param name="WorkspaceId">
///
///</param>
/// <response code="204"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands", Name = "")]
[HttpDelete]
public async Task<IActionResult>Async(CertificateDemandId,WorkspaceId)

    {
     var responseBuilder = await InternalAsync(CertificateDemandId, WorkspaceId);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( CertificateDemandId,   WorkspaceId )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build204(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)204, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("204" == "default" ? 500 : 204);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }














/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands", Name = "")]
[HttpPut]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }














/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands", Name = "")]
[HttpPatch]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="certificateDemandId">
///
///</param>
///<param name="workspaceId">
///
///</param>
/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands/{certificateDemandId}", Name = "")]
[HttpGet]
public async Task<IActionResult>Async(certificateDemandId,workspaceId)

    {
     var responseBuilder = await InternalAsync(certificateDemandId, workspaceId);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( certificateDemandId,   workspaceId )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="certificateDemandId">
///
///</param>
///<param name="metadataCode">
///
///</param>
///<param name="workspaceId">
///
///</param>
/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands/{certificateDemandId}/file/{metadataCode}", Name = "")]
[HttpPost]
public async Task<IActionResult>Async(certificateDemandId,metadataCode,workspaceId)

    {
     var responseBuilder = await InternalAsync(certificateDemandId, metadataCode, workspaceId);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( certificateDemandId,   metadataCode,   workspaceId )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

/// <response code="202"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands/mail", Name = "")]
[HttpPost]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build202(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)202, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("202" == "default" ? 500 : 202);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="401"></response>
[Route("/v1/features/certificates/demands/medatada", Name = "")]
[HttpGet]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="academyId">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands/medatada/{academyId}", Name = "")]
[HttpGet]
public async Task<IActionResult>Async(academyId)

    {
     var responseBuilder = await InternalAsync(academyId);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( academyId )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="academyId">
///
///</param>
///<param name="departmentId">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands/medatada/{academyId}/{departmentId}", Name = "")]
[HttpGet]
public async Task<IActionResult>Async(academyId,departmentId)

    {
     var responseBuilder = await InternalAsync(academyId, departmentId);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( academyId,   departmentId )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="certificateDemandId">
///
///</param>
///<param name="certificateTemplateId">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands/template/generate/{certificateDemandId}/{certificateTemplateId}", Name = "")]
[HttpGet]
public async Task<IActionResult>Async(certificateDemandId,certificateTemplateId)

    {
     var responseBuilder = await InternalAsync(certificateDemandId, certificateTemplateId);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( certificateDemandId,   certificateTemplateId )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands/template", Name = "")]
[HttpGet]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="academy">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands/template/{academy}", Name = "")]
[HttpGet]
public async Task<IActionResult>Async(academy)

    {
     var responseBuilder = await InternalAsync(academy);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( academy )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="academy">
///
///</param>
///<param name="department">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/certificates/demands/template/{academy}/{department}", Name = "")]
[HttpGet]
public async Task<IActionResult>Async(academy,department)

    {
     var responseBuilder = await InternalAsync(academy, department);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( academy,   department )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="workspaceId">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
[Route("/v1/features", Name = "")]
[HttpGet]
public async Task<IActionResult>Async(workspaceId)

    {
     var responseBuilder = await InternalAsync(workspaceId);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( workspaceId )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="featureId">
///
///</param>
/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/features/{featureId}", Name = "")]
[HttpGet]
public async Task<IActionResult>Async(featureId)

    {
     var responseBuilder = await InternalAsync(featureId);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( featureId )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

/// <response code="202"></response>
/// <response code="400"></response>
/// <response code="401"></response>
[Route("/v1/mail", Name = "")]
[HttpPost]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build202(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)202, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("202" == "default" ? 500 : 202);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
        }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="401"></response>
[Route("/v1/users", Name = "")]
[HttpGet]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
        }














/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/users", Name = "")]
[HttpPatch]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }














/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
[Route("/v1/users", Name = "")]
[HttpPut]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
        }














/// <summary>
    /// 
///</summary>

/// <response code="204"></response>
/// <response code="400"></response>
/// <response code="401"></response>
[Route("/v1/users", Name = "")]
[HttpDelete]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build204(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)204, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("204" == "default" ? 500 : 204);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
        }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/users/current", Name = "")]
[HttpGet]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>
[Route("/v1/login", Name = "")]
[HttpPost]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
        }















/// <summary>
    /// 
///</summary>

/// <response code="201"></response>
/// <response code="400"></response>
[Route("/v1/register", Name = "")]
[HttpPost]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build201(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)201, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("201" == "default" ? 500 : 201);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="Email">
///
///</param>
///<param name="Token">
///
///</param>
/// <response code="200"></response>
/// <response code="400"></response>
[Route("/v1/confirm", Name = "")]
[HttpGet]
public async Task<IActionResult>Async(Email,Token)

    {
     var responseBuilder = await InternalAsync(Email, Token);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( Email,   Token )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
        }















/// <summary>
    /// 
///</summary>

/// <response code="204"></response>
/// <response code="400"></response>
[Route("/v1/forgot", Name = "")]
[HttpPost]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build204(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)204, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("204" == "default" ? 500 : 204);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
        }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>
[Route("/v1/reset", Name = "")]
[HttpPost]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
        }















/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="401"></response>
[Route("/v1/workspaces", Name = "")]
[HttpGet]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
        }














/// <summary>
    /// 
///</summary>

/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
[Route("/v1/workspaces", Name = "")]
[HttpPut]
public async Task<IActionResult>Async()

    {
     var responseBuilder = await InternalAsync();

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync()
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
        }















/// <summary>
    /// 
///</summary>

///<param name="workspaceId">
///
///</param>
/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/workspaces/{workspaceId}", Name = "")]
[HttpPatch]
public async Task<IActionResult>Async(workspaceId)

    {
     var responseBuilder = await InternalAsync(workspaceId);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( workspaceId )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }














/// <summary>
    /// 
///</summary>

///<param name="workspaceId">
///
///</param>
/// <response code="204"></response>
/// <response code="400"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/workspaces/{workspaceId}", Name = "")]
[HttpDelete]
public async Task<IActionResult>Async(workspaceId)

    {
     var responseBuilder = await InternalAsync(workspaceId);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( workspaceId )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build204(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)204, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("204" == "default" ? 500 : 204);
            }

            
            
            

			

			public static ResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }














/// <summary>
    /// 
///</summary>

///<param name="workspaceId">
///
///</param>
/// <response code="204"></response>
/// <response code="401"></response>
/// <response code="404"></response>
[Route("/v1/workspaces/{workspaceId}", Name = "")]
[HttpGet]
public async Task<IActionResult>Async(workspaceId)

    {
     var responseBuilder = await InternalAsync(workspaceId);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<ResponseBuilder> InternalAsync( workspaceId )
            {
                throw new NotImplementedException();
            }

        public partial class ResponseBuilder : ResponseBuilder<ResponseBuilder>
        {
            [JsonConstructor]
            private ResponseBuilder() { }

            
            

			

			public static ResponseBuilder Build204(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)204, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("204" == "default" ? 500 : 204);
            }

            
            
            

			

			public static ResponseBuilder Build401(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)401, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("401" == "default" ? 500 : 401);
            }

            
            
            

			

			public static ResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new ResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }











    }
}

