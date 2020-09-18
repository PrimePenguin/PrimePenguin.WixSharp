using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class ShippingInfo
    {
        /// <summary>
        /// Shipping option name
        /// </summary>
        [JsonProperty("deliveryOption")]
        public string DeliveryOption { get; set; }

        /// <summary>
        /// Latest expected delivery date
        /// </summary>
        [JsonProperty("deliverByDate")]
        public string DeliverByDate { get; set; }

        /// <summary>
        /// Shipping option delivery time
        /// </summary>
        [JsonProperty("estimatedDeliveryTime")]
        public string EstimatedDeliveryTime { get; set; }

        [JsonProperty("shipmentDetails")] public Details ShipmentDetails { get; set; }
    }

    public class Details
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