﻿using System;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class MediaItem
    {
        /// <summary>
        /// Media type
        /// </summary>
        [JsonProperty("mediaType")]
        public string MediaType { get; set; }

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

        [JsonProperty("altText")]
        public string AltText { get; set; }

        /// <summary>
        /// Media external URL
        /// </summary>
        [JsonProperty("externalImageUrl")]
        public string ExternalImageUrl { get; set; }
    }
}