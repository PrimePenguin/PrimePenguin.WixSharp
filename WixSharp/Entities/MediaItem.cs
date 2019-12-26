using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class MediaItem
    {
        /// <summary>
        /// Media type
        /// </summary>
        [JsonProperty("mediaType")]
        public MediaType MediaType { get; set; }

        /// <summary>
        /// Media URL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Media URL
        /// </summary>
        [JsonProperty("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Media item height
        /// </summary>
        [JsonProperty("height")]
        public int? Height { get; set; }

        [JsonProperty("altText")] public string AltText { get; set; }

        /// <summary>
        /// Media external URL
        /// </summary>
        [JsonProperty("externalImageUrl")]
        public string ExternalImageUrl { get; set; }

        /// <summary>
        /// Media ID(for media items previously saved in Wix Media)
        /// </summary>
        [JsonProperty("mediaId")]
        public string MediaId { get; set; }
    }

    public enum MediaType
    {
        UNSPECIFIED_MEDIA_TYPE_ITEM,
        IMAGE
    }
}