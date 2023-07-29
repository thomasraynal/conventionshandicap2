using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Features.CertificateDemand;
using ConventionsHandicap.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Controller.Dto
{
    public class UpdateCertificateDemandDto
    {

        [AcademyValidation]
        public string Academy { get; set; }

        [Required(ErrorMessage = "ChildFirstName is required")]
        public string ChildFirstName { get; set; }

        [Required(ErrorMessage = "ChildLastName is required")]
        public string ChildLastName { get; set; }

        [Required(ErrorMessage = "ChildDateOfBirth is required")]
        public DateTime? ChildDateOfBirth { get; set; }

        public ConventionsHandicapCertificateDemandStatus CertificateDemandStatus { get; set; }

        [DepartmentValidation]
        public string Department { get; set; }

        [Required(ErrorMessage = "Certificates is required")]
        public Guid[] Certificates { get; set; }

        [JsonConverter(typeof(PropertyArrayDtoJsonConverter))]
        public Property[] Properties { get; set; }

        [Required(ErrorMessage = "WorkspaceId is required")]
        public Guid? WorkspaceId { get; set; }

        [Required(ErrorMessage = "CertificateDemandId is required")]
        public Guid? CertificateDemandId { get; set; }
    }
}
