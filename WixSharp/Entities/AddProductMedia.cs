using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class AddProductMedia
    {
        /// <summary>
        /// Media ID (for media items previously saved in Wix Media, the media ID is returned in the Query Product response)
        /// </summary>
        [JsonProperty("mediaId")]
        public string MediaId { get; set; }

        /// <summary>
        /// Media external URL (for new media items)
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Optional - assign this media item to a specific product choice. Note that you may set media items for choices under only one option (e.g., if Colors blue, green, and red have media items, Sizes S, M, and L can't have media items assigned to them). You may clear existing media from choices via the Remove Product Media From Choices endpoint
        /// </summary>
        [JsonProperty("choice")]
        public MediaChoice MediaChoice { get; set; }
    }
}