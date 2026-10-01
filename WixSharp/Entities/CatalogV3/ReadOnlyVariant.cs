using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WixSharp.Entities.CatalogV3
{
    /// <summary>
    /// A product variant as returned by the Catalog V3 read-only variants endpoints (Query Variants / Search Variants).
    /// Variants are created and updated through the product itself.
    /// </summary>
    public class ReadOnlyVariant
    {
        /// <summary>
        /// Variant ID. Not unique across products: use it together with <see cref="ReadOnlyVariantProductData.ProductId"/>.
        /// </summary>
        [JsonProperty("variantId")]
        public string VariantId { get; set; }

        [JsonProperty("visible")]
        public bool? Visible { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("optionChoices")]
        public List<OptionChoice> OptionChoices { get; set; }

        [JsonProperty("price")]
        public PriceInfo Price { get; set; }

        [JsonProperty("revenueDetails")]
        public RevenueDetails RevenueDetails { get; set; }

        [JsonProperty("media")]
        public ProductMedia Media { get; set; }

        [JsonProperty("subscriptionPricesInfo")]
        public JObject SubscriptionPricesInfo { get; set; }

        [JsonProperty("inventoryStatus")]
        public InventoryStatus InventoryStatus { get; set; }

        [JsonProperty("physicalProperties")]
        public VariantPhysicalProperties PhysicalProperties { get; set; }

        [JsonProperty("digitalProperties")]
        public VariantDigitalProperties DigitalProperties { get; set; }

        [JsonProperty("productData")]
        public ReadOnlyVariantProductData ProductData { get; set; }
    }

    public class ReadOnlyVariantProductData
    {
        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("productType")]
        public string ProductType { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("visible")]
        public bool? Visible { get; set; }

        [JsonProperty("visibleInPos")]
        public bool? VisibleInPos { get; set; }

        [JsonProperty("mainCategoryId")]
        public string MainCategoryId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("revision")]
        public string Revision { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonProperty("physicalProperties")]
        public PhysicalProperties PhysicalProperties { get; set; }
    }

    /// <summary>
    /// Values for the <c>fields</c> parameter of the read-only variants endpoints.
    /// </summary>
    public static class RequestedVariantFields
    {
        public const string Currency = "CURRENCY";
        /// <summary>Requires the SCOPE.STORES.PRODUCT_READ_ADMIN permission.</summary>
        public const string MerchantData = "MERCHANT_DATA";
        public const string SubscriptionPricesInfo = "SUBSCRIPTION_PRICES_INFO";
        public const string WeightMeasurementUnitInfo = "WEIGHT_MEASUREMENT_UNIT_INFO";
    }
}
