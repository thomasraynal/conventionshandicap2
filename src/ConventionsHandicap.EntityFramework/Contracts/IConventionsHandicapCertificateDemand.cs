using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model.Features.CertificateDemand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model.Contracts
{
    public interface IConventionsHandicapCertificateDemand
    {
        Guid Id { get; }
        Academy Academy { get; }
        Department Department { get; }
        string ChildFirstName { get; }
        string ChildLastName { get; }
        DateTime ChildDateOfBirth { get; }
        ConventionsHandicapWorkspace Workspace { get; }
        ConventionsHandicapCertificateDemandStatus CertificateDemandStatus { get; }
        ConventionsHandicapUser User { get; }
        ICollection<ConventionsHandicapCertificateTemplate> CertificateTemplates { get; }
        ICollection<ConventionsHandicapCertificateMetadataValue> Properties { get; }
    }
}
