using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Entities;

namespace WixSharp.Services.AppInstance
{
    public class AppInstanceService : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="AppInstanceService" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public AppInstanceService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Retrieves data about the installation of your app on the user's website
        /// </summary>
        public virtual async Task<AppInstanceResponse> GetAsync()
        {
            var req = PrepareRequestForAppInstance($"instance");
            return await ExecuteRequestAsync<AppInstanceResponse>(req, HttpMethod.Get);
        }
    }
}