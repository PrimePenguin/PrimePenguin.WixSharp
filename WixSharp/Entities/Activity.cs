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
        UNSPECIFIED_ORDER_HISTORY_ITEM_TYPE = 0,
        MERCHANT_COMMENT = 1,
        ORDER_PLACED = 2,
        ORDER_PAID = 3,
        ORDER_FULFILLED = 4,
        ORDER_NOT_FULFILLED = 5,
        DOWNLOAD_LINK_SENT = 6,
        PICKUP_READY_EMAIL_SENT = 7,
        TRACKING_NUMBER_ADDED = 8,
        TRACKING_NUMBER_EDITED = 9,
        TRACKING_LINK_WAS_SET = 10,
        SHIPPING_CONFIRMATION_EMAIL_SENT = 11,
        INVOICE_WAS_SET = 12,
        INVOICE_WAS_REMOVED = 13,
        INVOICE_WAS_SENT = 14
    }
}
