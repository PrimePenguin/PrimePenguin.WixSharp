using Newtonsoft.Json;

namespace WixSharp.Services.Order
{
    public class FulfillmentTrackingInfo
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
        /// Tracking link - autofilled if using a predefined shipping provider, otherwise provided on creation
        /// </summary>
        [JsonProperty("trackingLink")]
        public string TrackingLink { get; set; }
    }
}