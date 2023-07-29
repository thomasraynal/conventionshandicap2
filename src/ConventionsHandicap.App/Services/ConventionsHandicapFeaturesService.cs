using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using System;
using ConventionsHandicap.App.Contracts;

namespace ConventionsHandicap.App.Services
{
    public class ConventionsHandicapFeaturesService : IConventionsHandicapFeaturesService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ConventionsHandicapFeaturesService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task<ConventionsHandicapFeature> GetConventionsOneHandicapFeatureAsync(Guid featureId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var conventionsHandicapFeature = await conventionHandicapDbContext.ConventionsHandicapFeatures.FirstOrDefaultAsync(feature => feature.Id == featureId);

                    if (null == conventionsHandicapFeature)
                    {
                        throw new ConventionsHandicapNotFoundException($"Feature {featureId} does not exist");
                    }

                    return conventionsHandicapFeature;
                }
            }
        }

        public async Task<ConventionsHandicapFeature[]> GetConventionsHandicapFeatureByWorkspaceAsync(Guid workspaceId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var conventionsHandicapFeatures = await conventionHandicapDbContext.ConventionsHandicapFeatures
                        .Where(feature => feature.Workspaces.Any(workspace => workspace.Id == workspaceId)).ToArrayAsync();

                    return conventionsHandicapFeatures;
                }
            }
        }

        public async Task<ConventionsHandicapFeature[]> GetConventionsAllHandicapFeatureAsync()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                using (var conventionHandicapDbContext = scope.ServiceProvider.GetRequiredService<ConventionHandicapDbContext>())
                {
                    var conventionsHandicapFeatures = await conventionHandicapDbContext.ConventionsHandicapFeatures.ToArrayAsync();

                    return conventionsHandicapFeatures;
                }
            }
        }
    }
}
