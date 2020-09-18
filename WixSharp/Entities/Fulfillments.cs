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
        /// Fulfillment creation date and time.
        /// </summary>
        [JsonProperty("dateCreated")]
        public string DateCreated { get; set; }

        /// <summary>
        ///  Information about the line items in the fulfilled order.
        /// </summary>
        [JsonProperty("lineItems")]
        public List<FulfillmentLineItem> FulfillmentLineItems { get; set; }

        /// <summary>
        /// Tracking Info
        /// </summary>
        [JsonProperty("trackingInfo")]
        public TrackingInfo TrackingInfo { get; set; }
    }
}