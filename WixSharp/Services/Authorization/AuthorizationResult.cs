using Newtonsoft.Json;

namespace WixSharp.Services.Authorization
{
    public class WixAuthorizationResult
    {
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}