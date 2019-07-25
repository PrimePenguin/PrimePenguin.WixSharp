using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Multilingual
    {
        /// <summary>
        /// Returns true when multiple languages are supported.Otherwise false. When true, an array of supported languages is displayed
        /// </summary>
        [JsonProperty("isMultiLingual")]
        public bool IsMultiLingual { get; set; }

        /// <summary>
        /// An array of supported languages. Displayed only when isMultiLingual is true
        /// </summary>
        [JsonProperty("supportedLanguages")]
        public IEnumerable<SupportedLanguage> SupportedLanguages { get; set; }
    }
}