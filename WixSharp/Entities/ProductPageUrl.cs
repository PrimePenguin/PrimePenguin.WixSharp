using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class ProductPageUrl
    {
        /// <summary>
        /// Base URL. For premium sites, this is the domain. For free sites, this is the site URL (e.g mysite.wixsite.com/mysite)
        /// </summary>
        [JsonProperty("base")]
        public string Base { get; set; }


        /// <summary>
        /// Path to the product page - e.g /product-page/a-product
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }
    }
}