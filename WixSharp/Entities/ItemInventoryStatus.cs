using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class ItemInventoryStatus
    {
        /// <summary>
        /// Inventory item ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Whether inventory is being tracked.
        /// </summary>
        [JsonProperty("trackInventory")]
        public bool TrackInventory { get; set; }
    }
}
