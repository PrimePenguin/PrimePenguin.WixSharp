using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class VatId
    {
        /// <summary>
        /// Customer's tax ID
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// tax type
        /// </summary>
        [JsonProperty("type")]
        public VatType Type { get; set; }

    }
    public enum VatType
    {
        UNSPECIFIED_TAX_TYPE = 0,
        CPF = 1,
        CNPJ = 2
    }
}