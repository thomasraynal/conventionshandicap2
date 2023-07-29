using Anabasis.Identity.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConventionsHandicap.Controller.Dto
{
    public class ConventionsHandicapLoginDto : UserLoginDto
    {
        [Required(ErrorMessage = "WorkspaceId is required")]
        public Guid? WorkspaceId { get; set; }
    }
}
