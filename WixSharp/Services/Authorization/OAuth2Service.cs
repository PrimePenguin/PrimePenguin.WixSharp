using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WixSharp.Infrastructure;

namespace WixSharp.Services.Authorization
{
    /// <summary>
    /// Wix OAuth 2 (client credentials) authentication. This is the authentication method for new Wix apps;
    /// the authorization code / refresh token flow in <see cref="AuthorizationService"/> is "custom authentication (legacy)",
    /// which is no longer available for new apps.
    /// </summary>
    public class OAuth2Service
    {
        private static HttpClient _Client { get; } = new HttpClient();

        /// <summary>
        /// Creates an access token for an app instance (a site that has installed the app). The token is valid for 4 hours;
        /// call this again to get a new one. Existing apps can switch from the legacy flow by replacing refresh token calls with this.
        /// </summary>
        /// <param name="appId">Your app ID, from the OAuth page of your app's dashboard.</param>
        /// <param name="appSecret">Your app secret key, from the OAuth page of your app's dashboard.</param>
        /// <param name="instanceId">
        /// The app instance ID. Received in the App Instance Installed webhook, in every webhook payload
        /// (<see cref="Entities.WixHookPayload.InstanceId"/>), and in the app instance query parameter.
        /// </param>
        public static async Task<WixOAuthTokenResult> CreateAccessTokenAsync(string appId, string appSecret, string instanceId)
        {
            var content = new JsonContent(new
            {
                grant_type = "client_credentials",
                client_id = appId,
                client_secret = appSecret,
                instance_id = instanceId
            });

            var result = await PostAsync<WixOAuthTokenResult>("oauth2/token", content);
            result.ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(result.ExpiresIn);

            return result;
        }

        /// <summary>
        /// Retrieves information about an access token, such as whether it's active and which app instance it belongs to.
        /// Works with both OAuth and legacy custom authentication tokens.
        /// </summary>
        /// <param name="accessToken">The access token to inspect.</param>
        public static async Task<WixTokenInfoResult> GetTokenInfoAsync(string accessToken)
        {
            var content = new JsonContent(new { token = accessToken });
            return await PostAsync<WixTokenInfoResult>("oauth2/token-info", content);
        }

        private static async Task<T> PostAsync<T>(string path, HttpContent content)
        {
            var ub = new UriBuilder(WixService.BuildWixApiUri())
            {
                Path = path
            };

            using (var msg = new CloneableRequestMessage(ub.Uri, HttpMethod.Post, content))
            using (var response = await _Client.SendAsync(msg))
            {
                var rawDataString = await response.Content.ReadAsStringAsync();

                WixService.CheckResponseExceptions(response, rawDataString);
                return JsonConvert.DeserializeObject<T>(rawDataString);
            }
        }
    }
}
