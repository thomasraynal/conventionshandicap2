using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Contracts
{
    public interface IConventionHandicapMetadataFileStorage
    {
        Task<Uri> SaveFileAsync(Guid projectId, string metadataCode, IFormFile file);
    }
}
