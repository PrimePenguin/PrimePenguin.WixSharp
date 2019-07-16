using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class AdditionalInfoSection
    {
        /// <summary>
        /// Product info section title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Product info section description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}