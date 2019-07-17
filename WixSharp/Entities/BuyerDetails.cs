using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class BuyerDetails
    {
        /// <summary>
        /// Addressee name
        /// </summary>
        [JsonProperty("fullName")]
        public FullName FullName { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}