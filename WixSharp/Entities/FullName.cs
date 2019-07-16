using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class FullName
    {
        /// <summary>
        /// Customer's first name
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Customer's last name
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }
}