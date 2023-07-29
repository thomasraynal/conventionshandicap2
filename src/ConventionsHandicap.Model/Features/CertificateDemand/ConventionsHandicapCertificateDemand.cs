using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConventionsHandicap.Model.Features.CertificateDemand
{
    public class ConventionsHandicapCertificateDemand : IConventionsHandicapCertificateDemand
    {
        public ConventionsHandicapCertificateDemand()
        {
        }

        public ConventionsHandicapCertificateDemand(Guid id, 
            Academy academy, 
            Department department, 
            string childFirstName, 
            string childLastName, 
            DateTime childDateOfBirth, 
            ConventionsHandicapWorkspace workspace, 
            ConventionsHandicapCertificateDemandStatus 
            certificateDemandStatus, 
            ConventionsHandicapUser user,
            ConventionsHandicapCertificateTemplate[] certificateTemplates,
            ConventionsHandicapCertificateMetadataValue[] properties)
        {
            Id = id;
            Academy = academy;
            Department = department;
            ChildFirstName = childFirstName;
            ChildLastName = childLastName;
            ChildDateOfBirth = childDateOfBirth;
            Workspace = workspace;
            CertificateDemandStatus = certificateDemandStatus;
            UserId = user.Id;
            CertificateTemplates = certificateTemplates;
            Properties = properties;
        }

        public Guid Id { get; set; }

        [ForeignKey("AcademyName")]
        public string AcademyName { get; set; }
        public Academy Academy { get; set; }

        [ForeignKey("DepartmentName")]
        public string DepartmentName { get; set; }
        public Department Department { get; set; }

        public string ChildFirstName { get; set; }

        public string ChildLastName { get; set; }

        public DateTime ChildDateOfBirth { get; set; }

        [ForeignKey("WorkspaceId")]
        public Guid WorkspaceId { get; set; }

        public ConventionsHandicapWorkspace Workspace { get; set; }

        public ConventionsHandicapCertificateDemandStatus CertificateDemandStatus { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public ConventionsHandicapUser User { get; set; }

        public ICollection<ConventionsHandicapCertificateTemplate> CertificateTemplates { get; set; }
        
        public ICollection<ConventionsHandicapCertificateMetadataValue> Properties { get; set; }
    }
}
