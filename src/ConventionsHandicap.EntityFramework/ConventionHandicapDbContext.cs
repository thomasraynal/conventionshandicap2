using Anabasis.Common.Shared;
using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Features.CertificateDemand;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Xml.Linq;

namespace ConventionsHandicap.EntityFramework
{
    public class ConventionHandicapDbContext : DbContext
    {
#nullable disable
        public ConventionHandicapDbContext(DbContextOptions<ConventionHandicapDbContext> options) : base(options)
        {
        }
#nullable enable

        public DbSet<ConventionsHandicapUser> ConventionsHandicapUsers { get; set; }
        public DbSet<ConventionsHandicapIdentityRole> ConventionsHandicapIdentityRoles { get; set; }
        public DbSet<IdentityUserRole<Guid>> IdentityUserRoles { get; set; }
        public DbSet<ConventionsHandicapWorkspace> ConventionsHandicapWorkspaces { get; set; }
        public DbSet<ConventionsHandicapFeature> ConventionsHandicapFeatures { get; set; }
        public DbSet<ConventionsHandicapCertificateDemand> ConventionsHandicapCertificateDemands { get; set; }
        public DbSet<ConventionsHandicapCertificateTemplate> ConventionsHandicapCertificateTemplates { get; set; }
        public DbSet<ConventionsHandicapCertificateMetadataValue> ConventionsHandicapCertificateMetadataValues { get; set; }
        public DbSet<Academy> Academies { get; set; }
        public DbSet<Department> Departments { get; set; }

        private const string LocalCertificateRepositoryFeatures = "Features";
        private const string LocalCertificateRepositoryCertificateDemand = "CertificateDemand";
        private const string LocalCertificateRepositoryRootCertificates = "Certificates";
        private static readonly string LocalCertificateRepositoryRoot = Path.Combine(LocalCertificateRepositoryFeatures, LocalCertificateRepositoryCertificateDemand, LocalCertificateRepositoryRootCertificates);
  
