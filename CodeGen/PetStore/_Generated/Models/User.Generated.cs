
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



namespace PetStore
{

public partial class User 
{ 
    
    public long
  Id  {get; set;}

    
    public string
  Username  {get; set;}

    
    public string
  FirstName  {get; set;}

    
    public string
  LastName  {get; set;}

    
    public string
  Email  {get; set;}

    
    public string
  Password  {get; set;}

    
    public string
  Phone  {get; set;}

    
    public int
  UserStatus  {get; set;}

}




}



