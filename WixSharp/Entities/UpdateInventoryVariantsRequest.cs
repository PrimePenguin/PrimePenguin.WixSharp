using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class UpdateInventoryVariantsRequest
    {
        [JsonProperty("inventoryItem")]
        public UpdateInventoryItem InventoryItem { get; set; }
    }

    public class UpdateInventoryItem
    {
        /// <summary>
        /// Whether quantity is being tracked
        /// </summary>
        [JsonProperty("trackQuantity")]
        public bool TrackQuantity { get; set; }

        /// <summary>
        /// Variants associated with this inventory item
        /// </summary>
        [JsonProperty("variants")]
        public List<UpdateInventoryVariants> Variants { get; set; }
    }

    public class UpdateInventoryVariants
    {
        /// <summary>
        /// Variant Id
        /// </summary>
        [JsonProperty("variantId")]
        public string VariantId { get; set; }

        /// <summary>
        /// Whether the product is listed as in stock
        /// </summary>
        [JsonProperty("inStock")]
        public bool InStock { get; set; }

        /// <summary>
        /// Quantity currently left in inventory(only returned when inventory is being tracked)
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
