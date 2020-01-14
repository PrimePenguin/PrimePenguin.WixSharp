using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class QueryInventoryResponse
    {
        [JsonProperty("totalResults")] public int TotalResults { get; set; }
        [JsonProperty("metadata")] public MetaData MetaData { get; set; }
        [JsonProperty("inventoryItems")] public List<QueryInventoryItem> QueryInventoryItems { get; set; }
    }

    public class QueryInventoryItem
    {
        /// <summary>
        /// Whether quantity is being tracked
        /// </summary>
        [JsonProperty("trackQuantity")]
        public bool TrackQuantity { get; set; }

        /// <summary>
        /// Product Id
        /// </summary>
        [JsonProperty("externalId")]
        public string ProductId { get; set; }

        /// <summary>
        /// Last updated timestamp
        /// </summary>
        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// Inventory item ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Inventory’s unique numeric ID (assigned in ascending order). Primarily for sorting and filtering when crawling all inventories
        /// </summary>
        [JsonProperty("numericId")]
        public string NumericId { get; set; }

        /// <summary>
        /// Variants associated with this inventory item
        /// </summary>
        [JsonProperty("variants")]
        public List<ItemVariant> Variants { get; set; }
    }

    public class ItemVariant
    {
        /// <summary>
        ///  Variant Id
        /// </summary>
        [JsonProperty("variantId")]
        public string VariantId { get; set; }

        /// <summary>
        /// Whether the product is listed as in stock
        /// </summary>
        [JsonProperty("inStock")]
        public bool InStock { get; set; }

        /// <summary>
        ///  Quantity currently left in inventory (only returned when inventory is being tracked)
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
