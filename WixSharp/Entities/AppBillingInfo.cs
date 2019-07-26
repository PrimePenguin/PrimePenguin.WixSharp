using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class AppBillingInfo
    {
        /// <summary>
        /// Name of the paid package the user has paid for
        /// </summary>
        [JsonProperty("packageName")]
        public string PackageName { get; set; }

        /// <summary>
        /// Billing cycle type for the user's paid package - monthly/yearly
        /// </summary>
        [JsonProperty("billingCycle")]
        public BillingCycle BillingCycle { get; set; }
    }
    public enum BillingCycle
    {
        NONE_CYCLE,
        MONTHLY,
        YEARLY
    }
}