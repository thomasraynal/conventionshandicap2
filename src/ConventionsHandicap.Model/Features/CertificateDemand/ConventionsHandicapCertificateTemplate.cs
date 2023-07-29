using System.ComponentModel.DataAnnotations.Schema;

namespace ConventionsHandicap.Model.Features.CertificateDemand
{
    public class ConventionsHandicapCertificateTemplate
    {
        public Guid Id { get; set; }

        [ForeignKey("AcademyName")]
        public string AcademyName { get; set; }
        public Academy Academy { get; set; }

        [ForeignKey("DepartmentName")]
        public string DepartmentName { get; set; }
        public Department Department { get; set; }
        public string TemplateName { get; set; }
        public string FriendlyName => TemplateName;
        public string RelativeFilePath { get; set; }

        [NotMapped]
        public FileInfo FileInfo => new(RelativeFilePath);

        public ICollection<ConventionsHandicapCertificateDemand> CertificateDemands { get; set; }

    }
}
