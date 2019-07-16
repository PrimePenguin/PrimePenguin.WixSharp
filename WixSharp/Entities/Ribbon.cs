using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Ribbon
    {
        /// <summary>
        /// Ribbon text
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}