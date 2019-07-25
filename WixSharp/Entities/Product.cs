using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Product
    {
        /// <summary>
        /// Product weight
        /// </summary>
        [JsonProperty("weight")]
        public int Weight { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Product SKU (stock keeping unit). If variants are being managed, this will be empty
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Whether the product is visible to customers
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// A permanent, friendly URL name(generated automatically by the catalog)
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Product ID (generated automatically by the catalog)
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Product’s unique numeric ID(assigned in ascending order) Promarily for sorting and filtering when crawling all products
        /// </summary>
        [JsonProperty("numericId")]
        public string NumericId { get; set; }

        /// <summary>
        /// Whether variants are being managed for this product
        /// </summary>
        [JsonProperty("manageVariants")]
        public bool ManageVariants { get; set; }

        /// <summary>
        /// Inventory item ID - ID referencing the inventory system
        /// </summary>
        [JsonProperty("inventoryItemId")]
        public string InventoryItemId { get; set; }

        /// <summary>
        /// Product inventory status
        /// </summary>
        [JsonProperty("stock")]
        public Stock Stock { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        [JsonProperty("price")]
        public Price Price { get; set; }

        /// <summary>
        /// Product type: physical/digital
        /// </summary>
        [JsonProperty("productType")]
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Optional text marker that store owners can add to specific products (e.g., sale, new arrival)
        /// </summary>
        [JsonProperty("ribbons")]
        public IEnumerable<Ribbon> Ribbons { get; set; }

        /// <summary>
        /// Text box for the customer to add a message to their order (e.g., customization request)
        /// </summary>
        [JsonProperty("customTextFields")]
        public IEnumerable<CustomTextFieldForProduct> CustomTextFields { get; set; }

        /// <summary>
        /// Primary media(image, video etc) associated with this product
        /// </summary>
        [JsonProperty("media")]
        public Media Media { get; set; }

        /// <summary>
        /// Product page URL for this product(generated automatically by the server)
        /// </summary>
        [JsonProperty("productPageUrl")]
        public ProductPageUrl ProductPageUrl { get; set; }

        /// <summary>
        /// Additional text that the store owner can assign to the product(e.g.shipping details, refund policy, etc.)
        /// </summary>
        [JsonProperty("additionalInfoSections")]
        public IEnumerable<AdditionalInfoSection> AdditionalInfoSections { get; set; }

        /// <summary>
        /// Options (color, size etc) for this product
        /// </summary>
        [JsonProperty("productOptions")]
        public IEnumerable<ProductOptions> ProductOptions { get; set; }
    }

    public class ProductResponse
    {      
        /// <summary>
        /// Product Response
        /// </summary>
        [JsonProperty("product")]
        public Product Product { get; set; }
    }

    public enum ProductType
    {
        unspecified_product_type,
        physical,
        digital
    }
}
