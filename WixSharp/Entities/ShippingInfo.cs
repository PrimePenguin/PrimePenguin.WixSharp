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

        [JsonProperty("details")] public Details Details { get; set; }
    }

    public class Details
    {
        /// <summary>
        /// Shipment details (when this object describes shipment)
        /// </summary>
        [JsonProperty("shipmentDetails")]
        public ShipmentDetails ShipmentDetails { get; set; }

        /// <summary>
        /// Pickup details (when this object describes pickup)
        /// </summary>
        [JsonProperty("pickupDetails")]
        public PickupDetails PickupDetails { get; set; }
    }
}