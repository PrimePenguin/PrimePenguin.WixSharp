using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class UpdateInventoryRequest
    {
        /// <summary>
        /// Inventory Item
        /// </summary>
        [JsonProperty("inventoryItem")]
        public Item InventoryItem { get; set; }
    }

    public class Item
    {
        /// <summary>
        /// Whether quantity is being tracked.
        /// </summary>
        [JsonProperty("trackQuantity")]
        public bool TrackQuantity { get; set; }

        /// <summary>
        /// Variants associated with this inventory item.
        /// </summary>
        [JsonProperty("variants")]
        public List<ProductVariant> Variants { get; set; }
    }

    public class ProductVariant
    {
        /// <summary>
        /// Variant ID
        /// </summary>
        [JsonProperty("variantId")]
        public Guid VariantId { get; set; }

        /// <summary>
        /// Quantity currently left in inventory (only returned when inventory is being tracked).
        /// </summary>
        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// Whether the product is listed as in stock
        /// </summary>
        [JsonProperty("inStock")]
        public bool? InStock { get; set; }
    }
}
