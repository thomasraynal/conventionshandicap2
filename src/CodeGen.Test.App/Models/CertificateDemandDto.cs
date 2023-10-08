using ConventionsHandicap.Model;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model
{
    public partial class CertificateDemandDto
    {
        public CertificateDemandDto(Guid id, string academyName, string departmentName, string childFirstName, string childLastName, DateTime childDateOfBirth, Guid workspaceId, ConventionsHandicapCertificateDemandStatus certificateDemandStatus, Guid userId, Guid[] guids, object value)
        {
            Id = id;
            Academy = academyName;
            Department = departmentName;
            ChildFirstName = childFirstName;
            ChildLastName = childLastName;
            ChildDateOfBirth = childDateOfBirth;
            WorkspaceId = workspaceId;
            CertificateDemandStatus = certificateDemandStatus;
            UserId = userId;
        }
    }
}
