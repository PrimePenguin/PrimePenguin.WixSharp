using Newtonsoft.Json;

namespace WixSharp.Services.Order
{
    public class CreateFulFillment
    {
        [JsonProperty("fulfillment")]
        public FulfillmentInput Fulfillment { get; set; }
    }

    public  class FulfillmentInput
    {
        [JsonProperty("lineItems")]
        public LineItemInput[] LineItems { get; set; }

        [JsonProperty("trackingInfo")]
        public FulfillmentTrackingInfo TrackingInfo { get; set; }
    }

    public  class LineItemInput
    {
        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }
}