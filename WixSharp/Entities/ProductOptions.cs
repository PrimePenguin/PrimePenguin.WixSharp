﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class ProductOptions
    {
        /// <summary>
        /// Option type - color or other(drop down)
        /// </summary>
        [JsonProperty("optionType")]
        public string OptionType { get; set; }

        /// <summary>
        /// Option name(e.g., color, size)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Choices available for this option
        /// </summary>
        [JsonProperty("choices")]
        public IEnumerable<Choice> Choices { get; set; }
    }
}