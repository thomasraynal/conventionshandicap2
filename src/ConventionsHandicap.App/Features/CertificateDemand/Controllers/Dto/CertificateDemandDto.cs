using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Features.CertificateDemand;
using ConventionsHandicap.Shared;
using Newtonsoft.Json;
using System;

namespace ConventionsHandicap.App.Features.CertificateDemand.Controllers.Dto
{
    public class CertificateDemandDto
    {
        public CertificateDemandDto(Guid id, string academy, string department, string childFirstName, string childLastName, DateTime childDateOfBirth, Guid workspaceId, ConventionsHandicapCertificateDemandStatus certificateDemandStatus, Guid userId, Guid[]? certificateTemplates, Property[]? properties)
        {
            Id = id;
            Academy = academy;
            Department = department;
            ChildFirstName = childFirstName;
            ChildLastName = childLastName;
            ChildDateOfBirth = childDateOfBirth;
            WorkspaceId = workspaceId;
            CertificateDemandStatus = certificateDemandStatus;
            UserId = userId;
            CertificateTemplates = certificateTemplates;
            Properties = properties;
        }

        public Guid Id { get; set; }

        public string Academy { get; set; }

        public string Department { get; set; }

        public string ChildFirstName { get; set; }

        public string ChildLastName { get; set; }

        public DateTime ChildDateOfBirth { get; set; }

        public Guid WorkspaceId { get; set; }

        public ConventionsHandicapCertificateDemandStatus CertificateDemandStatus { get; set; }

        public Guid UserId { get; set; }

        public Guid[]? CertificateTemplates { get; set; }

        [JsonConverter(typeof(PropertyArrayDtoJsonConverter))]
        public Property[]? Properties { get; set; }
    }
}
