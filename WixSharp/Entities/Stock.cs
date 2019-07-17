using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Stock
    {
        /// <summary>
        /// Whether inventory is being tracked
        /// </summary>
        [JsonProperty("trackInventory")]
        public bool TrackInventory { get; set; }

        /// <summary>
        /// Quantity currently left in inventory
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Whether the product is currently in stock(relevant only when tracking manually)
        /// </summary>
        [JsonProperty("inStock")]
        public bool InStock { get; set; }
    }
}