using ConventionsHandicap;
using ConventionsHandicap.App.Contracts;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap
{
    public partial class ConventionsHandicapController : ConventionsHandicapApiControllerBase
    {
        private readonly IConventionsHandicapReferentialService _conventionsHandicapReferentialService;
        private readonly UserManager<ConventionsHandicapUser> _userManager;
        private readonly IConventionsHandicapWorkspaceService _workspaceService;

        public ConventionsHandicapController(IConventionsHandicapReferentialService conventionsHandicapReferentialService,
            IConventionsHandicapWorkspaceService workspaceService,
            UserManager<ConventionsHandicapUser> userManager)
        {
            _conventionsHandicapReferentialService = conventionsHandicapReferentialService;
            _userManager = userManager;
            _workspaceService = workspaceService;
        }
    }
}
