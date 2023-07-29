using Anabasis.Identity.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Controller.Dto
{
    public class ConventionsHandicapLoginDto : UserLoginDto
    {
        [Required(ErrorMessage = "WorkspaceId is required")]
        public Guid? WorkspaceId { get; set; }
    }
}
