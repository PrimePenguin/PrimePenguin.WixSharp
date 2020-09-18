using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Product
    {
        public Product()
        {
            Variants = new List<Variants>();
        }

        /// <summary>
        /// Product inventory status
        /// </summary>
        [JsonProperty("stock")]
        public Stock Stock { get; set; }

        /// <summary>
        /// Product weight (if variant management is enabled, weight will be set per variant, and this field will be empty).
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }

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
        /// A list of all collection IDs that this product is included in (writable via the Catalog > Collection APIs)
        /// </summary>  
        [JsonProperty("collectionIds")]
        public List<string> CollectionIds { get; set; }

        /// <summary>
        /// Whether the product is visible to customers
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Date and time the product was last updated.
        /// </summary>
        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// Options (color, size etc) for this product
        /// </summary>
        [JsonProperty("productOptions")]
        public IEnumerable<ProductOptions> ProductOptions { get; set; }

        /// <summary>
        /// A permanent, friendly URL name(generated automatically by the catalog)
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Product ID (generated automatically by the catalog)
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Product type: physical/digital
        /// </summary>
        [JsonProperty("productType")]
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Price Data
        /// </summary>
        [JsonProperty("priceData")]
        public ProductPriceData ProductPriceData { get; set; }

        /// <summary>
        /// Optional text marker that store owners can add to specific products (e.g., sale, new arrival)
        /// </summary>
        [JsonProperty("ribbons")]
        public IEnumerable<Ribbon> Ribbons { get; set; }

        /// <summary>
        /// pricePerUnitData
        /// </summary>
        [JsonProperty("pricePerUnitData")]
        public PricePerUnitData PricePerUnitData { get; set; }

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
        /// Product’s unique numeric ID(assigned in ascending order) Primarily for sorting and filtering when crawling all products
        /// </summary>
        [JsonProperty("numericId")]
        public string NumericId { get; set; }

        /// <summary>
        /// Whether variants are being managed for this product - enables unique SKU, price and weight per variant. Also affects inventory data.
        /// </summary>
        [JsonProperty("manageVariants")]
        public bool ManageVariants { get; set; }

        /// <summary>
        /// Inventory item ID - ID referencing the inventory system
        /// </summary>
        [JsonProperty("inventoryItemId")]
        public string InventoryItemId { get; set; }

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
        /// Product variants, will be provided if the the request was sent with the includeVariants flag.
        /// </summary>
        [JsonProperty("variants")]
        public List<Variants> Variants { get; set; }

        /// <summary>
        /// Discount taken off of the product's original price
        /// </summary>
        [JsonProperty("discount")]
        public ProductDiscount Discount { get; set; }

        /// <summary>
        /// Price data, converted to the currency specified in request header.
        /// </summary>
        [JsonProperty("convertedPriceData")]
        public ConvertedPriceData ConvertedPriceData { get; set; }
    }

    public class ConvertedPriceData
    {
        /// <summary>
        /// Discounted product price (if no discounted price is set, the product price is returned)
        /// </summary>
        [JsonProperty("discountedPrice")]
        public string DiscountedPrice { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }

        /// <summary>
        /// The product price and discounted price, formatted with the currency
        /// </summary>
        [JsonProperty("formatted")]
        public Formatted Formatted { get; set; }

        /// <summary>
        /// Price per unit
        /// </summary>
        [JsonProperty("pricePerUnit")]
        public string PricePerUnit { get; set; }

        /// <summary>
        /// Product price currency
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class ProductPriceData
    {
        /// <summary>
        /// Discounted product price (if no discounted price is set, the product price is returned)
        /// </summary>
        [JsonProperty("discountedPrice")]
        public string DiscountedPrice { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }

        /// <summary>
        /// Price per unit
        /// </summary>
        [JsonProperty("pricePerUnit")]
        public string PricePerUnit { get; set; }

        /// <summary>
        /// Product price currency
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// price per unit data
        /// </summary>
        [JsonProperty("formatted")]
        public Formatted Formatted { get; set; }
    }

    public class PricePerUnitData
    {
        /// <summary>
        /// Total quantity
        /// </summary>
        [JsonProperty("totalQuantity")]
        public string TotalQuantity { get; set; }

        /// <summary>
        /// Supported values: UNSPECIFIED, ML, CL, L, CBM, MG, G, KG, MM, CM, M, SQM, OZ, LB, FLOZ, PT, QT, GAL, IN, FT, YD, SQFT. Total measurement unit
        /// </summary>
        [JsonProperty("totalMeasurementUnit")]
        public string TotalMeasurementUnit { get; set; }

        /// <summary>
        /// Base quantity
        /// </summary>
        [JsonProperty("baseQuantity")]
        public string BaseQuantity { get; set; }

        /// <summary>
        /// Supported values: UNSPECIFIED, ML, CL, L, CBM, MG, G, KG, MM, CM, M, SQM, OZ, LB, FLOZ, PT, QT, GAL, IN, FT, YD, SQFT.Base measurement unit
        /// </summary>
        public string BaseMeasurementUnit { get; set; }
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
