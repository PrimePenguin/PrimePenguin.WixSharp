using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WixSharp.Entities.CatalogV3
{
    // Usings are declared inside the namespace so that Common types take precedence over
    // legacy types with the same name in WixSharp.Entities.
    using WixSharp.Entities.Common;

    /// <summary>
    /// A category in the Wix Stores category tree. Categories replace Catalog V1 collections.
    /// </summary>
    public class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Revision number. The current revision must be passed when updating the category.
        /// </summary>
        [JsonProperty("revision")]
        public string Revision { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("updatedDate")]
        public DateTimeOffset? UpdatedDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public WixImage Image { get; set; }

        /// <summary>
        /// Number of items directly assigned to this category, excluding subcategories. Read-only.
        /// </summary>
        [JsonProperty("itemCounter")]
        public int? ItemCounter { get; set; }

        /// <summary>
        /// Plain-text description. Returned only when <see cref="RequestedCategoryFields.Description"/> is requested.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Whether the category is visible to site visitors. Hiding a parent category hides all its subcategories.
        /// </summary>
        [JsonProperty("visible")]
        public bool? Visible { get; set; }

        /// <summary>
        /// Path from the top-level ancestor down to the parent of this category.
        /// Returned only when <see cref="RequestedCategoryFields.BreadcrumbsInfo"/> is requested.
        /// </summary>
        [JsonProperty("breadcrumbsInfo")]
        public BreadcrumbsInfo BreadcrumbsInfo { get; set; }

        /// <summary>
        /// Parent category. Omit (or leave the ID empty) for a top-level category.
        /// </summary>
        [JsonProperty("parentCategory")]
        public ParentCategory ParentCategory { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("seoData")]
        public JObject SeoData { get; set; }

        /// <summary>
        /// Returned only when <see cref="RequestedCategoryFields.RichContentDescription"/> is requested.
        /// </summary>
        [JsonProperty("richContentDescription")]
        public JObject RichContentDescription { get; set; }

        [JsonProperty("treeReference")]
        public TreeReference TreeReference { get; set; }

        /// <summary>
        /// When set, only this app can add or remove items in the category.
        /// </summary>
        [JsonProperty("managingAppId")]
        public string ManagingAppId { get; set; }

        [JsonProperty("extendedFields")]
        public ExtendedFields ExtendedFields { get; set; }
    }

    public class ParentCategory
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Position of this category among its siblings.
        /// </summary>
        [JsonProperty("index")]
        public int? Index { get; set; }
    }

    public class TreeReference
    {
        /// <summary>
        /// Namespace of the app whose catalog the category tree belongs to. Currently only "@wix/stores" is supported.
        /// </summary>
        [JsonProperty("appNamespace")]
        public string AppNamespace { get; set; }

        /// <summary>
        /// Key to differentiate between multiple trees of the same app. Omit for Wix Stores.
        /// </summary>
        [JsonProperty("treeKey")]
        public string TreeKey { get; set; }
    }

    /// <summary>
    /// Reference to an item (for Wix Stores, a product) in a category.
    /// </summary>
    public class ItemReference
    {
        /// <summary>
        /// ID of the item within its catalog. For Wix Stores, the product ID.
        /// </summary>
        [JsonProperty("catalogItemId")]
        public string CatalogItemId { get; set; }

        /// <summary>
        /// ID of the app providing the catalog. For Wix Stores, "215238eb-22a5-4c36-9e7b-e7c08025e04e".
        /// </summary>
        [JsonProperty("appId")]
        public string AppId { get; set; }
    }

    public class QueryCategoriesResponse
    {
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("pagingMetadata")]
        public CursorPagingMetadata PagingMetadata { get; set; }
    }

    public class SearchCategoriesResponse : QueryCategoriesResponse
    {
        [JsonProperty("aggregationData")]
        public JObject AggregationData { get; set; }
    }

    public class BulkItemsToCategoryResponse
    {
        [JsonProperty("results")]
        public List<BulkItemToCategoryResult> Results { get; set; }

        [JsonProperty("bulkActionMetadata")]
        public BulkActionMetadata BulkActionMetadata { get; set; }
    }

    public class BulkItemToCategoryResult
    {
        [JsonProperty("itemMetadata")]
        public ItemReferenceMetadata ItemMetadata { get; set; }
    }

    public class ItemReferenceMetadata
    {
        [JsonProperty("item")]
        public ItemReference Item { get; set; }

        [JsonProperty("originalIndex")]
        public int? OriginalIndex { get; set; }

        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("error")]
        public ApplicationError Error { get; set; }
    }

    public class ListItemsInCategoryResponse
    {
        [JsonProperty("items")]
        public List<ItemReference> Items { get; set; }

        [JsonProperty("pagingMetadata")]
        public PagingMetadataV2 PagingMetadata { get; set; }
    }

    public class ListCategoriesForItemResponse
    {
        /// <summary>
        /// Categories the item is directly assigned to.
        /// </summary>
        [JsonProperty("directCategoryIds")]
        public List<string> DirectCategoryIds { get; set; }

        /// <summary>
        /// Direct categories plus all their ancestors.
        /// </summary>
        [JsonProperty("allCategoryIds")]
        public List<string> AllCategoryIds { get; set; }
    }

    public class ListCategoriesForItemsResponse
    {
        [JsonProperty("categoriesForItems")]
        public List<ItemCategories> CategoriesForItems { get; set; }
    }

    public class ItemCategories
    {
        [JsonProperty("item")]
        public ItemReference Item { get; set; }

        /// <summary>
        /// Categories the item is directly assigned to.
        /// </summary>
        [JsonProperty("directCategoryIds")]
        public List<string> DirectCategoryIds { get; set; }

        /// <summary>
        /// Ancestors of the direct categories.
        /// </summary>
        [JsonProperty("indirectCategoryIds")]
        public List<string> IndirectCategoryIds { get; set; }
    }

    public class BulkCategoriesResponse
    {
        [JsonProperty("results")]
        public List<BulkCategoryResult> Results { get; set; }

        [JsonProperty("bulkActionMetadata")]
        public BulkActionMetadata BulkActionMetadata { get; set; }
    }

    public class BulkCategoryResult
    {
        [JsonProperty("itemMetadata")]
        public ItemMetadata ItemMetadata { get; set; }

        /// <summary>
        /// The category. Returned only when <c>returnEntity: true</c> is passed in the request.
        /// </summary>
        [JsonProperty("category")]
        public Category Category { get; set; }
    }

    public class MoveCategoryResponse
    {
        [JsonProperty("parentCategoryId")]
        public string ParentCategoryId { get; set; }

        /// <summary>
        /// IDs of the parent's subcategories, in their order after the move.
        /// </summary>
        [JsonProperty("categoriesAfterMove")]
        public List<string> CategoriesAfterMove { get; set; }
    }

    /// <summary>
    /// Values for the <c>position</c> parameter of Move Category.
    /// </summary>
    public static class CategoryMovePositions
    {
        public const string First = "FIRST";
        public const string Last = "LAST";
        /// <summary>Requires the ID of the category to move after.</summary>
        public const string After = "AFTER";
    }

    /// <summary>
    /// Body of the category action webhooks (Category Moved, Item Added To Category, Item Removed From Category,
    /// Items Arranged In Category). Read it with <c>WixDomainEvent.GetEntity&lt;CategoryActionEventBody&gt;()</c>.
    /// </summary>
    public class CategoryActionEventBody
    {
        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        /// <summary>
        /// Category Moved only.
        /// </summary>
        [JsonProperty("parentCategory")]
        public ParentCategory ParentCategory { get; set; }

        /// <summary>
        /// Item Added To Category only.
        /// </summary>
        [JsonProperty("addedItem")]
        public ItemReference AddedItem { get; set; }

        /// <summary>
        /// Item Removed From Category only.
        /// </summary>
        [JsonProperty("removedItem")]
        public ItemReference RemovedItem { get; set; }

        [JsonProperty("treeReference")]
        public TreeReference TreeReference { get; set; }
    }

    /// <summary>
    /// Values for the <c>fields</c> parameter of Categories endpoints.
    /// </summary>
    public static class RequestedCategoryFields
    {
        public const string BreadcrumbsInfo = "BREADCRUMBS_INFO";
        public const string Description = "DESCRIPTION";
        public const string RichContentDescription = "RICH_CONTENT_DESCRIPTION";
    }

    internal class CategoryEnvelope
    {
        [JsonProperty("category")]
        public Category Category { get; set; }
    }

    internal class ItemReferencesEnvelope
    {
        [JsonProperty("items")]
        public List<ItemReference> Items { get; set; }
    }

    internal class TreesEnvelope
    {
        [JsonProperty("trees")]
        public List<TreeReference> Trees { get; set; }
    }
}
