using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class TrackingInfo
    {
        /// <summary>
        /// Tracking number
        /// </summary>
        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }


        /// <summary>
        /// Shipping provider
        /// </summary>
        [JsonProperty("shippingProvider")]
        public string ShippingProvider { get; set; }

        /// <summary>
        /// Tracking link
        /// </summary>
        [JsonProperty("trackingLink")]
        public string TrackingLink { get; set; }
    }
}