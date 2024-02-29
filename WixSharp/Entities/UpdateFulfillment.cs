using Newtonsoft.Json;
using WixSharp.Services.Order;

namespace WixSharp.Entities
{
    public  class UpdateFulfillment
    {
        [JsonProperty("fulfillmentTrackingInfo")]
        public FulfillmentTrackingInfo FulfillmentTrackingInfo { get; set; }
    }
}
