using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Activity
    {
        /// <summary>
        /// History log item type
        /// </summary>
        [JsonProperty("type")]
        public ActivityType Type { get; set; }

        /// <summary>
        /// History log item author
        /// </summary>
        [JsonProperty("Author")]
        public string Author { get; set; }

        /// <summary>
        /// Comment added to history log item
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// History log item occurrence timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

    }

    public enum ActivityType
    {
        UNSPECIFIED_ORDER_HISTORY_ITEM_TYPE,
        MERCHANT_COMMENT,
        ORDER_PLACED,
        ORDER_PAID,
        ORDER_FULFILLED,
        ORDER_NOT_FULFILLED,
        DOWNLOAD_LINK_SENT,
        PICKUP_READY_EMAIL_SENT,
        TRACKING_NUMBER_ADDED,
        TRACKING_NUMBER_EDITED,
        TRACKING_LINK_WAS_SET,
        SHIPPING_CONFIRMATION_EMAIL_SENT,
        INVOICE_WAS_SET,
        INVOICE_WAS_REMOVED,
        INVOICE_WAS_SENT
    }
}
