using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class SupportedLanguage
    {
        /// <summary>
        /// Language code(ISO 639-1) of the supported language
        /// </summary>
        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// Locale of the supported language
        /// </summary>
        [JsonProperty("locale")]
        public LanguageLocale Locale { get; set; }

        /// <summary>
        /// Language icon of the supported language
        /// </summary>
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Whether the supported language is the site's primary language
        /// </summary>
        [JsonProperty("isPrimary")]
        public bool IsPrimary { get; set; }

        /// <summary>
        /// States how the language will be resolved
        /// </summary>
        [JsonProperty("resolutionMethod")]
        public ResolutionMethod ResolutionMethod { get; set; }
    }
    public enum ResolutionMethod
    {
        QUERY_PARAM = 0,
        SUBDOMAIN = 1,
    }
}