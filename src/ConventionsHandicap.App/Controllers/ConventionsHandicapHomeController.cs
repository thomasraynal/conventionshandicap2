using ConventionsHandicap.Controller.Dto;
using ConventionsHandicap.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Anabasis.Common;
using ConventionsHandicap.Services;
using Anabasis.Identity;
using Anabasis.Api.Shared;

namespace ConventionsHandicap.Controller
{
    [Authorize]
    public class ConventionsHandicapHomeController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ConventionsHandicapHomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var webRoot = _webHostEnvironment.WebRootPath;
            var path = System.IO.Path.Combine(webRoot, "index.html");

            return File(path, "text/html");
        }
    }
}
