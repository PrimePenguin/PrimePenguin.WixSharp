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
        /// first name of the buyer
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// last name of the buyer
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// phone of the buyer
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// email of the buyer
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

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