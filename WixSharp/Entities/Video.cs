using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Video
    {
        /// <summary>
        /// Data (URL, size) about each resolution for which this video is available
        /// </summary>
        [JsonProperty("files")]
        public IEnumerable<Image> Files { get; set; }
    }
}