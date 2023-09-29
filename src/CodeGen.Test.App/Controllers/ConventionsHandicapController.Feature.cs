using ConventionsHandicap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap
{
    public partial class ConventionsHandicapController
    {
        protected async override Task<GetFeatureByIdResponseBuilder> GetFeatureByIdInternalAsync(Guid featureId)
        {
            var feature = await _conventionsHandicapFeaturesService.GetConventionsOneHandicapFeatureAsync(featureId);

            return GetFeatureByIdResponseBuilder.Build200(feature);
        }

        protected async override Task<GetFeaturesResponseBuilder> GetFeaturesInternalAsync(Guid? workspaceId)
        {
            ConventionsHandicapFeature[] conventionsHandicapFeatures;

            if (null != workspaceId)
            {
                conventionsHandicapFeatures = await _conventionsHandicapFeaturesService.GetConventionsHandicapFeatureByWorkspaceAsync(workspaceId.Value);
            }
            else
            {
                conventionsHandicapFeatures = await _conventionsHandicapFeaturesService.GetConventionsAllHandicapFeatureAsync();
            }

            return GetFeaturesResponseBuilder.Build200(conventionsHandicapFeatures);
        }
    }
}