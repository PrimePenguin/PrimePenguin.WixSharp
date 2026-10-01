using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WixSharp.Entities.Common
{
    /// <summary>
    /// A Wix Media image.
    /// </summary>
    public class WixImage
    {
        /// <summary>
        /// WixMedia image ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Original image height.
        /// </summary>
        [JsonProperty("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Original image width.
        /// </summary>
        [JsonProperty("width")]
        public int? Width { get; set; }

        [JsonProperty("altText")]
        public string AltText { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }
    }

    /// <summary>
    /// Custom data added to an entity by apps through Wix extended fields.
    /// </summary>
    public class ExtendedFields
    {
        /// <summary>
        /// Extended field data. Each key is the namespace of the app that created the fields;
        /// each value is an object of that app's field values.
        /// </summary>
        [JsonProperty("namespaces")]
        public JObject Namespaces { get; set; }
    }

    public class TagList
    {
        [JsonProperty("tagIds")]
        public List<string> TagIds { get; set; }
    }
}
