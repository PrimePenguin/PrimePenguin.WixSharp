using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Media
    {
        /// <summary>
        /// Primary media (image, video etc) associated with this product
        /// </summary>
        [JsonProperty("mainMedia")]
        public MainMedia MainMedia { get; set; }

        /// <summary>
        /// Media (images, videoes etc) associated with this product
        /// </summary>
        [JsonProperty("items")]
        public IEnumerable<MainMedia> Items { get; set; }
    }
}