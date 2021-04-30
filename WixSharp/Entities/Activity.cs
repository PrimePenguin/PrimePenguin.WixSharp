using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Activity
    {
        /// <summary>
        /// History log item type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// History log item author
        /// </summary>
        [JsonProperty("Author")]
        public string Author { get; set; }

        /// <summary>
        /// Comment added to history log item
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// History log item occurrence timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}