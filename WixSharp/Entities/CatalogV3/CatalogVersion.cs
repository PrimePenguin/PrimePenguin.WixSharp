using Newtonsoft.Json;

namespace WixSharp.Entities.CatalogV3
{
    public class GetCatalogVersionResponse
    {
        /// <summary>
        /// The version of the Stores catalog installed on the site. See <see cref="CatalogVersions"/>.
        /// </summary>
        [JsonProperty("catalogVersion")]
        public string CatalogVersion { get; set; }

        /// <summary>
        /// Whether the site uses Catalog V1. Use the V1 services (ProductService, InventoryItemService, CollectionService).
        /// </summary>
        [JsonIgnore]
        public bool IsV1Catalog => CatalogVersion == CatalogVersions.V1Catalog;

        /// <summary>
        /// Whether the site uses Catalog V3. Use the V3 services (ProductV3Service, InventoryItemV3Service, CategoryService).
        /// </summary>
        [JsonIgnore]
        public bool IsV3Catalog => CatalogVersion == CatalogVersions.V3Catalog;
    }

    public static class CatalogVersions
    {
        public const string V1Catalog = "V1_CATALOG";
        public const string V3Catalog = "V3_CATALOG";
        public const string StoresNotInstalled = "STORES_NOT_INSTALLED";
    }
}
