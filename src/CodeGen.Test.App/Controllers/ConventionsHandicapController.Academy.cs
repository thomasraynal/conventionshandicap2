using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Contracts;
using ConventionsHandicap.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using ConventionsHandicap.Model;
using System.ComponentModel;
using Anabasis.Api;

namespace ConventionsHandicap
{


    public partial class ConventionsHandicapController
    {
   
        protected override async Task<GetAcademiesResponseBuilder> GetAcademiesInternalAsync()
        {
            var academies = await _conventionsHandicapReferentialService.GetAcademiesAsync();
            return GetAcademiesResponseBuilder.Build200(academies);
        }

        protected async override Task<GetAcademyResponseBuilder> GetAcademyInternalAsync(string academyName)
        {
            var academy = await _conventionsHandicapReferentialService.GetAcademyAsync(academyName);
            return GetAcademyResponseBuilder.Build200(academy);
        }
    }
}
