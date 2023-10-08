using ConventionsHandicap;
using ConventionsHandicap.App.Contracts;
using ConventionsHandicap.App.Features.CertificateDemand.Contracts;
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
        private readonly IConventionsHandicapFeaturesService _conventionsHandicapFeaturesService;
        private readonly IConventionsHandicapCertificateDemandService _certificateDemandService;
        private readonly IConventionsHandicapWorkspaceService _conventionsHandicapWorkspaceService;
        private readonly IConventionsHandicapCertificateDemandMailService _mailService;

        public ConventionsHandicapController(IConventionsHandicapReferentialService conventionsHandicapReferentialService,
            IConventionsHandicapWorkspaceService workspaceService,
            IConventionsHandicapFeaturesService conventionsHandicapFeaturesService,
            ConventionsHandicapWorkspaceService conventionsHandicapWorkspaceService,
            IConventionsHandicapCertificateDemandService certificateDemandService,
            IConventionsHandicapCertificateDemandMailService mailService,
            UserManager<ConventionsHandicapUser> userManager)
        {
            _conventionsHandicapReferentialService = conventionsHandicapReferentialService;
            _userManager = userManager;
            _workspaceService = workspaceService;
            _conventionsHandicapFeaturesService = conventionsHandicapFeaturesService;
            _certificateDemandService = certificateDemandService;
            _conventionsHandicapWorkspaceService = conventionsHandicapWorkspaceService;
            _mailService = mailService;

        }
    }
}
