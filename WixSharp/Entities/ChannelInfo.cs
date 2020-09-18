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
        public Type Type { get; set; }

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

    public enum Type    
    {
        UNSPECIFIED,
        WEB,
        POS, 
        EBAY, 
        AMAZON,
        OTHER_PLATFORM,
        WIX_APP_STORE
    }
}
