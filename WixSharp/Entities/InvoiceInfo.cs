using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class InvoiceInfo
    {
        /// <summary>
        /// Invoice ID
        /// </summary>
        [JsonProperty("id")]
        public string InvoiceId { get; set; }

        /// <summary>
        /// Invoice source
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }
    }
}