using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class FulFillmentResponse
    {
        /// <summary>
        /// Fulfillment id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}