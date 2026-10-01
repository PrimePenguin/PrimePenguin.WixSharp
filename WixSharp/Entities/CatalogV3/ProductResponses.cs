using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WixSharp.Entities.CatalogV3
{
    using WixSharp.Entities.Common;

    public class QueryProductsResponse
    {
        /// <summary>
        /// Products. Query and Search don't return variants; use the read-only variants endpoints for variant data.
        /// </summary>
        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("pagingMetadata")]
        public CursorPagingMetadata PagingMetadata { get; set; }
    }

    public class SearchProductsResponse : QueryProductsResponse
    {
        [JsonProperty("aggregationData")]
        public JObject AggregationData { get; set; }
    }

    public class ProductWithInventoryResponse
    {
        [JsonProperty("product")]
        public Product Product { get; set; }

        /// <summary>
        /// Results of creating or updating the inventory items of the product's variants.
        /// </summary>
        [JsonProperty("inventoryResults")]
        public InventoryItemResults InventoryResults { get; set; }
    }

    public class InventoryItemResults : BulkResponse<InventoryItem>
    {
        [JsonProperty("error")]
        public ApplicationError Error { get; set; }
    }

    public class BulkProductsWithInventoryResponse
    {
        [JsonProperty("productResults")]
        public BulkResponse<Product> ProductResults { get; set; }

        [JsonProperty("inventoryResults")]
        public InventoryItemResults InventoryResults { get; set; }
    }

    public class GetAllProductsCategoryResponse
    {
        /// <summary>
        /// ID of the "All Products" category, which contains every product in the store.
        /// </summary>
        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        [JsonProperty("treeReference")]
        public TreeReference TreeReference { get; set; }
    }

    /// <summary>
    /// A product ID with its current revision, used by the info section bulk endpoints.
    /// </summary>
    public class ProductIdWithRevision
    {
        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("revision")]
        public string Revision { get; set; }
    }

    /// <summary>
    /// Price and cost adjustments for Bulk Adjust Product Variants By Filter. Set only the fields to adjust.
    /// </summary>
    public class VariantPriceAdjustment
    {
        /// <summary>
        /// Adjustment of the selling price.
        /// </summary>
        [JsonProperty("actualPrice")]
        public AdjustValue ActualPrice { get; set; }

        /// <summary>
        /// Adjustment of the compare-at (original) price.
        /// </summary>
        [JsonProperty("compareAtPrice")]
        public AdjustValue CompareAtPrice { get; set; }

        /// <summary>
        /// Sets the actual price by applying this discount to the compare-at price, ignoring the old actual price
        /// (e.g. compare-at $100 with a 10% discount sets the actual price to $90). If there's no compare-at price,
        /// the current actual price becomes the compare-at price first. Values can't be negative.
        /// </summary>
        [JsonProperty("compareAtPriceDiscount")]
        public AdjustValue CompareAtPriceDiscount { get; set; }

        /// <summary>
        /// Adjustment of the merchant's cost.
        /// </summary>
        [JsonProperty("cost")]
        public AdjustValue Cost { get; set; }

        /// <summary>
        /// Rounding of the calculated prices. See <see cref="PriceRoundingStrategies"/>.
        /// </summary>
        [JsonProperty("rounding")]
        public string Rounding { get; set; }
    }

    /// <summary>
    /// A relative change to a value. Set either <see cref="Amount"/> or <see cref="Percentage"/>.
    /// </summary>
    public class AdjustValue
    {
        /// <summary>
        /// Decimal amount to add, e.g. "5" or "-2.50".
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Percentage to add, e.g. 10 or -15.
        /// </summary>
        [JsonProperty("percentage")]
        public int? Percentage { get; set; }
    }

    public static class PriceRoundingStrategies
    {
        /// <summary>Calculated prices are saved without rounding, e.g. $3.5555 stays $3.5555.</summary>
        public const string NoRounding = "NO_ROUNDING";
        /// <summary>Calculated prices are rounded to the currency's precision, e.g. $3.5555 becomes $3.56.</summary>
        public const string CurrencyPrecision = "CURRENCY_PRECISION";
        /// <summary>Calculated prices are rounded to the nearest whole number, e.g. $3.5555 becomes $4.</summary>
        public const string NearestWholeNumber = "NEAREST_WHOLE_NUMBER";
    }

    public class QueryVariantsResponse
    {
        [JsonProperty("variants")]
        public List<ReadOnlyVariant> Variants { get; set; }

        [JsonProperty("pagingMetadata")]
        public CursorPagingMetadata PagingMetadata { get; set; }
    }

    public class SearchVariantsResponse : QueryVariantsResponse
    {
        [JsonProperty("aggregationData")]
        public JObject AggregationData { get; set; }
    }

    internal class ProductEnvelope
    {
        [JsonProperty("product")]
        public Product Product { get; set; }
    }

    internal class CountEnvelope
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
