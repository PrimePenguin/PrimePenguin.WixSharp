using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class PickupDetails
    {
        /// <summary>
        /// Pickup address
        /// </summary>
        [JsonProperty("pickupAddress")]
        public PickupAddress PickupAddress { get; set; }


        /// <summary>
        /// Customer details
        /// </summary>
        [JsonProperty("buyerDetails")]
        public BuyerDetails BuyerDetails { get; set; }


        /// <summary>
        /// Store owner's pickup instructions
        /// </summary>
        [JsonProperty("pickupInstructions")]
        public string PickupInstructions { get; set; }

    }
}