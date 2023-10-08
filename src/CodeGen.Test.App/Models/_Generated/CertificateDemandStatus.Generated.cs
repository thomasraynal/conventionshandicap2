
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


/// <summary>
///  
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
[DataContract]
public enum CertificateDemandStatus
{
    [EnumMember(Value = "ToComplete")]
    @ToComplete,
    [EnumMember(Value = "ToValidate")]
    @ToValidate,
    [EnumMember(Value = "Validated")]
    @Validated,
}

}






