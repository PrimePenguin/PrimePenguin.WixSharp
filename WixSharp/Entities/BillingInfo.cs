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
        /// External transaction ID
        /// </summary>
        [JsonProperty("externalTransactionId")]
        public string ExternalTransactionId { get; set; }

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
    }
}