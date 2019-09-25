using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class AppliedCoupon
    {
        /// <summary>
        /// Coupon ID
        /// </summary>
        [JsonProperty("couponId")]
        public string CouponId { get; set; }

        /// <summary>
        /// Coupon name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Coupon code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}