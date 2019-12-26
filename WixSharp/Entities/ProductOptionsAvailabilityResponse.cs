using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class SelectedVariant
    {
        /// <summary>
        /// Variant price
        /// </summary>
        [JsonProperty("price")]
        public Price Price { get; set; }

        /// <summary>
        /// Variant weight
        /// </summary>
        [JsonProperty("weight")]
        public int Weight { get; set; }

        /// <summary>
        /// Variant SKU (stock keeping unit)
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Whether the product is currently in stock (relevant only when tracking manually)
        /// </summary>
        [JsonProperty("inStock")]
        public bool InStock { get; set; }

        /// <summary>
        /// Whether the variant is visible to customers
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Quantity currently in inventory (relevant only when tracking by inventory)
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; set; }
    }

    public class ProductOption
    {
        [JsonProperty("optionType")]
        public string OptionType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("choices")]
        public List<Choice> Choices { get; set; }
    }

    public class ProductOptionsAvailabilityResponse
    {
        /// <summary>
        /// The variant, given that the all the choices were provided
        /// </summary>
        [JsonProperty("selectedVariant")]
        public SelectedVariant SelectedVariant { get; set; }

        /// <summary>
        /// Media items (images, videos etc) associated with this choice
        /// </summary>
        [JsonProperty("media")]
        public Media Media { get; set; }

        /// <summary>
        /// Options (color, size, etc.) for this product, given the choices provided, with the inventory and visibility fields updated per the provided choices
        /// </summary>
        [JsonProperty("productOptions")]
        public List<ProductOption> ProductOptions { get; set; }

        /// <summary>
        /// Whether all the selected choices result in a visible, in-stock variant
        /// </summary>
        [JsonProperty("availableForPurchase")]
        public bool AvailableForPurchase { get; set; }
    }
}
