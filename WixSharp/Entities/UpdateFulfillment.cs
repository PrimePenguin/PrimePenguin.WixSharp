using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WixSharp.Entities
{
    public class UpdateFulfillment
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("fulfillment")]
        public FulFillmentUpdate Fulfillment { get; set; }

        [JsonProperty("fieldMask")]
        public object FieldMask { get; set; }
    }

    public class FulFillmentUpdate
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lineItems")]
        public FulfillmentLineItem[] LineItems { get; set; }

        [JsonProperty("status")]
        public FulfillmentStatus Status { get; set; }
    }

    public class FulfillmentLineItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
