using System;
using Newtonsoft.Json;


namespace WixSharp.Services.Order
{
    public class CreateFulFillment
    {
        [JsonProperty("fulfillment")]
        public Fulfillment Fulfillment { get; set; }
    }

    public class Fulfillment
    {
        [JsonProperty("lineItems")]
        public LineItem[] LineItems { get; set; }

        [JsonProperty("trackingInfo")]
        public TrackingInfo TrackingInfo { get; set; }
    }

    public  class LineItem
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }

    public  class TrackingInfo
    {
        [JsonProperty("trackingNumber")]
        public long TrackingNumber { get; set; }

        [JsonProperty("shippingProvider")]
        public string ShippingProvider { get; set; }
    }
}