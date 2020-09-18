using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public partial class VariantsWithInventoryResponse
    {
        [JsonProperty("inventoryItem")]
        public VariantsWithInventoryItem InventoryItem { get; set; }
    }

    public partial class VariantsWithInventoryItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("trackQuantity")]
        public bool TrackQuantity { get; set; }

        [JsonProperty("variants")]
        public VariantWithInventory[] Variants { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("numericId")]
        public string NumericId { get; set; }
    }

    public partial class VariantWithInventory
    {
        [JsonProperty("variantId")]
        public string VariantId { get; set; }

        [JsonProperty("inStock")]
        public bool InStock { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }
}
