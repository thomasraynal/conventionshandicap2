using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Features.CertificateDemand;
using ConventionsHandicap.App.Features.CertificateDemand.Shared;

namespace ConventionsHandicap.App.Features.CertificateDemand.Contracts
{
    public interface IConventionsHandicapMetadataService
    {
        ConventionsHandicapCertificateAcademyMetadata[] InMemoryAcademiesMetadata { get; }
        ConventionsHandicapCertificateMetadata[] InMemoryMetadata { get; }

        ConventionsHandicapCertificateMetadataValue[] GetMetadataValues(string academy, string department, Property[]? properties);
        void EnsureMetadataCodeExist(string metadataCode);
        void EnsureMetadataCodesExist(string[] metadataCodes);
        void EnsureMetadataExists(Property[] properties);
        void EnsureMetadataValuesAreValidAndFormatted(Property[] properties);
        ConventionsHandicapCertificateMetadata GetMetadata(string code);
        ConventionsHandicapCertificateMetadata[] GetMetadatas();
        ConventionsHandicapCertificateMetadata[] GetMetadatasByAcademy(string academy);
        ConventionsHandicapCertificateMetadata[] GetMetadatasByAcademyAndDepartment(string academy, string department);
    }
}