using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Services.Product
{
    public class UpdateVariantRequest
    {
        /// <summary>
        /// Variant weight
        /// </summary>
        [JsonProperty("weight")]
        public int Weight { get; set; }

        /// <summary>
        /// Variant SKU (stock keeping unit)
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// The specific choices available or chosen from within a selection(e.g., choosing the red Selection triggers the red Choice). You may specify all the relevant choices for a specific variant, or only some of the options, which will return all corresponding variants(Not relevant when passing variant IDs)
        /// </summary>
        [JsonProperty("choices")]
        public IEnumerable<IDictionary<string, string>> Choices { get; set; }

        /// <summary>
        /// Whether the variant is visible to customers
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// List of variant IDs (Not relevant when passing choices)
        /// </summary>
        [JsonProperty("variantIds")]
        public List<string> VariantsIds { get; set; }

        /// <summary>
        /// Variant price
        /// </summary>
        [JsonProperty("price")]
        public int Price { get; set; }
    }
}