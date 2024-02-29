using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WixSharp.Entities
{
    public class OrderListItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("updatedDate")]
        public DateTimeOffset UpdatedDate { get; set; }

        [JsonProperty("lineItems")]
        public List<OrderLineItem> LineItems { get; set; }

        [JsonProperty("buyerInfo")]
        public OrderBuyerInfo BuyerInfo { get; set; }

        [JsonProperty("paymentStatus")]
        public string PaymentStatus { get; set; }

        [JsonProperty("fulfillmentStatus")]
        public string FulfillmentStatus { get; set; }

        [JsonProperty("buyerLanguage")]
        public string BuyerLanguage { get; set; }

        [JsonProperty("weightUnit")]
        public string WeightUnit { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("taxIncludedInPrices")]
        public bool TaxIncludedInPrices { get; set; }

        [JsonProperty("priceSummary")]
        public PayNow PriceSummary { get; set; }

        [JsonProperty("billingInfo")]
        public OrderBillingInfo BillingInfo { get; set; }

        [JsonProperty("shippingInfo")]
        public OrderShippingInfo ShippingInfo { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("taxSummary")]
        public TaxSummary TaxSummary { get; set; }

        [JsonProperty("appliedDiscounts")]
        public AppliedDiscount[] AppliedDiscounts { get; set; }

        [JsonProperty("activities")]
        public List<Activity> Activities { get; set; }

        [JsonProperty("attributionSource")]
        public string AttributionSource { get; set; }

        [JsonProperty("createdBy")]
        public CreatedBy CreatedBy { get; set; }

        [JsonProperty("channelInfo")]
        public ChannelInfo ChannelInfo { get; set; }

        [JsonProperty("seenByAHuman")]
        public bool SeenByAHuman { get; set; }

        [JsonProperty("customFields")]
        public object[] CustomFields { get; set; }

        [JsonProperty("cartId")]
        public string CartId { get; set; }

        [JsonProperty("balanceSummary")]
        public BalanceSummary BalanceSummary { get; set; }

        [JsonProperty("additionalFees")]
        public object[] AdditionalFees { get; set; }

        [JsonProperty("checkoutId", NullValueHandling = NullValueHandling.Ignore)]
        public string? CheckoutId { get; set; }

        [JsonProperty("payNow", NullValueHandling = NullValueHandling.Ignore)]
        public PayNow PayNow { get; set; }
    }

}
