using Anabasis.Common.Shared;
using Anabasis.Identity.Shared;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Features.CertificateDemand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace ConventionsHandicap.Tests
{

    [TestFixture]
    public class DbContextFixture
    {
        [Ignore("todo")]
        [Test]
        public async Task ShouldCreateDemands()
        {
            using (var conventionHandicapDbContext = new ConventionHandicapDbContextFactory().CreateDbContext(null))
            {
                var user = await conventionHandicapDbContext.ConventionsHandicapUsers.FirstAsync();
                var academy = await conventionHandicapDbContext.Academies.Include(d=>d.Departments).FirstAsync();
                var template = await conventionHandicapDbContext.ConventionsHandicapCertificateTemplates.FirstAsync();

                var workspace = new ConventionsHandicapWorkspace()
                {
                    Id = Guid.NewGuid(),
                    Name = $"{Guid.NewGuid()}"
                };

                conventionHandicapDbContext.ConventionsHandicapWorkspaces.Add(workspace);

                await conventionHandicapDbContext.SaveChangesAsync();

                var demand = new ConventionsHandicapCertificateDemand()
                {
                    ChildDateOfBirth = DateTime.UtcNow,
                    Academy = academy,
                    Department = academy.Departments.First(),
                    CertificateDemandStatus  = ConventionsHandicapCertificateDemandStatus.ToValidate,
                    ChildFirstName= "ffsqfq",
                    ChildLastName = "fqfsqf",
                    Workspace = workspace,
                    User = user,
                    Id = Guid.NewGuid()
                };

                demand.CertificateTemplates.Add(template);

                conventionHandicapDbContext.ConventionsHandicapCertificateDemands.Add(demand);

                demand.Properties.Add(new ConventionsHandicapCertificateMetadataValue()
                {
                    CertificateDemandId = demand.Id,
                    Code = "fffsf",
                    Value ="qfqfsqf"
                });


                await conventionHandicapDbContext.SaveChangesAsync();

                var conventionsHandicapCertificateDemands = await conventionHandicapDbContext.ConventionsHandicapCertificateDemands
                    .Include(demand=> demand.CertificateTemplates)
                    .ToListAsync();
                var templates = await conventionHandicapDbContext.ConventionsHandicapCertificateTemplates
                    .Include(demand => demand.CertificateDemands)
                    .ToArrayAsync();
            }
        }

        [Ignore("todo")]
        [Test]
        public async Task ShouldCreateRootAdminUser()
        {

            var rootAdminEmail = "thomas.raynal2@gmail.com";
            var rootAdminPassword = "password";

            using (var conventionHandicapDbContext = new ConventionHandicapDbContextFactory().CreateDbContext(null))
            {
                var serviceCollection = new ServiceCollection();

                serviceCollection.AddDbContext<ConventionHandicapDbContext>(options => options.UseSqlServer(""));

                serviceCollection
                .AddIdentity<ConventionsHandicapUser, ConventionsHandicapIdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ConventionHandicapDbContext>();

                serviceCollection.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;

                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    options.User.RequireUniqueEmail = true;
                });

                serviceCollection.AddLogging();
                serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                var serviceProvider = serviceCollection.BuildServiceProvider();

                var userManager = serviceProvider.GetRequiredService<UserManager<ConventionsHandicapUser>>();

                var roleManager = serviceProvider.GetRequiredService<RoleManager<ConventionsHandicapIdentityRole>>();

                var userId = GuidUtility.Create(GuidUtility.UrlNamespace, rootAdminEmail);

                var conventionsHandicapUser = await userManager.FindByEmailAsync(rootAdminEmail);

                if (conventionsHandicapUser != null)
                {
                    return;
                }

                conventionsHandicapUser = new ConventionsHandicapUser()
                {
                    UserName = rootAdminEmail,
                    Email = rootAdminEmail,
                    UserTemporaryPassword = rootAdminPassword
                };

                var identityResult = await userManager.CreateAsync(conventionsHandicapUser);

                if (!identityResult.Succeeded)
                {
                    throw new InvalidOperationException($"Error during user creation {identityResult.FlattenErrors()}");
                }

                conventionsHandicapUser = await userManager.FindByEmailAsync(rootAdminEmail);

                identityResult = await userManager.AddPasswordAsync(conventionsHandicapUser, rootAdminPassword);

                if (!identityResult.Succeeded)
                {
                    throw new InvalidOperationException($"Error during role creation {identityResult.FlattenErrors()}");
                }

                var role = ConventionsHandicapIdentityRole.GetRoleName(ConventionsHandicapUserRole.Administrator, null);

                var doesRoleExist = await roleManager.RoleExistsAsync(role);

                if (!doesRoleExist)
                {
                    identityResult = await roleManager.CreateAsync(new ConventionsHandicapIdentityRole(ConventionsHandicapUserRole.Administrator, null));

                    if (!identityResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Error during role creation {identityResult.FlattenErrors()}");
                    }

                }

                var isUserInRole = await userManager.IsInRoleAsync(conventionsHandicapUser, role);

                if (!isUserInRole)
                {

                    identityResult = await userManager.AddToRoleAsync(conventionsHandicapUser, $"{ConventionsHandicapUserRole.Administrator}");

                    if (!identityResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Error during role creation {identityResult.FlattenErrors()}");
                    }

                }
            }
        }


    }
}