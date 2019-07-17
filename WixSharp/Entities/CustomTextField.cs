using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class CustomTextField
    {
        /// <summary>
        /// Custom text field name
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Custom text field value
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// Whether this text box is mandatory
        /// </summary>
        [JsonProperty("maxLength")]
        public int MaxLength { get; set; }

        /// <summary>
        /// Whether this text box is mandatory
        /// </summary>
        [JsonProperty("mandatory")]
        public string Mandatory { get; set; }
    }
}