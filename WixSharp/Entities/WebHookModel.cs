using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WixSharp.Entities
{
    public class WebHookModel
    {
        /// <summary>The id of the web hook</summary>
        [JsonProperty("webHookId",
            NullValueHandling = NullValueHandling.Ignore)]
        public int? WebHookId { get; set; }

        /// <summary>The name of the web hook</summary>
        [JsonProperty("name",
            NullValueHandling = NullValueHandling.Ignore)]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>The triggering event</summary>
        [JsonProperty("event",
            NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public WebHookModelEvent Event { get; set; }

        /// <summary>The id of an order status. Only used with the order-status-changes event.</summary>
        [JsonProperty("statusId",
            NullValueHandling = NullValueHandling.Ignore)]
        [Range(1, int.MaxValue)]
        public int? StatusId { get; set; }

        /// <summary>The URL to call when the event triggers</summary>
        [JsonProperty("url",
            NullValueHandling = NullValueHandling.Ignore)]
        [StringLength(255)]
        public string Url { get; set; }
    }
}