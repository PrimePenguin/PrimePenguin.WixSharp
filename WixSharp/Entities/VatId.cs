using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class VatId
    {
        /// <summary>
        /// Customer's tax ID
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// tax type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}