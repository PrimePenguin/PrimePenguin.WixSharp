using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Total
    {
        /// <summary>
        /// Total items weight
        /// </summary>
        [JsonProperty("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// Total number of line items
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// Total tax
        /// </summary>
        [JsonProperty("tax")]
        public string Tax { get; set; }

        /// <summary>
        /// Total price charged
        /// </summary>
        [JsonProperty("total")]
        public string TotalPrice { get; set; }

        /// <summary>
        /// Subtotal of all the line items, before tax
        /// </summary>
        [JsonProperty("subtotal")]
        public string Subtotal { get; set; }

        /// <summary>
        /// Total calculated discount value, according to order.discount
        /// </summary>
        [JsonProperty("discount")]
        public string Discount { get; set; }

        /// <summary>
        /// Total shipping price, including tax
        /// </summary>
        [JsonProperty("shipping")]
        public string Shipping { get; set; }
    }
}