using System;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class BillingInfo
    {      
        /// <summary>
        /// Payment method used for this order
        /// </summary>
        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Full billing address
        /// </summary>
        [JsonProperty("address")]
        public Address Address { get; set; }

        /// <summary>
        /// Full billing address
        /// </summary>
        [JsonProperty("paidDate")]
        public string PaidDate { get; set; }

        /// <summary>
        /// Transaction ID from payment provider (e.g., PayPal, Square, Stripe) transaction ID
        /// </summary>
        [JsonProperty("paymentProviderTransactionId")]
        public string PaymentProviderTransactionId { get; set; }

        /// <summary>
        /// Transaction ID from payment gateway(e.g., Wix Payments)
        /// </summary>
        [JsonProperty("paymentGatewayTransactionId")]
        public string PaymentGatewayTransactionId { get; set; }
    }
}