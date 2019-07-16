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
        public int Width { get; set; }

        /// <summary>
        /// Media item height
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public enum MediaType
    {
        UNSPECIFIED_MEDIA_TYPE_ITEM = 0,
        IMAGE = 1
    }
}