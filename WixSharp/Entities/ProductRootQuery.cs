using Newtonsoft.Json;

namespace WixSharp.Entities
{
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

    public class Query
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

    public class ProductRootQuery
    {
        [JsonProperty("query")]
        public Query Query { get; set; }
            
        /// <summary>
        /// Whether variants should be included in the response
        /// </summary>
        [JsonProperty("includeVariants")]
        public bool IncludeVariants { get; set; }

        /// <summary>
        /// Whether hidden products should be included in the response. Requires permissions to manage products.
        /// </summary>
        [JsonProperty("includeHiddenProducts")]
        public bool IncludeHiddenProducts { get; set; }
    }
}