using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Controllers.Dto
{
    public class ConventionsHandicapSendMailToConventionHandicapDto
    {
        [Required(ErrorMessage = "BodyText is required")]
        public string BodyText { get; set; }

        [Required(ErrorMessage = "SubjectText is required")]
        public string SubjectText { get; set; }

        [Required(ErrorMessage = "WorkspaceId is required")]
        public Guid? WorkspaceId { get; set; }
    }
}
