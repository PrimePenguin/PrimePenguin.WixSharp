using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WixSharp.Entities
{
    public class CustomTextFieldForLineItem
    {
        /// <summary>
        /// Custom text field name
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Custom text field value
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// Whether this text box is mandatory
        /// </summary>
        [JsonProperty("maxLength")]
        public int MaxLength { get; set; }

        /// <summary>
        /// Whether this text box is mandatory
        /// </summary>
        [JsonProperty("mandatory")]
        public bool Mandatory { get; set; }
    }
}
