using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Order
    {
        /// <summary>
        /// Whether the order was read by the store owner.
        /// </summary>
        [JsonProperty("read")]
        public bool Read { get; set; }

        /// <summary>
        /// ID displayed in the owner's store (auto generated).
        /// </summary>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        /// Order archive status
        /// </summary>
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// Order ID (auto generated upon order creation)
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Order creation date
        /// </summary>
        [JsonProperty("dateCreated")]
        public string DateCreated { get; set; }

        /// <summary>
        /// Message from the customer(e.g., customization request)
        /// </summary>
        [JsonProperty("buyerNote")]
        public string BuyerNote { get; set; }

        /// <summary>
        /// Currency used for pricing in this store
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Line items ordered
        /// </summary>
        [JsonProperty("lineItems")]
        public IEnumerable<LineItem> LineItems { get; set; }

        /// <summary>
        /// Invoice information
        /// </summary>
        [JsonProperty("invoiceInfo")]
        public InvoiceInfo InvoiceInfo { get; set; }

        /// <summary>
        /// Order payment status
        /// </summary>
        [JsonProperty("paymentStatus")]
        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>
        /// Order shipping information
        /// </summary>
        [JsonProperty("shippingInfo")]
        public ShippingInfo ShippingInfo { get; set; }

        /// <summary>
        /// Order history log containing changes that were made to the order
        /// </summary>
        [JsonProperty("activities")]
        public IEnumerable<Activity> Activities { get; set; }

        /// <summary>
        /// Weight unit used in this store
        /// </summary>
        [JsonProperty("weightUnit")]
        public WeightUnit WeightUnit { get; set; }

        /// <summary>
        /// Order billing information
        /// </summary>
        [JsonProperty("billingInfo")]
        public BillingInfo BillingInfo { get; set; }

        /// <summary>
        /// Customer information
        /// </summary>
        [JsonProperty("buyerInfo")]
        public BuyerInfo BuyerInfo { get; set; }

        /// <summary>
        /// Totals for order's line items
        /// </summary>
        [JsonProperty("totals")]
        public Total Totals { get; set; }

        /// <summary>
        /// Order fulfillment status
        /// </summary>
        [JsonProperty("fulfillmentStatus")]
        public FulfillmentStatus FulfillmentStatus { get; set; }

    }
    public enum PaymentStatus
    {
        UNSPECIFIED_PAYMENT_STATUS ,
        NOT_PAID ,
        PAID
    }

    public enum WeightUnit
    {
        UNSPECIFIED_WEIGHT_UNIT,
        KG ,
        LB 
    }

    public enum FulfillmentStatus
    {
        NOT_FULFILLED,
        FULFILLED
    }

    public class GetOrderResponse
    {   
        /// <summary>
        /// Order object
        /// </summary>
        [JsonProperty("order")]
        public Order Order { get; set; }
    }
}
