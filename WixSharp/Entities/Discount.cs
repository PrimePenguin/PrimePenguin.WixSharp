using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Discount
    {
        /// <summary>
        /// Discount value
        /// </summary>
        [JsonProperty("value")]
        public string DiscountValue { get; set; }

        /// <summary>
        /// Applied coupon
        /// </summary>
        [JsonProperty("appliedCoupon")]
        public AppliedCoupon AppliedCoupon { get; set; }
    }
}