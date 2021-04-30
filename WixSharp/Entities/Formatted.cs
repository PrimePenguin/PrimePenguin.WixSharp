using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Formatted
    {
        /// <summary>
        /// Product price formatted with the currency
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }

        /// <summary>
        /// Discounted product price formatted with the currency (if no discounted price is set, the product formatted price is returned)
        /// </summary>
        [JsonProperty("discountedPrice")]
        public string DiscountedPrice { get; set; }

        /// <summary>
        /// Price per unit
        /// </summary>
        [JsonProperty("pricePerUnit")]
        public string PricePerUnit { get; set; }

    }
}