using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WixSharp.Entities
{
    public  class FulFillmentResponse
    {
        [JsonProperty("orderWithFulfillments")]
        public OrderWithFulfillments OrderWithFulfillments { get; set; }
    }

    public  class OrderWithFulfillments
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("fulfillments")]
        public List<Fulfillment> Fulfillments { get; set; }
    }

    public  class Fulfillment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("lineItems")]
        public List<FulFillmentLineItem> LineItems { get; set; }

        [JsonProperty("trackingInfo")]
        public TrackingInfo TrackingInfo { get; set; }
    }

    public class FulFillmentLineItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }

}