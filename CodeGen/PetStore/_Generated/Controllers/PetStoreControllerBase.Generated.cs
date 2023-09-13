
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


namespace PetStore
{

public abstract partial class PetStoreControllerBase:ControllerBase
{







/// <summary>
    /// Add a new pet to the store
///</summary>

///<param name="body">
///Pet object that needs to be added to the store
///</param>
/// <response code="201"></response>
/// <response code="400"></response>
/// <response code="405"></response>
[Route("/pet", Name = "AddPet")]
[HttpPost]
public async Task<IActionResult>AddPetAsync(Pet body)

    {
     var responseBuilder = await AddPetInternalAsync(body);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<AddPetResponseBuilder> AddPetInternalAsync(Pet body )
            {
                throw new NotImplementedException();
            }

        public partial class AddPetResponseBuilder : ResponseBuilder<AddPetResponseBuilder>
        {
            [JsonConstructor]
            private AddPetResponseBuilder() { }

            
            

			public static AddPetResponseBuilder Build201(Pet content)
            {
				return new AddPetResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("201" == "default" ? 500 : 201);

            }

			public static AddPetResponseBuilder Build201(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)201, errorMessage, arguments) });
				
				return new AddPetResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("201" == "default" ? 500 : 201);
            }

            public static ErrorResponseMessage GetDefaultErrorResponseMessage201(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
                return new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)201, errorMessage, arguments) });
           
            }
            
            

			

			public static AddPetResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new AddPetResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static AddPetResponseBuilder Build405(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)405, errorMessage, arguments) });
				
				return new AddPetResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("405" == "default" ? 500 : 405);
            }

            
        }















/// <summary>
    /// Update an existing pet
///</summary>

///<param name="body">
///Pet object that needs to be added to the store
///</param>
/// <response code="400"></response>
/// <response code="404"></response>
/// <response code="405"></response>
[Route("/pet", Name = "UpdatePet")]
[HttpPut]
public async Task<IActionResult>UpdatePetAsync(Pet body)

    {
     var responseBuilder = await UpdatePetInternalAsync(body);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<UpdatePetResponseBuilder> UpdatePetInternalAsync(Pet body )
            {
                throw new NotImplementedException();
            }

        public partial class UpdatePetResponseBuilder : ResponseBuilder<UpdatePetResponseBuilder>
        {
            [JsonConstructor]
            private UpdatePetResponseBuilder() { }

            
            

			

			public static UpdatePetResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new UpdatePetResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static UpdatePetResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new UpdatePetResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
            
            

			

			public static UpdatePetResponseBuilder Build405(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)405, errorMessage, arguments) });
				
				return new UpdatePetResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("405" == "default" ? 500 : 405);
            }

            
        }















/// <summary>
    /// Get user by user name
///</summary>

///<param name="username">
///The name that needs to be fetched. Use user1 for testing. 
///</param>
/// <response code="200"></response>
/// <response code="400"></response>
/// <response code="404"></response>
[Route("/user", Name = "GetUserByName")]
[HttpGet]
public async Task<IActionResult>GetUserByNameAsync(string username)

    {
     var responseBuilder = await GetUserByNameInternalAsync(username);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<GetUserByNameResponseBuilder> GetUserByNameInternalAsync(string username )
            {
                throw new NotImplementedException();
            }

        public partial class GetUserByNameResponseBuilder : ResponseBuilder<GetUserByNameResponseBuilder>
        {
            [JsonConstructor]
            private GetUserByNameResponseBuilder() { }

            
            

			public static GetUserByNameResponseBuilder Build200(User content)
            {
				return new GetUserByNameResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);

            }

			public static GetUserByNameResponseBuilder Build200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
				
				return new GetUserByNameResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("200" == "default" ? 500 : 200);
            }

            public static ErrorResponseMessage GetDefaultErrorResponseMessage200(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
                return new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)200, errorMessage, arguments) });
           
            }
            
            

			

			public static GetUserByNameResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new GetUserByNameResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static GetUserByNameResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new GetUserByNameResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }















/// <summary>
    /// Updated user
///</summary>

///<param name="username">
///name that need to be deleted
///</param>
///<param name="body">
///Updated user object
///</param>
/// <response code="400"></response>
/// <response code="404"></response>
[Route("/user", Name = "UpdateUser")]
[HttpPut]
public async Task<IActionResult>UpdateUserAsync(string username,User body)

    {
     var responseBuilder = await UpdateUserInternalAsync(username, body);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<UpdateUserResponseBuilder> UpdateUserInternalAsync(string username,  User body )
            {
                throw new NotImplementedException();
            }

        public partial class UpdateUserResponseBuilder : ResponseBuilder<UpdateUserResponseBuilder>
        {
            [JsonConstructor]
            private UpdateUserResponseBuilder() { }

            
            

			

			public static UpdateUserResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new UpdateUserResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static UpdateUserResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new UpdateUserResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }














/// <summary>
    /// Delete user
///</summary>

///<param name="username">
///The name that needs to be deleted
///</param>
///<param name="enumParam">
///
///</param>
/// <response code="400"></response>
/// <response code="404"></response>
[Route("/user", Name = "DeleteUser")]
[HttpDelete]
public async Task<IActionResult>DeleteUserAsync(string username,string enumParam)

    {
     var responseBuilder = await DeleteUserInternalAsync(username, enumParam);

        return responseBuilder.BuildResult();
    
    }

  protected virtual Task<DeleteUserResponseBuilder> DeleteUserInternalAsync(string username,  string enumParam )
            {
                throw new NotImplementedException();
            }

        public partial class DeleteUserResponseBuilder : ResponseBuilder<DeleteUserResponseBuilder>
        {
            [JsonConstructor]
            private DeleteUserResponseBuilder() { }

            
            

			

			public static DeleteUserResponseBuilder Build400(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)400, errorMessage, arguments) });
				
				return new DeleteUserResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("400" == "default" ? 500 : 400);
            }

            
            
            

			

			public static DeleteUserResponseBuilder Build404(string errorMessage = "", Dictionary<string,object> arguments=null)
            {
				
				var content = new ErrorResponseMessage(new[] { new UserErrorMessage((HttpStatusCode)404, errorMessage, arguments) });
				
				return new DeleteUserResponseBuilder()
				   .WithContent(content)
				   .WithStatusCode("404" == "default" ? 500 : 404);
            }

            
        }











    }
}

