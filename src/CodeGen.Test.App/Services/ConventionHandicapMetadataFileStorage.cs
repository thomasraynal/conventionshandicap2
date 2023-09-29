using Azure.Storage.Blobs;
using ConventionsHandicap.Model;
using ConventionsHandicap.App.Features.CertificateDemand.Contracts;
using Microsoft.AspNetCore.Http;
using Polly;
using Polly.Retry;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Services
{
    public class ConventionHandicapMetadataFileStorage : IConventionHandicapMetadataFileStorage
    {
        private readonly BlobContainerClient _blobContainerClient;
        private readonly RetryPolicy _retryPolicy;

        public ConventionHandicapMetadataFileStorage(ConventionsHandicapConfigurationOptions conventionsHandicapConfiguration)
        {

#if DEBUG
            _blobContainerClient = null;
#else
            _blobContainerClient = new BlobContainerClient(conventionsHandicapConfiguration.TableStorageConnectionString, "uploads");

#endif

            _retryPolicy = Policy.Handle<TaskCanceledException>()
                       .Or<SocketException>()
                       .Or<TimeoutException>()
                       .WaitAndRetry(5, (_) => TimeSpan.FromSeconds(5));

        }

        public async Task<Uri> SaveFileAsync(Guid projectId, string metadataCode, IFormFile file)
        {
#if DEBUG
            return new Uri("http://fakeuri.com");

#endif
            return await _retryPolicy.Execute(async () =>
            {

                await _blobContainerClient.CreateIfNotExistsAsync();

                var filePath = Path.Combine($"{projectId}", metadataCode, file.FileName);

                var blobClient = _blobContainerClient.GetBlobClient(filePath);

                using var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);

                memoryStream.Position = 0;

                var response = await blobClient.UploadAsync(memoryStream, overwrite: true);

                return new Uri(Path.Combine(_blobContainerClient.Uri.AbsolutePath, filePath));

            });

        }


    }
}