        private static ConventionsHandicapCertificateTemplate[] GetCertificates()
        {
            var academiesCertificates = new List<ConventionsHandicapCertificateTemplate>();

            foreach (var certificateFolder in Directory.GetDirectories(LocalCertificateRepositoryRoot))
            {
                var academy = new DirectoryInfo(certificateFolder).Name;

                foreach (var departmentFolder in Directory.GetDirectories(certificateFolder))
                {
                    var department = new DirectoryInfo(departmentFolder).Name;

                    var departmentFiles = Directory.GetFiles(departmentFolder, "*.*", SearchOption.AllDirectories);

                    if (departmentFiles.Length == 0) throw new InvalidOperationException($"No certificate found for {academy} - {department}");

                    foreach (var departmentFile in departmentFiles)
                    {
                        var templateFileInfo = new FileInfo(departmentFile);

                        var certificate = new ConventionsHandicapCertificateTemplate()
                        {
                            Id = GuidUtility.Create(GuidUtility.UrlNamespace, templateFileInfo.Name),
                            Academy = new Academy() { Name = academy },
                            Department = new Department() { Name = department },
                            TemplateName = templateFileInfo.Name,
                            //https://github.com/thomasraynal/conventionshandicap/issues/21
                            RelativeFilePath = Path.Combine(LocalCertificateRepositoryRoot, academy, department, templateFileInfo.Name)
                        };

                        academiesCertificates.Add(certificate);
                    }
                }

            }

            return academiesCertificates.ToArray();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ConventionsHandicapUser>().ToTable("ConventionsHandicapUser").HasKey("Id");

            modelBuilder.Entity<ConventionsHandicapIdentityRole>().ToTable("ConventionsHandicapIdentityRole").HasKey("Name");
            modelBuilder.Entity<ConventionsHandicapIdentityRole>().Property(entity => entity.UserRole).HasConversion(new EnumToStringConverter<ConventionsHandicapUserRole>());

            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("IdentityUserRole").HasKey(userRole => new { userRole.UserId, userRole.RoleId });

            modelBuilder.Entity<ConventionsHandicapUser>().ToTable("ConventionsHandicapUser").HasKey("Id");

            modelBuilder.Entity<ConventionsHandicapWorkspace>().ToTable("ConventionsHandicapWorkspace").HasKey("Id");
            modelBuilder.Entity<ConventionsHandicapWorkspace>().Property(workspace => workspace.Logo).HasConversion(uri => uri.ToString(), uriString => new Uri(uriString));
            modelBuilder.Entity<ConventionsHandicapWorkspace>().ToTable("ConventionsHandicapWorkspace");

            var conventionsHandicapWorspaceId = Guid.Parse("91181DDC-6AE5-4CA1-B07C-623B876EB670");

            modelBuilder.Entity<ConventionsHandicapWorkspace>().HasData(
                new { Id = conventionsHandicapWorspaceId, Name = "Cap Handi Cap", }
                );

            var generateCertificateFeatureId = Guid.Parse("69227A83-84FE-497D-86B8-A413744DA919");

            modelBuilder.Entity<ConventionsHandicapFeature>().HasData(
                new { Id = generateCertificateFeatureId, Name = "GenerateCertificate", }
                );

            modelBuilder.Entity<ConventionsHandicapFeature>().ToTable("ConventionsHandicapFeature").HasKey("Id");
            modelBuilder.Entity<ConventionsHandicapFeature>().ToTable("ConventionsHandicapFeature")
                .HasMany(feature => feature.Workspaces)
                .WithMany(workspace => workspace.Features)
                .UsingEntity(j => j
                .ToTable("FeatureWorkspace")
                .HasData(
                       new { FeaturesId = generateCertificateFeatureId, WorkspacesId = conventionsHandicapWorspaceId }
                 ));

            modelBuilder.Entity<Department>().ToTable("Department").HasKey("Name");
            modelBuilder.Entity<Department>().ToTable("Department").HasOne(department => department.Academy).WithMany(academy => academy.Departments).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Academy>().ToTable("Academy").HasKey("Name");
            modelBuilder.Entity<Academy>().ToTable("Academy").HasMany(academy => academy.Departments).WithOne(department => department.Academy);

            modelBuilder.Entity<Academy>().HasData(new { Name = "Versailles", }, new { Name = "Paris" }, new { Name = "Créteil" });

            modelBuilder.Entity<Department>().HasData(
                new { Name = "92", AcademyName = "Versailles" },
                new { Name = "94", AcademyName = "Versailles" },
                new { Name = "95", AcademyName = "Versailles" },
                new { Name = "93", AcademyName = "Créteil" },
                new { Name = "75", AcademyName = "Paris" });

            modelBuilder.Entity<ConventionsHandicapCertificateTemplate>().ToTable("ConventionsHandicapCertificateTemplate").HasKey("Id");

            modelBuilder.Entity<ConventionsHandicapCertificateTemplate>().ToTable("ConventionsHandicapCertificateTemplate")
                .HasMany(template => template.CertificateDemands)
                .WithMany(demand => demand.CertificateTemplates)
                .UsingEntity<Dictionary<string, object>>(
                    "CertificateTemplateCertificateDemand",
                    builder => builder.HasOne<ConventionsHandicapCertificateDemand>().WithMany().OnDelete(DeleteBehavior.NoAction),
                    builder => builder.HasOne<ConventionsHandicapCertificateTemplate>().WithMany().OnDelete(DeleteBehavior.NoAction)
                );

            modelBuilder.Entity<ConventionsHandicapCertificateMetadataValue>().ToTable("ConventionsHandicapCertificateMetadataValue").HasKey(metadata => new { metadata.Code,  metadata.CertificateDemandId });

            var certificateTemplates = GetCertificates();

            modelBuilder.Entity<ConventionsHandicapCertificateTemplate>().HasData(certificateTemplates.Select(template =>
            {
                return new { Id = template.Id, TemplateName = template.TemplateName, AcademyName = template.Academy.Name, DepartmentName = template.Department.Name, RelativeFilePath = template.RelativeFilePath };
            }));

            modelBuilder.Entity<ConventionsHandicapCertificateDemand>().ToTable("ConventionsHandicapCertificateDemand").HasKey("Id");
            modelBuilder.Entity<ConventionsHandicapCertificateDemand>().Property(entity => entity.CertificateDemandStatus).HasConversion(new EnumToStringConverter<ConventionsHandicapCertificateDemandStatus>());
            modelBuilder.Entity<ConventionsHandicapCertificateDemand>().ToTable("ConventionsHandicapCertificateDemand").HasMany(demand => demand.Properties);
       

        }

    }
}
