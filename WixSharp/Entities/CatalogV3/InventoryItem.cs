using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WixSharp.Entities.CatalogV3
{
    using WixSharp.Entities.Common;

    /// <summary>
    /// Stock of one product variant at one location in a Wix Stores Catalog V3.
    /// </summary>
    public class InventoryItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Revision number. The current revision must be passed when updating the inventory item.
        /// </summary>
        [JsonProperty("revision")]
        public string Revision { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("updatedDate")]
        public DateTimeOffset? UpdatedDate { get; set; }

        [JsonProperty("variantId")]
        public string VariantId { get; set; }

        /// <summary>
        /// Stores location ID. The store's default location is used if not specified on create.
        /// </summary>
        [JsonProperty("locationId")]
        public string LocationId { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        /// <summary>
        /// Tracking method: in stock / out of stock, without a quantity limit. Set either this or <see cref="Quantity"/>.
        /// </summary>
        [JsonProperty("inStock")]
        public bool? InStock { get; set; }

        /// <summary>
        /// Tracking method: quantity left in inventory. Can be negative. Set either this or <see cref="InStock"/>.
        /// </summary>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Whether quantity is being tracked. Read-only; derived from whether <see cref="Quantity"/> or <see cref="InStock"/> is set.
        /// </summary>
        [JsonProperty("trackQuantity")]
        public bool? TrackQuantity { get; set; }

        /// <summary>
        /// "IN_STOCK", "OUT_OF_STOCK" or "PREORDER". Read-only.
        /// </summary>
        [JsonProperty("availabilityStatus")]
        public string AvailabilityStatus { get; set; }

        [JsonProperty("preorderInfo")]
        public PreorderInfo PreorderInfo { get; set; }

        /// <summary>
        /// Associated product and variant details. Read-only.
        /// </summary>
        [JsonProperty("product")]
        public InventoryItemProduct Product { get; set; }

        [JsonProperty("extendedFields")]
        public ExtendedFields ExtendedFields { get; set; }
    }

    public class PreorderInfo
    {
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Message displayed to customers when the item is out of stock and preorder is enabled.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Maximum number of items that can be preordered after stock reaches zero. Only for quantity-tracked items.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Number of times this item has been preordered. Read-only.
        /// </summary>
        [JsonProperty("counter")]
        public int? Counter { get; set; }

        /// <summary>
        /// Remaining quantity available for preorder. Read-only.
        /// </summary>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }
    }

    public class InventoryItemProduct
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("directCategoryIds")]
        public List<string> DirectCategoryIds { get; set; }

        [JsonProperty("variantName")]
        public string VariantName { get; set; }

        [JsonProperty("variantSku")]
        public string VariantSku { get; set; }

        [JsonProperty("variantVisible")]
        public bool? VariantVisible { get; set; }
    }

    public class InventoryIncrementData
    {
        [JsonProperty("inventoryItemId")]
        public string InventoryItemId { get; set; }

        [JsonProperty("incrementBy")]
        public int IncrementBy { get; set; }
    }

    public class InventoryDecrementData
    {
        [JsonProperty("inventoryItemId")]
        public string InventoryItemId { get; set; }

        [JsonProperty("decrementBy")]
        public int DecrementBy { get; set; }

        /// <summary>
        /// Whether the decrement is part of a purchase that includes preordered items.
        /// </summary>
        [JsonProperty("preorderRequest")]
        public bool? PreorderRequest { get; set; }
    }

    public class VariantLocationIncrementData
    {
        [JsonProperty("variantId")]
        public string VariantId { get; set; }

        /// <summary>
        /// Location ID. The default location is used when omitted.
        /// </summary>
        [JsonProperty("locationId")]
        public string LocationId { get; set; }

        [JsonProperty("incrementBy")]
        public int IncrementBy { get; set; }
    }

    public class VariantLocationDecrementData
    {
        [JsonProperty("variantId")]
        public string VariantId { get; set; }

        /// <summary>
        /// Location ID. The default location is used when omitted.
        /// </summary>
        [JsonProperty("locationId")]
        public string LocationId { get; set; }

        [JsonProperty("decrementBy")]
        public int DecrementBy { get; set; }

        [JsonProperty("preorderRequest")]
        public bool? PreorderRequest { get; set; }
    }

    public class QueryInventoryItemsResponse
    {
        [JsonProperty("inventoryItems")]
        public List<InventoryItem> InventoryItems { get; set; }

        [JsonProperty("pagingMetadata")]
        public CursorPagingMetadata PagingMetadata { get; set; }
    }

    public class SearchInventoryItemsResponse : QueryInventoryItemsResponse
    {
        [JsonProperty("aggregationData")]
        public JObject AggregationData { get; set; }
    }

    /// <summary>
    /// Body of the Inventory Item Updated With Reason webhook.
    /// Read it with <c>WixDomainEvent.GetEntity&lt;InventoryItemUpdatedWithReasonBody&gt;()</c>.
    /// </summary>
    public class InventoryItemUpdatedWithReasonBody
    {
        [JsonProperty("currentEntity")]
        public InventoryItem CurrentEntity { get; set; }

        /// <summary>
        /// See <see cref="InventoryChangeReasons"/>.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// ID of the app that updated the inventory item.
        /// </summary>
        [JsonProperty("appId")]
        public string AppId { get; set; }
    }

    /// <summary>
    /// Values for the <c>reason</c> parameter of inventory update, increment and decrement endpoints.
    /// </summary>
    public static class InventoryChangeReasons
    {
        public const string Order = "ORDER";
        public const string Manual = "MANUAL";
        public const string RevertInventoryChange = "REVERT_INVENTORY_CHANGE";
    }

    internal class InventoryItemEnvelope
    {
        [JsonProperty("inventoryItem")]
        public InventoryItem InventoryItem { get; set; }
    }
}
