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
    public class VariantInventoryRequestResponse
    {
        /// <summary>
        /// Inventory item ID
        /// </summary>
        [JsonProperty("itemId")]
        public bool ItemId { get; set; }

        /// <summary>
        /// Variant ID
        /// </summary>
        [JsonProperty("variantId")]
        public bool VariantId { get; set; }

        /// <summary>
        /// Whether the product is listed as in stock
        /// </summary>
        [JsonProperty("inStock")]
        public bool InStock { get; set; }

        /// <summary>
        /// Quantity currently left in inventory(only returned when inventory is being tracked).
        /// </summary>
        [JsonProperty("quantity")]
        public bool Quantity { get; set; }
    }
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
