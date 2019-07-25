using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class LanguageLocale
    {
        /// <summary>
        /// Language code(ISO 639-1) of the supported language
        /// </summary>
        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// Country code(ISO 3166-1) for this site
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}