
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

public partial class Pet 
{ 
    
    public long
  Id  {get; set;}

    
    public Category
  Category  {get; set;}

    [Required(ErrorMessage = "name is required")]
    public string
  Name  {get; set;}

    [Required(ErrorMessage = "photoUrls is required")]
    public  string
[]
  PhotoUrls  {get; set;}

    
    public  Tag
[]
  Tags  {get; set;}

    
    public string
  PetStatus  {get; set;}

}




}



