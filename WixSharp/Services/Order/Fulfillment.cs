using System.Collections.Generic;
using Newtonsoft.Json;
using WixSharp.Entities;

namespace WixSharp.Services.Order
{
    public class Fulfillment
    {
        /// <summary>
        /// Line items(corresponding to line items in the designated order)
        /// </summary>
        [JsonProperty("lineItems")]
        public List<FulfillmentLineItem> FulfillmentLineItems { get; set; }

        /// <summary>
        /// Tracking information
        /// </summary>
        [JsonProperty("trackingInfo")]
        public TrackingInfo TrackingInfo { get; set; }
    }

    public class CreateFulFillment
    {
        [JsonProperty("fulfillment")] public Fulfillment Fulfillment { get; set; }
    }
}