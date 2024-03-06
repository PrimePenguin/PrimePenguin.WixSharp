using Newtonsoft.Json;
using System;

namespace WixSharp.Services.Order
{
    public  class CreateFulFillment
    {
        [JsonProperty("fulfillment")]
        public FulfillmentInput Fulfillment { get; set; }
    }

    public  class FulfillmentInput
    {
        [JsonProperty("lineItems")]
        public LineItemInput[] LineItems { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("trackingInfo")]
        public TrackingInfoInput TrackingInfo { get; set; }
    }

    public  class LineItemInput
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }

    public  class TrackingInfoInput
    {
        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonProperty("shippingProvider")]
        public string ShippingProvider { get; set; }
    }
}