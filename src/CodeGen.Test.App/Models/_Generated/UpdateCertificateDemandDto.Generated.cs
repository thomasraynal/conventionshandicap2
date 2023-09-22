
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



public partial class UpdateCertificateDemandDto 
{ 
    
    public string
?   Academy{get; set;}

    [Required(ErrorMessage = "childFirstName is required")]
    public string
   ChildFirstName{get; set;}

    [Required(ErrorMessage = "childLastName is required")]
    public string
   ChildLastName{get; set;}

    [Required(ErrorMessage = "childDateOfBirth is required")]
    public string
   ChildDateOfBirth{get; set;}

    
    public string
   CertificateDemandStatus{get; set;}

    
    public string
?   Department{get; set;}

    [Required(ErrorMessage = "certificates is required")]
    public  Guid
[]
   Certificates{get; set;}

    
    public  Property
[]
?   Properties{get; set;}

    [Required(ErrorMessage = "workspaceId is required")]
    public Guid
   WorkspaceId{get; set;}

    [Required(ErrorMessage = "certificateDemandId is required")]
    public Guid
   CertificateDemandId{get; set;}

}


}






