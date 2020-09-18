using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Discount
    {
        /// <summary>
        /// Applied coupon
        /// </summary>
        [JsonProperty("appliedCoupon")]
        public AppliedCoupon AppliedCoupon { get; set; }
    }
}