
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



namespace ConventionsHandicap
{



public partial class CertificateDemandDto 
{ 
    
    public Guid
   Id{get; set;}

    
    public string
?   Academy{get; set;}

    
    public string
?   Department{get; set;}

    
    public string
?   ChildFirstName{get; set;}

    
    public string
?   ChildLastName{get; set;}

    
    public string
   ChildDateOfBirth{get; set;}

    
    public Guid
   WorkspaceId{get; set;}

    
    public string
   CertificateDemandStatus{get; set;}

    
    public Guid
   UserId{get; set;}

    
    public  Guid
[]
?   CertificateTemplates{get; set;}

    
    public Dictionary<string, string
>
?   Properties{get; set;}

}


}






