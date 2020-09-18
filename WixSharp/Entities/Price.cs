using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Price
    {
        /// <summary>
        /// Product price currency
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Price per unit
        /// </summary>
        [JsonProperty("pricePerUnit")]
        public string PricePerUnit { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        [JsonProperty("price")]
        public string ProductPrice { get; set; }

        /// <summary>
        /// Discounted product price(if no discounted price is set, the product price is returned)
        /// </summary>
        [JsonProperty("discountedPrice")]
        public string DiscountedPrice { get; set; }

        /// <summary>
        /// The product price and discounted price, formatted with the currency
        /// </summary>
        [JsonProperty("formatted")]
        public Formatted Formatted { get; set; }
    }
}