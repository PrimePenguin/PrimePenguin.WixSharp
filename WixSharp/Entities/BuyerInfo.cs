using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class BuyerInfo
    {
        /// <summary>
        /// May display visitorId/memberId/uid interchangeably
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Customer type
        /// </summary>
        [JsonProperty("type")]
        public IdentityType Type { get; set; }
    }

    public enum IdentityType
    {
        UNSPECIFIED_IDENTITY_TYPE,
        MEMBER,
        CONTACT
    }
}