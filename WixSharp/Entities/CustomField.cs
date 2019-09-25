using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class CustomField
    {
        /// <summary>
        /// Free text that the customer entered in the custom field during the checkout process
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// Title that was entered by the store owner in the checkout settings for her main language
        /// </summary>
        [JsonProperty("untranslatedTitle")]
        public string UntranslatedTitle { get; set; }

        /// <summary>
        /// Translation of the title (as displayed during the checkout process)
        /// </summary>
        [JsonProperty("translatedTitle")]
        public string TranslatedTitle { get; set; }
    }
}