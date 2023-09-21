using ConventionsHandicap.Model;
using System;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Contracts
{
    public interface IConventionsHandicapFeaturesService
    {
        Task<ConventionsHandicapFeature[]> GetConventionsAllHandicapFeatureAsync();
        Task<ConventionsHandicapFeature[]> GetConventionsHandicapFeatureByWorkspaceAsync(Guid workspaceId);
        Task<ConventionsHandicapFeature> GetConventionsOneHandicapFeatureAsync(Guid featureId);
    }
}