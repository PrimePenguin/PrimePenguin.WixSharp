using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities.Ecom
{
    using WixSharp.Entities.Common;

    public class SearchOrdersResponse
    {
        [JsonProperty("orders")]
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Paging metadata. Pass <c>Cursors.Next</c> as <c>CursorPaging.Cursor</c> to get the next page.
        /// </summary>
        [JsonProperty("metadata")]
        public CursorPagingMetadata Metadata { get; set; }
    }

    public class AddActivitiesResponse
    {
        [JsonProperty("order")]
        public Order Order { get; set; }

        /// <summary>
        /// IDs of the added activities, in the order they were passed.
        /// </summary>
        [JsonProperty("activityIds")]
        public List<string> ActivityIds { get; set; }
    }

    public class OrderCreationSettings
    {
        /// <summary>
        /// Whether any app with the required permissions can edit the order. Set either this or <see cref="EditableByOwnerApps"/>.
        /// </summary>
        [JsonProperty("editableByEveryone")]
        public bool? EditableByEveryone { get; set; }

        /// <summary>
        /// Restricts editing of the order to the listed apps.
        /// </summary>
        [JsonProperty("editableByOwnerApps")]
        public OwnerApps EditableByOwnerApps { get; set; }

        /// <summary>
        /// Condition for the order to be approved, e.g. "DEFAULT", "PAYMENT_RECEIVED", "PAYMENT_METHOD_SAVED".
        /// </summary>
        [JsonProperty("orderApprovalStrategy")]
        public string OrderApprovalStrategy { get; set; }

        [JsonProperty("notifications")]
        public OrderCreateNotifications Notifications { get; set; }
    }

    public class OwnerApps
    {
        [JsonProperty("appIds")]
        public List<string> AppIds { get; set; }
    }

    public class OrderCreateNotifications
    {
        [JsonProperty("sendNotificationToBuyer")]
        public bool? SendNotificationToBuyer { get; set; }

        [JsonProperty("sendNotificationsToBusiness")]
        public bool? SendNotificationsToBusiness { get; set; }
    }

    /// <summary>
    /// Body of the order action webhooks (Order Approved, Order Canceled, Payment Status Updated).
    /// Read it with <c>WixDomainEvent.GetEntity&lt;OrderActionEventBody&gt;()</c>.
    /// </summary>
    public class OrderActionEventBody
    {
        [JsonProperty("order")]
        public Order Order { get; set; }

        /// <summary>
        /// Payment status before the update. Payment Status Updated only.
        /// </summary>
        [JsonProperty("previousPaymentStatus")]
        public string PreviousPaymentStatus { get; set; }

        /// <summary>
        /// Order Canceled only.
        /// </summary>
        [JsonProperty("restockAllItems")]
        public bool? RestockAllItems { get; set; }

        /// <summary>
        /// Order Canceled only.
        /// </summary>
        [JsonProperty("sendOrderCanceledEmail")]
        public bool? SendOrderCanceledEmail { get; set; }

        /// <summary>
        /// Order Canceled only.
        /// </summary>
        [JsonProperty("customMessage")]
        public string CustomMessage { get; set; }
    }

    internal class OrderEnvelope
    {
        [JsonProperty("order")]
        public Order Order { get; set; }
    }
}
