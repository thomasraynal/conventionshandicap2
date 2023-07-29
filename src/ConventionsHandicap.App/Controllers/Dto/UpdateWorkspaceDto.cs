using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Controllers.Dto
{

    public class UpdateWorkspaceDto
    {
        public Uri? Logo { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Features is required")]
        public Guid[]? Features { get; set; }
    }
}
