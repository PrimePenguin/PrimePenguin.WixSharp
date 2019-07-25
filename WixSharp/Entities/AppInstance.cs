    using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class AppInstance
    {
        /// <summary>
        /// App instance ID - a unique ID assigned to each app in each site
        /// </summary>
        [JsonProperty("instanceId")]
        public string InstanceId { get; set; }

        /// <summary>
        /// Returns true when the user has a free version of the app(and no package is found). Otherwise false
        /// </summary>
        [JsonProperty("isFree")]
        public bool IsFree { get; set; }

        /// <summary>
        /// App name
        /// </summary>
        [JsonProperty("appName")]
        public string AppName { get; set; }

        /// <summary>
        /// App version installed at this instance
        /// </summary>
        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        /// <summary>
        /// Permissions included in this app's access token
        /// </summary>
        [JsonProperty("permissions")]
        public IEnumerable<string> Permissions { get; set; }

        /// <summary>
        /// Billing info for this app in this site. Returns only if isFree is false
        /// </summary>
        [JsonProperty("billing")]
        public AppBillingInfo Billing { get; set; }
    }
}