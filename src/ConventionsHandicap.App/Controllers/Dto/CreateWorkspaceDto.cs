using System;
using System.ComponentModel.DataAnnotations;

namespace ConventionsHandicap.Controller.Dto
{
    public class CreateWorkspaceDto
    {
        public Uri? Logo { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

    }
}
