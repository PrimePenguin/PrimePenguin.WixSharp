using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class QueryVariantsResponse
    {
        [JsonProperty("totalResults")] public int TotalResults { get; set; }

        [JsonProperty("metadata")] public MetaData Metadata { get; set; }

        /// <summary>
        /// All variants
        /// </summary>
        [JsonProperty("variants")]
        public IEnumerable<Variants> Variants { get; set; }
    }

    public class Variants
    {
        /// <summary>
        /// Requested Variant ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Specific choices within a selection, as option-choice key-value pairs
        /// </summary>
        [JsonProperty("choices")]
        public IDictionary<string, string> Choices { get; set; }

        /// <summary>
        /// All variants
        /// </summary>
        [JsonProperty("variant")]
        public Variant Variant { get; set; }

        public VariantWithInventory VariantInventory { get; set; }
    }

    public class Variant
    {
        /// <summary>
        /// Variant price
        /// </summary>
        [JsonProperty("priceData")]
        public VariantPriceData VariantPriceData { get; set; }

        /// <summary>
        /// Variant Weight
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }

        /// <summary>
        /// Variant SKU (stock keeping unit
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Whether the variant is visible to customers
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Variant price data, converted to currency requested in header
        /// </summary>
        [JsonProperty("convertedPriceData")]
        public ConvertedPriceData ConvertedPriceData { get; set; }
    }

    public class VariantPriceData
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