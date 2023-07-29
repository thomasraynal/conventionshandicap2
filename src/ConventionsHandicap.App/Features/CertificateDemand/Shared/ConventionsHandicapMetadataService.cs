using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Features.CertificateDemand;
using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Features.CertificateDemand.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConventionsHandicap.App.Features.CertificateDemand.Shared
{

    public class ConventionsHandicapMetadataService : IConventionsHandicapMetadataService
    {
        public const string LocalCertificateMetadataRepositoryRoot = "./Features/CertificateDemand/Metadata";
        public const string LocalCertificateMetadataAcademiesRepositoryRoot = "./Features/CertificateDemand/Metadata/Academies";

        public ConventionsHandicapCertificateAcademyMetadata[] InMemoryAcademiesMetadata { get; }
        public ConventionsHandicapCertificateMetadata[] InMemoryMetadata { get; }

        public ConventionsHandicapMetadataService()
        {
            var inMemoryAcademyMetadata = new List<ConventionsHandicapCertificateAcademyMetadata>();

            InMemoryMetadata = File.ReadAllLines(Path.Combine(LocalCertificateMetadataRepositoryRoot, "metadata.csv")).Skip(1).Select(csvLine =>
            {
                var splitedCsv = csvLine.Split(',');

                return new ConventionsHandicapCertificateMetadata(splitedCsv[0], splitedCsv[1], splitedCsv[2], splitedCsv[3], splitedCsv[4], splitedCsv[5]);

            }).ToArray();

            var metadataAcademiesFiles = Directory.GetFiles(LocalCertificateMetadataAcademiesRepositoryRoot, "*.*", SearchOption.AllDirectories);

            foreach (var academyFolder in Directory.GetDirectories(LocalCertificateMetadataAcademiesRepositoryRoot))
            {

                var academy = new DirectoryInfo(academyFolder).Name;

                foreach (var departmentFolder in Directory.GetDirectories(academyFolder))
                {
                    var department = new DirectoryInfo(departmentFolder).Name;

                    var departmentFile = Directory.GetFiles(departmentFolder, "*.csv", SearchOption.AllDirectories).FirstOrDefault();

                    if (null == departmentFile) throw new ConventionsHandicapBadRequestException($"No metadata file found for {academy} - {department}");

                    var csvLines = File.ReadLines(departmentFile);

                    var metadatas = csvLines.Skip(1).Select(csvLine =>
                    {
                        var splitedCsv = csvLine.Split(',');
                        var code = splitedCsv[0].Trim();
                        var referenceMetatadata = InMemoryMetadata.FirstOrDefault(metadata => metadata.Code == code);

                        if (null == referenceMetatadata)
                        {
                            throw new ConventionsHandicapBadRequestException($"Unable to find reference metadata for field {code}");
                        }

                        return new ConventionsHandicapCertificateAcademyMetadata(academy, department, referenceMetatadata);

                    });

                    inMemoryAcademyMetadata.AddRange(metadatas);

                }

            }

            InMemoryAcademiesMetadata = inMemoryAcademyMetadata.ToArray();

        }

        public ConventionsHandicapCertificateMetadata[] GetMetadatas()
        {
            return InMemoryAcademiesMetadata;
        }
        public ConventionsHandicapCertificateMetadata[] GetMetadatasByAcademy(string academy)
        {
            return InMemoryAcademiesMetadata.Where(metadata => metadata.Academy == academy).ToArray();
        }

        public ConventionsHandicapCertificateMetadata[] GetMetadatasByAcademyAndDepartment(string academy, string department)
        {
            return InMemoryAcademiesMetadata.Where(metadata => metadata.Academy == academy && metadata.Department == department).ToArray();
        }

        public ConventionsHandicapCertificateMetadata GetMetadata(string code)
        {
            return InMemoryMetadata.FirstOrDefault(metadata => metadata.Code == code);
        }

        public void EnsureMetadataCodesExist(string[] metadataCodes)
        {
            foreach (var metadataCode in metadataCodes)
            {
                EnsureMetadataCodeExist(metadataCode);
            }
        }

        public void EnsureMetadataCodeExist(string metadataCode)
        {

            var metadata = GetMetadata(metadataCode);

            if (null == metadata)
            {
                throw new ConventionsHandicapBadRequestException($"Metadata {metadataCode} does not exist");
            }


        }

        public void EnsureMetadataExists(Property[] properties)
        {
            EnsureMetadataCodesExist(properties.Select(saveFieldBatchItem => saveFieldBatchItem.Code).ToArray());
        }



        public ConventionsHandicapCertificateMetadataValue[] GetMetadataValues(string academy, string department, Property[]? properties)
        {

            if (null ==  properties || properties.Length == 0)
            {
                return Array.Empty<ConventionsHandicapCertificateMetadataValue>();
            }

            EnsureMetadataExists(properties);

            EnsureMetadataValuesAreValidAndFormatted(properties);

            var metadatas = GetMetadatasByAcademyAndDepartment(academy, department);

            var notFoundInMetadata = properties.Where(property => !metadatas.Any(metadata => metadata.Code == property.Code));

            if (notFoundInMetadata.Any())
            {
                properties = properties.Where(property => !notFoundInMetadata.Any(notFound => property.Code == notFound.Code)).ToArray();
            }

            var metadataValues = new List<ConventionsHandicapCertificateMetadataValue>();

            foreach (var metadata in metadatas)
            {
                var valueCandidate = properties.FirstOrDefault(saveFieldBatchItem => saveFieldBatchItem.Code == metadata.Code);

                if (null == valueCandidate)
                {
                    metadataValues.Add(new ConventionsHandicapCertificateMetadataValue(metadata.Code, null));
                }
                else
                {
                    metadataValues.Add(new ConventionsHandicapCertificateMetadataValue(metadata.Code, valueCandidate?.Value));
                }
            }

            return metadataValues.ToArray();

        }

        public void EnsureMetadataValuesAreValidAndFormatted(Property[] properties)
        {
            foreach (var property in properties)
            {
                if (ConventionsHandicapPropertyFormater.Transformers.ContainsKey(property.Code))
                {
                    ConventionsHandicapPropertyFormater.Transformers[property.Code](property);
                }

                if (ConventionsHandicapPropertyFormater.Checkers.ContainsKey(property.Code))
                {
                    ConventionsHandicapPropertyFormater.Checkers[property.Code](property);
                }
            }
        }
    }
}
