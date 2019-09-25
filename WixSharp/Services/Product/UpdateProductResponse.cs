using Newtonsoft.Json;

namespace WixSharp.Services.Product
{
    public class UpdateProductResponse
    {
        [JsonProperty("product")]
        public Entities.Product Product { get; set; }
    }
}