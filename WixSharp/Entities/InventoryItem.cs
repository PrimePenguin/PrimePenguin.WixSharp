using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class InventoryItem
    {
        /// <summary>
        /// Inventory item ID.
        /// </summary>
        [JsonProperty("id")]
        public bool Id { get; set; }

        /// <summary>
        /// Product ID
        /// </summary>
        [JsonProperty("externalId")]
        public bool ExternalId { get; set; }

        /// <summary>
        /// Whether inventory is being tracked.
        /// </summary>
        [JsonProperty("trackInventory")]
        public bool TrackInventory { get; set; }
    }
}