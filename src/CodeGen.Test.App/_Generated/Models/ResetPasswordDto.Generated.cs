
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
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;



namespace ConventionsHandicap.Model
{



public partial class ResetPasswordDto 
{ 
    [Required(ErrorMessage = "email is required")]
    public string
   Email{get; set;}

    [Required(ErrorMessage = "token is required")]
    public string
   Token{get; set;}

    [Required(ErrorMessage = "password is required")]
    public string
   Password{get; set;}

}


}






