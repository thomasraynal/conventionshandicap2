
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



public partial class ConventionsHandicapCertificateDemandSendMailRequest 
{ 
    
    public                 Guid

   WorkspaceId{get; set;}

    
    public                 Guid

?   CertificateDemandId{get; set;}

    
    public                     string

?   SubjectText{get; set;}

    
    public                     string

?   BodyText{get; set;}

    
    public             bool
   IsHtml{get; set;}

}


}





















