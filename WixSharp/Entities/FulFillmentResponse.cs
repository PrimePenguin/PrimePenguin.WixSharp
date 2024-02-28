using Newtonsoft.Json;
using System;

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
        public Guid OrderId { get; set; }

        [JsonProperty("fulfillments")]
        public Fulfillment[] Fulfillments { get; set; }
    }

    public  class Fulfillment
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("lineItems")]
        public LineItem[] LineItems { get; set; }

        [JsonProperty("trackingInfo")]
        public TrackingInfo TrackingInfo { get; set; }
    }
}