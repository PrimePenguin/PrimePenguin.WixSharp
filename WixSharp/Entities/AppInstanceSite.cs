using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class AppInstanceSite
    {
        /// <summary>
        /// Site display name
        /// </summary>
        [JsonProperty("siteDisplayName")]
        public string SiteDisplayName { get; set; }

        /// <summary>
        /// Language code (ISO 639-1) used on this site
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Currency code(ISO 4217) selected to bill customers on this site
        /// </summary>
        [JsonProperty("paymentCurrency")]
        public string PaymentCurrency { get; set; }

        /// <summary>
        /// Multilingual support
        /// </summary>
        [JsonProperty("multilingual")]
        public Multilingual Multilingual { get; set; }
    }
}