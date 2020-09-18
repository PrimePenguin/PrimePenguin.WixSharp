using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Address
    {
        /// <summary>
        /// City name
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Addressee name
        /// </summary>
        [JsonProperty("fullName")]
        public FullName FullName { get; set; }

        /// <summary>
        /// ZIP/postal code
        /// </summary>
        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Country code (2 letters)
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// Tax information(for Brazil only)
        /// </summary>
        [JsonProperty("vatId")]
        public VatId VatId { get; set; }

        /// <summary>
        /// address line
        /// </summary>
        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// State or district
        /// </summary>
        [JsonProperty("subdivision")]
        public string Subdivision { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// main address line
        /// </summary>
        [JsonProperty("addressLine1")]
        public string Address1 { get; set; }

        /// <summary>
        /// Address line 1 (street)
        /// </summary>
        [JsonProperty("street")]
        public Street Street { get; set; }
    }
}