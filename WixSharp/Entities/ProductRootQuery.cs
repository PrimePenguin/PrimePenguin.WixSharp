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
    }
}