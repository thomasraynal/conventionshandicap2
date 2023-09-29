using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model.Features.CertificateDemand;
using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Features.CertificateDemand.Contracts;
using ConventionsHandicap.App.Features.CertificateDemand.Shared;
using ConventionsHandicap.App.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenXMLTemplates.Documents;
using OpenXMLTemplates.Engine;
using OpenXMLTemplates.Variables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Services
{
    internal class ConventionsHandicapGenerateCertificateService : IConventionsHandicapGenerateCertificateService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConventionsHandicapMetadataService _conventionsHandicapMetadataService;

        public ConventionsHandicapGenerateCertificateService(IServiceScopeFactory serviceScopeFactory, IConventionsHandicapMetadataService conventionsHandicapMetadataService)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _conventionsHandicapMetadataService = conventionsHandicapMetadataService;
        }

        public async Task<ConventionsHandicapGeneratedCertificate> GenerateCertificateAsync(ConventionsHandicapUser currentUser, Guid certificateDemandId, Guid certificateTemplateId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var certificateTemplate = await conventionHandicapDbContext.ConventionsHandicapCertificateTemplates.FirstOrDefaultAsync(template => certificateDemandId == template.Id);

                    if (null == certificateTemplate)
                    {
                        throw new ConventionsHandicapNotFoundException($"CertificateTemplate {certificateTemplateId} not found");
                    }

                    var certificateDemand = await conventionHandicapDbContext.ConventionsHandicapCertificateDemands.FirstOrDefaultAsync(template => certificateTemplateId == template.Id);

                    if (null == certificateDemand)
                    {
                        throw new ConventionsHandicapNotFoundException($"CertificateDemand {certificateDemandId} not found");
                    }

                    var certificatePath = Path.GetTempFileName();
                    var templateTemPath = Path.GetTempFileName().Replace(".tmp", ".docx");

                    File.Copy(certificateTemplate.FileInfo.FullName, templateTemPath, true);

                    using (var templateDocument = new TemplateDocument(templateTemPath))
                    {
                        var projectDataDictionnary = new Dictionary<string, string>();

                        foreach (var metadataValue in certificateDemand.Properties)
                        {

                            var metadata = _conventionsHandicapMetadataService.GetMetadata(metadataValue.Code);

                            if (null != metadataValue &&
                              null != metadataValue.Value &&
                              !string.IsNullOrEmpty((string)metadataValue.Value) &&
                              metadata.DataType == typeof(DateTime))
                            {
                                metadataValue.Value = DateTime.Parse($"{metadataValue.Value}").ToString("dd/MM/yyyy");
                            }

                            projectDataDictionnary.Add(metadataValue.Code, metadataValue.Value != null ? $"{metadataValue.Value}" : "[NOT FILLED]");
                        }

                        var variableSource = new VariableSource(projectDataDictionnary);

                        var defaultOpenXmlTemplateEngine = new DefaultOpenXmlTemplateEngine();

                        defaultOpenXmlTemplateEngine.ReplaceAll(templateDocument, variableSource);
                        templateDocument.SaveAs(certificatePath).Close();
                        templateDocument.Close();

                    }

                    File.Delete(templateTemPath);

                    return new ConventionsHandicapGeneratedCertificate { CertificateFileInfo = new FileInfo(certificatePath), MedataValues = certificateDemand.Properties.ToArray(), CertificateTemplate = certificateTemplate };

                }
            }
        }

        public async Task<ConventionsHandicapCertificateTemplate[]> GetCertificatesAsync()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    return await conventionHandicapDbContext.ConventionsHandicapCertificateTemplates.ToArrayAsync();
                }
            }
        }

        public async Task<ConventionsHandicapCertificateTemplate[]> GetCertificateTemplatesByAcademyAndDepartmentAsync(string academy, string department)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    return await conventionHandicapDbContext.ConventionsHandicapCertificateTemplates.Where(template => template.AcademyName == academy && template.DepartmentName == department).ToArrayAsync();
                }
            }
        }

        public async Task<ConventionsHandicapCertificateTemplate[]> GetCertificatesTemplatesByAcademyAsync(string academy)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    return await conventionHandicapDbContext.ConventionsHandicapCertificateTemplates.Where(template=> template.AcademyName == academy).ToArrayAsync();
                }
            }
        }
    }
}
