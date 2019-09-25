using Newtonsoft.Json;

namespace WixSharp.Services.Order
{
    public class FulfillmentLineItem
    {
        /// <summary>
        /// Line item ID(mirrors the line item index of the order)
        /// </summary>
        [JsonProperty("index")]
        public int Index { get; set; }

        /// <summary>
        /// Line item quantity.On creation, if this param isn't passed, the new fulfillment will automatically include all items of this line item that have not already been linked to a fulfillment). If the order does not have the requested quantity of line items quantity available to add to this fulfillment, the fulfillment will not be created and an error will be returned. (This property will always have a value when returned)
        /// </summary>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }
    }
}