using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class InventoryVariantsRequest
    {
        /// <summary>
        /// Product ID
        /// </summary>
        [JsonProperty("externalId")]
        public string ProductId { get; set; }

        /// <summary>
        /// Variant IDs to query for this inventory item(optional)
        /// </summary>
        [JsonProperty("variantIds")]
        public List<string> VariantIds { get; set; }
    }
}