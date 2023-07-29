using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Shared;
using ConventionsHandicap.App.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Services
{
    public class ConventionsHandicapReferentialService : IConventionsHandicapReferentialService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ConventionsHandicapReferentialService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<Academy> GetAcademyAsync(string academyName)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var academy = await conventionHandicapDbContext.Academies.Include(academy => academy.Departments).FirstOrDefaultAsync(academy => academy.Name == academyName);

                    if (null == academy)
                    {
                        throw new ConventionsHandicapNotFoundException($"Academy {academyName} does not exist");
                    }

                    return academy;
                }
            }
        }

        public async Task<Academy[]> GetAcademiesAsync()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    return await conventionHandicapDbContext.Academies.Include(academy => academy.Departments).ToArrayAsync();
                }
            }
        }
    }
}
