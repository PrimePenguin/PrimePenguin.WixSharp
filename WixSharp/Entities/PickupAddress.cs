using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class PickupAddress
    {
        /// <summary>
        /// Address
        /// </summary>
        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// subdivision
        /// </summary>
        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Country code (3 letters)
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// State/District
        /// </summary>
        [JsonProperty("subdivision")]
        public string Subdivision { get; set; }

    }
}