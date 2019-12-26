using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class InventoryVariantsResponse
    {
        /// <summary>
        /// Whether quantity is being tracked
        /// </summary>
        [JsonProperty("trackQuantity")]
        public bool TrackQuantity { get; set; }

        /// <summary>
        /// Product ID
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
        /// Inventory’s unique numeric ID(assigned in ascending order). Primarily for sorting and filtering when crawling all inventories
        /// </summary>
        [JsonProperty("numericId")]
        public int NumericId { get; set; }

        /// <summary>
        /// Variants associated with this inventory item
        /// </summary>
        [JsonProperty("variants")]
        public List<InventoryVariant> Variants { get; set; }

    }

    public class InventoryVariant
    {
        /// <summary>
        /// Variant ID
        /// </summary>
        [JsonProperty("variantId")]
        public string VariantId { get; set; }

        /// <summary>
        /// Whether the product is listed as in stock
        /// </summary>
        [JsonProperty("inStock")]
        public bool InStock { get; set; }

        /// <summary>
        /// Quantity currently left in inventory (only returned when inventory is being tracked)
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
