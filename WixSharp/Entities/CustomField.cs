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
        /// Title for the custom field
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Translation of the title (as displayed during the checkout process)
        /// </summary>
        [JsonProperty("translatedTitle")]
        public string TranslatedTitle { get; set; }
    }
}