using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Services.Product
{
    public class ProductMediaChoices
    {
        /// <summary>
        /// Product option, e.g., color or size
        /// </summary>
        [JsonProperty("option")]
        public string Option { get; set; }

        /// <summary>
        /// Choice within the option, e.g., red or L
        /// </summary>
        [JsonProperty("choice")]
        public string Choice { get; set; }

        /// <summary>
        /// Media IDs(available via the Query Product endpoint)
        /// </summary>
        [JsonProperty("mediaIds")]
        public List<string> MediaIds { get; set; }
    }
}