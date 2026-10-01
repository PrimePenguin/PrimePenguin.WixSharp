using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WixSharp.Entities.Ecom
{
    using WixSharp.Entities.Common;

    /// <summary>
    /// A fulfillment: a subset of an order's line items that are shipped or delivered together.
    /// </summary>
    public class Fulfillment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("lineItems")]
        public List<FulfillmentLineItem> LineItems { get; set; }

        /// <summary>
        /// Tracking info for shipped items. Set either this or <see cref="CustomInfo"/>.
        /// </summary>
        [JsonProperty("trackingInfo")]
        public FulfillmentTrackingInfo TrackingInfo { get; set; }

        [JsonProperty("customInfo")]
        public CustomFulfillmentInfo CustomInfo { get; set; }

        /// <summary>
        /// See <see cref="FulfillmentStatuses"/>. Values are case-sensitive; any other value is rejected.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Whether the fulfillment is complete. When <c>false</c>, its line items don't count as fulfilled
        /// in the order's fulfillment status. When not set, they count as fulfilled.
        /// </summary>
        [JsonProperty("completed")]
        public bool? Completed { get; set; }
    }

    public class FulfillmentLineItem
    {
        /// <summary>
        /// ID of the order line item.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Quantity fulfilled. Defaults to the line item's remaining unfulfilled quantity.
        /// </summary>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }
    }

    public class FulfillmentTrackingInfo
    {
        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Predefined providers ("fedex", "ups", "usps", "dhl", "canadaPost", "hermes") get <see cref="TrackingLink"/> generated
        /// automatically. Any other value is a custom provider, for which you must pass the tracking link yourself.
        /// </summary>
        [JsonProperty("shippingProvider")]
        public string ShippingProvider { get; set; }

        /// <summary>
        /// Tracking link. Autofilled for predefined providers, otherwise provided on creation.
        /// </summary>
        [JsonProperty("trackingLink")]
        public string TrackingLink { get; set; }
    }

    public class CustomFulfillmentInfo
    {
        [JsonProperty("fieldsData")]
        public JObject FieldsData { get; set; }
    }

    public class OrderWithFulfillments
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("fulfillments")]
        public List<Fulfillment> Fulfillments { get; set; }
    }

    public class FulfillmentResponse
    {
        [JsonProperty("orderWithFulfillments")]
        public OrderWithFulfillments OrderWithFulfillments { get; set; }

        /// <summary>
        /// ID of the created fulfillment. Returned only by Create Fulfillment.
        /// </summary>
        [JsonProperty("fulfillmentId")]
        public string FulfillmentId { get; set; }
    }

    public class ListFulfillmentsForMultipleOrdersResponse
    {
        [JsonProperty("ordersWithFulfillments")]
        public List<OrderWithFulfillments> OrdersWithFulfillments { get; set; }
    }

    public class BulkCreateFulfillmentsResponse
    {
        [JsonProperty("results")]
        public List<BulkOrderFulfillmentsResult> Results { get; set; }

        [JsonProperty("bulkActionMetadata")]
        public BulkActionMetadata BulkActionMetadata { get; set; }
    }

    public class BulkOrderFulfillmentsResult
    {
        [JsonProperty("itemMetadata")]
        public ItemMetadata ItemMetadata { get; set; }

        [JsonProperty("ordersWithFulfillments")]
        public OrderWithFulfillments OrdersWithFulfillments { get; set; }
    }

    public static class FulfillmentStatuses
    {
        public const string Pending = "Pending";
        public const string Accepted = "Accepted";
        public const string Ready = "Ready";
        public const string InDelivery = "In_Delivery";
        public const string Fulfilled = "Fulfilled";
    }
}
