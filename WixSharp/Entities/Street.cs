using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Street
    {
        /// <summary>
        /// Street number
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// Street name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}