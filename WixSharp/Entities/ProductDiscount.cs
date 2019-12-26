using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class ProductDiscount
    {
        /// <summary>
        ///  One of UNDEFINED, NONE, AMOUNT, PERCENT.Discount type: amount / percent
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Discount value
        /// </summary>
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}