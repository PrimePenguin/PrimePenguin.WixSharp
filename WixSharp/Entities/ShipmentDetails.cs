using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class ShipmentDetails
    {
        /// <summary>
        /// Shipping destination address
        /// </summary>
        [JsonProperty("address")]
        public Address Address { get; set; }

        /// <summary>
        /// Order tracking information
        /// </summary>
        [JsonProperty("trackingInfo")]
        public TrackingInfo TrackingInfo { get; set; }

        /// <summary>
        /// Discount applied for shipping
        /// </summary>
        [JsonProperty("discount")]
        public string Discount { get; set; }

        /// <summary>
        /// Tax applied for shipping
        /// </summary>
        [JsonProperty("tax")]
        public string Tax { get; set; }
    }
}