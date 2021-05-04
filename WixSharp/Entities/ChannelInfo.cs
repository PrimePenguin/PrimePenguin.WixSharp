using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class ChannelInfo
    {
        /// <summary>
        /// One of UNSPECIFIED, WEB, POS, EBAY, AMAZON. Sales channel that submitted the order
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Reference to an order ID from an external system, as defined in channelInfo (e.g., eBay or Amazon)
        /// </summary>
        [JsonProperty("externalOrderId")]
        public string ExternalOrderId { get; set; }

        /// <summary>
        /// URL to the order in the external system, as defined in channelInfo (e.g., eBay or Amazon)
        /// </summary>
        [JsonProperty("externalOrderUrl")]
        public string ExternalOrderUrl { get; set; }
    }
}
