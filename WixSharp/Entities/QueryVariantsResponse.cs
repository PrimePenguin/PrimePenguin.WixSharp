using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class QueryVariantsResponse
    {
        [JsonProperty("totalResults")] public int TotalResults { get; set; }

        [JsonProperty("metadata")] public MetaData Metadata { get; set; }

        /// <summary>
        /// All variants
        /// </summary>
        [JsonProperty("variants")]
        public IEnumerable<Variants> Variants { get; set; }
    }

    public class Variants
    {
        /// <summary>
        /// Requested Variant ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Specific choices within a selection, as option-choice key-value pairs
        /// </summary>
        [JsonProperty("choices")]
        public IDictionary<string, string> Choices { get; set; }

        /// <summary>
        /// All variants
        /// </summary>
        [JsonProperty("variant")]
        public Variant Variant { get; set; }

        /// <summary>
        /// Variant inventory status
        /// </summary>
        [JsonProperty("variantInventoryStatus")]
        public VariantInventoryRequestResponse VariantInventoryStatus { get; set; }
    }

    public class Variant
    {
        /// <summary>
        /// Variant price
        /// </summary>
        [JsonProperty("price")]
        public Price Price { get; set; }

        /// <summary>
        /// Variant Weight
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }

        /// <summary>
        /// Variant SKU (stock keeping unit
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Whether the variant is visible to customers
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }
    }
}