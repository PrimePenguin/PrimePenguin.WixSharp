using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class BuyerInfo
    {
        /// <summary>
        /// Wix customer ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Customer's first name
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Customer's last name
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Customer's phone number
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Customer's email address
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}