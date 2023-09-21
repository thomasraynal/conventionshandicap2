
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



public partial class CertificateTemplateDto 
{ 
    
    public Guid
   Id{get; set;}

    
    public string
?   Academy{get; set;}

    
    public string
?   Department{get; set;}

    
    public string
?   TemplateName{get; set;}

    
    public string
?   FriendlyName{get; set;}

}


}






