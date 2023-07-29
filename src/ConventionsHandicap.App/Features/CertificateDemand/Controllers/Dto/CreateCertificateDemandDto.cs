using ConventionsHandicap.Model;
using ConventionsHandicap.Shared;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Controller.Dto
{
    public class CreateCertificateDemandDto
    {
        [JsonProperty("academy")]
        [Required(ErrorMessage = "Academy is required")]
        [AcademyValidation]
        public string Academy { get; set; }

        [Required(ErrorMessage = "ChildFirstName is required")]
        public string ChildFirstName { get; set; }

        [Required(ErrorMessage = "ChildLastName is required")]
        public string ChildLastName { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [DepartmentValidation]
        public string Department { get; set; }

        [Required(ErrorMessage = "Certificates is required")]
        public Guid[] Certificates { get; set; }

        [Required(ErrorMessage = "ChildDateOfBirth is required")]
        public DateTime? ChildDateOfBirth { get; set; }

        [Required(ErrorMessage = "WorkspaceId is required")]
        public Guid? WorkspaceId { get; set; }

        [JsonConverter(typeof(PropertyArrayDtoJsonConverter))]
        public Property[]? Properties { get; set; }


    }
}
