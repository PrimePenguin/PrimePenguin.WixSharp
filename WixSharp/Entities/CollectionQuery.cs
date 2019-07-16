using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class CollectionQuery
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

    public class CollectionQueryResponse
    {
        [JsonProperty("totalResults")] public int TotalResults { get; set; }
        [JsonProperty("metadata")] public MetaData MetaData { get; set; }
        [JsonProperty("collections")] public IEnumerable<Collection> Collections { get; set; }
    }
}
