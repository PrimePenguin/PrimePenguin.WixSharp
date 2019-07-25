using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class OrderQuery
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

    public class OrderRootQuery
    {
        [JsonProperty("query")]
        public OrderQuery Query { get; set; }
    }

    public class OrderQueryResponse
   {
       /// <summary>
       /// Total results
       /// </summary>
       [JsonProperty("totalResults")]
       public int TotalResults { get; set; }

       /// <summary>
       /// Paging metadata
       /// </summary>
       [JsonProperty("metadata")]
       public MetaData MetaData { get; set; }

       /// <summary>
       /// Orders answered the query
       /// </summary>
       [JsonProperty("orders")]
       public IEnumerable<Order> Orders { get; set; }
   }
}