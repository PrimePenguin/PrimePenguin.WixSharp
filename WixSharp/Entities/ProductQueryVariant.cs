using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
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
}
