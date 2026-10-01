using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WixSharp.Entities.Ecom
{
    /// <summary>
    /// Payments and refunds recorded for an order.
    /// </summary>
    public class OrderTransactions
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("payments")]
        public List<Payment> Payments { get; set; }

        [JsonProperty("refunds")]
        public List<Refund> Refunds { get; set; }
    }

    public class Payment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("updatedDate")]
        public DateTimeOffset? UpdatedDate { get; set; }

        [JsonProperty("amount")]
        public Price Amount { get; set; }

        /// <summary>
        /// E.g. "APPROVED", "PENDING", "PENDING_MERCHANT", "CANCELED", "DECLINED", "REFUNDED", "PARTIALLY_REFUNDED", "AUTHORIZED", "VOIDED".
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("refundDisabled")]
        public bool? RefundDisabled { get; set; }

        [JsonProperty("supportReceiptGeneration")]
        public bool? SupportReceiptGeneration { get; set; }

        [JsonProperty("chargeCorrelationId")]
        public string ChargeCorrelationId { get; set; }

        /// <summary>
        /// Set for regular (card, PayPal, offline etc.) payments.
        /// </summary>
        [JsonProperty("regularPaymentDetails")]
        public RegularPaymentDetails RegularPaymentDetails { get; set; }

        [JsonProperty("giftcardPaymentDetails")]
        public GiftCardPaymentDetails GiftcardPaymentDetails { get; set; }

        [JsonProperty("membershipPaymentDetails")]
        public MembershipPaymentDetails MembershipPaymentDetails { get; set; }

        [JsonProperty("cashRounding")]
        public JObject CashRounding { get; set; }
    }

    public class RegularPaymentDetails
    {
        [JsonProperty("creditCardDetails")]
        public CreditCardDetails CreditCardDetails { get; set; }

        /// <summary>
        /// Wix Payments order ID.
        /// </summary>
        [JsonProperty("paymentOrderId")]
        public string PaymentOrderId { get; set; }

        [JsonProperty("gatewayTransactionId")]
        public string GatewayTransactionId { get; set; }

        /// <summary>
        /// Transaction ID in the payment provider's system, e.g. at PayPal or Stripe.
        /// </summary>
        [JsonProperty("providerTransactionId")]
        public string ProviderTransactionId { get; set; }

        /// <summary>
        /// Whether the payment was made offline, e.g. in cash.
        /// </summary>
        [JsonProperty("offlinePayment")]
        public bool? OfflinePayment { get; set; }

        [JsonProperty("savedPaymentMethod")]
        public bool? SavedPaymentMethod { get; set; }

        [JsonProperty("authorizationDetails")]
        public JObject AuthorizationDetails { get; set; }

        [JsonProperty("chargebacks")]
        public List<JObject> Chargebacks { get; set; }

        [JsonProperty("platformFee")]
        public Price PlatformFee { get; set; }

        [JsonProperty("paymentMethodName")]
        public PaymentMethodName PaymentMethodName { get; set; }
    }

    public class CreditCardDetails
    {
        [JsonProperty("lastFourDigits")]
        public string LastFourDigits { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }
    }

    public class PaymentMethodName
    {
        [JsonProperty("buyerLanguageName")]
        public string BuyerLanguageName { get; set; }

        [JsonProperty("siteLanguageName")]
        public string SiteLanguageName { get; set; }

        [JsonProperty("userDefinedName")]
        public JObject UserDefinedName { get; set; }
    }

    public class GiftCardPaymentDetails
    {
        [JsonProperty("giftCardPaymentId")]
        public string GiftCardPaymentId { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("obfuscatedCode")]
        public string ObfuscatedCode { get; set; }
    }

    public class MembershipPaymentDetails
    {
        [JsonProperty("membershipId")]
        public string MembershipId { get; set; }

        [JsonProperty("lineItemId")]
        public string LineItemId { get; set; }

        [JsonProperty("name")]
        public TranslatableString Name { get; set; }

        [JsonProperty("externalTransactionId")]
        public string ExternalTransactionId { get; set; }

        [JsonProperty("providerAppId")]
        public string ProviderAppId { get; set; }
    }

    public class Refund
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("transactions")]
        public List<RefundTransaction> Transactions { get; set; }

        [JsonProperty("details")]
        public RefundDetails Details { get; set; }

        [JsonProperty("summary")]
        public JObject Summary { get; set; }

        [JsonProperty("requestingServiceAppId")]
        public string RequestingServiceAppId { get; set; }
    }

    public class RefundTransaction
    {
        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("amount")]
        public Price Amount { get; set; }

        /// <summary>
        /// "SUCCEEDED", "FAILED", "SCHEDULED" or "STARTED".
        /// </summary>
        [JsonProperty("refundStatus")]
        public string RefundStatus { get; set; }

        [JsonProperty("refundStatusInfo")]
        public RefundStatusInfo RefundStatusInfo { get; set; }

        [JsonProperty("gatewayRefundId")]
        public string GatewayRefundId { get; set; }

        [JsonProperty("providerRefundId")]
        public string ProviderRefundId { get; set; }

        [JsonProperty("externalRefund")]
        public bool? ExternalRefund { get; set; }
    }

    public class RefundStatusInfo
    {
        [JsonProperty("paymentGatewayReasonCode")]
        public string PaymentGatewayReasonCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class RefundDetails
    {
        [JsonProperty("lineItems")]
        public List<LineItemRefund> LineItems { get; set; }

        [JsonProperty("shippingIncluded")]
        public bool? ShippingIncluded { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("additionalFees")]
        public List<AdditionalFeeRefund> AdditionalFees { get; set; }

        [JsonProperty("shipping")]
        public ShippingRefund Shipping { get; set; }
    }

    public class LineItemRefund
    {
        [JsonProperty("lineItemId")]
        public string LineItemId { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }
    }

    public class AdditionalFeeRefund
    {
        [JsonProperty("additionalFeeId")]
        public string AdditionalFeeId { get; set; }

        [JsonProperty("amount")]
        public Price Amount { get; set; }
    }

    public class ShippingRefund
    {
        [JsonProperty("amount")]
        public Price Amount { get; set; }
    }

    internal class OrderTransactionsEnvelope
    {
        [JsonProperty("orderTransactions")]
        public OrderTransactions OrderTransactions { get; set; }
    }

    internal class OrderTransactionsListEnvelope
    {
        [JsonProperty("orderTransactions")]
        public List<OrderTransactions> OrderTransactions { get; set; }
    }
}
