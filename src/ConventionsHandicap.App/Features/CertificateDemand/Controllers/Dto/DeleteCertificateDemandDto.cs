using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Controller.Dto
{
    public class DeleteCertificateDemandDto
    {
        public Guid CertificateDemandId { get; set; }
        public Guid WorkspaceId { get; set; }
    }
}
