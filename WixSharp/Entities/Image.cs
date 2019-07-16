using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Image
    {
        /// <summary>
        /// Media item URL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Media item URL
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Media item URL
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}