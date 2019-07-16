using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class ProductQuery
    {
        /// <summary>
        /// Filter string
        /// </summary>
        [JsonProperty("filter")]
        public string Filter { get; set; }

        /// <summary>
        /// Sort string
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; }
        [JsonProperty("paging")] public Paging Paging { get; set; }
    }
    public class Paging
    {
        /// <summary>
        /// Amount of items to load per page
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Number of items to skip in the display (relevant for all pages after the first)
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
    public class ProductQueryResponse
    {
        [JsonProperty("totalResults")] public int TotalResults { get; set; }

        [JsonProperty("metadata")] public MetaData MetaData { get; set; }

        [JsonProperty("products")] public IEnumerable<Product> Products { get; set; }
    }
    public class MetaData
    {
        /// <summary>
        /// Amount of items to load per page
        /// </summary>
        [JsonProperty("items")]
        public int Items { get; set; }

        /// <summary>
        /// Number of items to skip in the display(relevant for all pages after the first)
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

    }
    public class ProductQueryVariant
    {
        [JsonProperty("paging")] public Paging Paging { get; set; }

        /// <summary>
        /// List of variant IDs (Not relevant when passing choices)
        /// </summary>
        [JsonProperty("variantIds")]
        public List<string> VariantIds { get; set; }

        /// <summary>
        /// The specific choices available or chosen from within a selection (e.g., choosing the red Selection triggers the red Choice). You may specify all the relevant choices for a specific variant, or only some of the options, which will return all corresponding variants (Not relevant when passing variant IDs)
        /// </summary>
        [JsonProperty("choices")]
       public IEnumerable<IDictionary<string, string>> Choices { get; set; }
    }
    public class Choices
    {
        [JsonProperty("key")] public IEnumerable<IDictionary<string, string>> Key { get; set; }
    }
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
        public int Weight { get; set; }

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
