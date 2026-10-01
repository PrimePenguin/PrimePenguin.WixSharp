using System;
using Newtonsoft.Json;

namespace WixSharp.Services.Authorization
{
    public class WixOAuthTokenResult
    {
        /// <summary>
        /// Access token. Pass it as the shopAccessToken of any WixSharp service.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Token type. Always "Bearer".
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Token lifetime in seconds (4 hours).
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// When the token expires, calculated from <see cref="ExpiresIn"/> when the token was received.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset ExpiresAt { get; set; }
    }

    public class WixTokenInfoResult
    {
        /// <summary>
        /// Whether the token is active.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Type of subject the token is issued to, e.g. "APP", "USER", "MEMBER", "VISITOR".
        /// </summary>
        [JsonProperty("subjectType")]
        public string SubjectType { get; set; }

        [JsonProperty("subjectId")]
        public string SubjectId { get; set; }

        /// <summary>
        /// Token expiration time, in seconds since the Unix epoch.
        /// </summary>
        [JsonProperty("exp")]
        public long? Exp { get; set; }

        /// <summary>
        /// Token issue time, in seconds since the Unix epoch.
        /// </summary>
        [JsonProperty("iat")]
        public long? Iat { get; set; }

        /// <summary>
        /// ID of the app that created the token.
        /// </summary>
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("siteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// ID of the app instance the token was created for.
        /// </summary>
        [JsonProperty("instanceId")]
        public string InstanceId { get; set; }
    }
}
