using FeatureApi.Core;

namespace FeatureApi.Web.Services
{ 
    public class CurrentUserService : ICurrentUserService
    {
        // No actual authentication has been implemented. So hard coded string FTW.
        public string CurrentUserName() => "mrobertson";
    }
}
