using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Choice
    {
        /// <summary>
        /// Based on the customer’s choices, which (if any) variants that include the selected choices are in stock
        /// </summary>
        [JsonProperty("inStock")]
        public bool InStock { get; set; }

        /// <summary>
        /// Based on the customer’s choices, which (if any) variants that include the selected choices are visible
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Choice name
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Color hex value or choice name
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
        /// <summary>
        /// Option name(e.g., color, size)
        /// </summary>
        [JsonProperty("media")]
        public Media Media { get; set; }

    }
}