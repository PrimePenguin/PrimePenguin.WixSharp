using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
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
}