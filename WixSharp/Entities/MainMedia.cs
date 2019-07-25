using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class MainMedia
    {
        /// <summary>
        /// Media item type (image, video, etc.)
        /// </summary>
        [JsonProperty("mediaType")]
        public MediaItemType MediaType { get; set; }

        /// <summary>
        /// Image data(URL, size)
        /// </summary>
        [JsonProperty("image")]
        public Image Image { get; set; }

        /// <summary>
        /// thumbnail
        /// </summary>
        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        /// <summary></summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Video data (URL, size)
        /// </summary>
        [JsonProperty("video")]
        public Video Video { get; set; }

        /// <summary>
        /// Media item title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public enum MediaItemType
    {
        unspecified_media_item_type,
        image,
        video,
        audio,
        document,
        zip
    }
}