using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class OrderAddress
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("subdivision")]
        public string Subdivision { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postalCode")]
        public long PostalCode { get; set; }

        [JsonProperty("addressLine")]
        public string AddressLine { get; set; }

        [JsonProperty("countryFullname")]
        public string CountryFullname { get; set; }

        [JsonProperty("subdivisionFullname")]
        public string SubdivisionFullname { get; set; }
    }
}
