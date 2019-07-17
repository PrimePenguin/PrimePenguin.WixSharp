using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class LineItemOption
    {
        /// <summary>
        /// Option name
        /// </summary>
        [JsonProperty("option")]
        public string Option { get; set; }

        /// <summary>
        /// Selected choice for this option
        /// </summary>
        [JsonProperty("selection")]
        public string Selection { get; set; }
    }
}