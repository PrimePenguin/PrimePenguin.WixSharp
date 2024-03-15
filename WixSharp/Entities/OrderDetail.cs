using Newtonsoft.Json;
using System;

namespace WixSharp.Entities
{
    public class OrderDetail
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
        public OrderLineItem[] LineItems { get; set; }

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
        public OrderActivity[] Activities { get; set; }

        [JsonProperty("attributionSource")]
        public string AttributionSource { get; set; }

        [JsonProperty("createdBy")]
        public CreatedBy CreatedBy { get; set; }

        [JsonProperty("channelInfo")]
        public OrderChannelInfo ChannelInfo { get; set; }

        [JsonProperty("seenByAHuman")]
        public bool SeenByAHuman { get; set; }

        [JsonProperty("checkoutId")]
        public string CheckoutId { get; set; }

        [JsonProperty("customFields")]
        public object[] CustomFields { get; set; }

        [JsonProperty("cartId")]
        public string CartId { get; set; }

        [JsonProperty("payNow")]
        public PayNow PayNow { get; set; }

        [JsonProperty("balanceSummary")]
        public BalanceSummary BalanceSummary { get; set; }

        [JsonProperty("additionalFees")]
        public object[] AdditionalFees { get; set; }
    }
}
