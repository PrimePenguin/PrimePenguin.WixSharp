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
    }
}