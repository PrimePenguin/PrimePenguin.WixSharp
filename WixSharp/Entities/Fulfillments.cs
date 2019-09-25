using System.Collections.Generic;
using Newtonsoft.Json;
using WixSharp.Services.Order;

namespace WixSharp.Entities
{
    public class Fulfillments
    {
        /// <summary>
        /// Fulfillment ID (auto generated upon fulfillment creation)
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Date generated
        /// </summary>
        [JsonProperty("dateCreated")]
        public string DateCreated { get; set; }

        /// <summary>
        /// lineItems
        /// </summary>
        [JsonProperty("lineItems")]
        public List<FulfillmentLineItem> FulfillmentLineItems { get; set; }

        public TrackingInfo TrackingInfo { get; set; }
    }
}