using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Infrastructure;

namespace WixSharp.Services.CatalogV3
{
    using WixSharp.Entities.CatalogV3;
    using WixSharp.Entities.Common;

    /// <summary>
    /// A service for managing Wix Stores categories, which replace collections in Catalog V3.
    /// Only use it for sites where <see cref="CatalogVersionService"/> reports V3_CATALOG.
    /// </summary>
    public class CategoryService : WixService
    {
        /// <summary>
        /// App namespace of the Wix Stores category tree.
        /// </summary>
        public const string WixStoresAppNamespace = "@wix/stores";

        /// <summary>
        /// App ID of Wix Stores, used as <see cref="ItemReference.AppId"/> for products.
        /// </summary>
        public const string WixStoresAppId = "215238eb-22a5-4c36-9e7b-e7c08025e04e";

        private static readonly TreeReference _StoresTreeReference = new TreeReference { AppNamespace = WixStoresAppNamespace };

        /// <summary>
        /// Creates a new instance of <see cref="CategoryService" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public CategoryService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Creates a category.
        /// </summary>
        /// <param name="category">Category to create. Requires <c>Name</c>; set <c>ParentCategory</c> to create a subcategory.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedCategoryFields"/>.</param>
        public virtual async Task<Category> CreateCategoryAsync(Category category, IEnumerable<string> fields = null)
        {
            var req = PrepareWixApiRequest("categories/v1/categories");
            var content = new JsonContent(new { category, treeReference = _StoresTreeReference, fields });
            var response = await ExecuteRequestAsync<CategoryEnvelope>(req, HttpMethod.Post, content);
            return response.Category;
        }

        /// <summary>
        /// Retrieves a category.
        /// </summary>
        /// <param name="categoryId">Category ID.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedCategoryFields"/>.</param>
        public virtual async Task<Category> GetCategoryAsync(string categoryId, IEnumerable<string> fields = null)
        {
            var req = PrepareWixApiRequest($"categories/v1/categories/{categoryId}");
            AddTreeReferenceQueryParam(req);

            if (fields != null && fields.Any())
            {
                req.QueryParams.Add("fields", fields);
            }

            var response = await ExecuteRequestAsync<CategoryEnvelope>(req, HttpMethod.Get);
            return response.Category;
        }

        /// <summary>
        /// Updates a category. Only the fields that are set are updated.
        /// </summary>
        /// <param name="category">Category fields to update. <c>Id</c> and the current <c>Revision</c> are required.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedCategoryFields"/>.</param>
        public virtual async Task<Category> UpdateCategoryAsync(Category category, IEnumerable<string> fields = null)
        {
            var req = PrepareWixApiRequest($"categories/v1/categories/{category.Id}");
            var content = new JsonContent(new { category, treeReference = _StoresTreeReference, fields });
            var response = await ExecuteRequestAsync<CategoryEnvelope>(req, HttpMethod.Patch, content);
            return response.Category;
        }

        /// <summary>
        /// Deletes a category and all its subcategories. The products remain in the catalog.
        /// </summary>
        /// <param name="categoryId">ID of the category to delete.</param>
        public virtual async Task DeleteCategoryAsync(string categoryId)
        {
            var req = PrepareWixApiRequest($"categories/v1/categories/{categoryId}");
            AddTreeReferenceQueryParam(req);
            await ExecuteRequestAsync<object>(req, HttpMethod.Delete);
        }

        /// <summary>
        /// Retrieves a list of up to 1,000 categories, given the provided paging, filtering, and sorting.
        /// </summary>
        /// <param name="query">Paging, filtering and sorting.</param>
        /// <param name="returnNonVisibleCategories">Whether to also return hidden categories.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedCategoryFields"/>.</param>
        public virtual async Task<QueryCategoriesResponse> QueryCategoriesAsync(CursorQuery query = null, bool? returnNonVisibleCategories = null, IEnumerable<string> fields = null)
        {
            var req = PrepareWixApiRequest("categories/v1/categories/query");
            var content = new JsonContent(new { query, treeReference = _StoresTreeReference, returnNonVisibleCategories, fields });
            return await ExecuteRequestAsync<QueryCategoriesResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Retrieves a list of categories, given the provided free-text search, filtering, sorting, and aggregations.
        /// </summary>
        /// <param name="search">Search, paging, filtering, sorting and aggregations.</param>
        /// <param name="returnNonVisibleCategories">Whether to also return hidden categories.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedCategoryFields"/>.</param>
        public virtual async Task<SearchCategoriesResponse> SearchCategoriesAsync(CursorSearch search = null, bool? returnNonVisibleCategories = null, IEnumerable<string> fields = null)
        {
            var req = PrepareWixApiRequest("categories/v1/categories/search");
            var content = new JsonContent(new { search, treeReference = _StoresTreeReference, returnNonVisibleCategories, fields });
            return await ExecuteRequestAsync<SearchCategoriesResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Adds up to 1,000 products to a category.
        /// </summary>
        /// <param name="categoryId">Category ID.</param>
        /// <param name="productIds">IDs of the products to add.</param>
        public virtual async Task<BulkItemsToCategoryResponse> BulkAddProductsToCategoryAsync(string categoryId, IEnumerable<string> productIds)
        {
            var req = PrepareWixApiRequest($"categories/v1/bulk/categories/{categoryId}/add-items");
            var content = new JsonContent(new { items = ToItemReferences(productIds), treeReference = _StoresTreeReference });
            return await ExecuteRequestAsync<BulkItemsToCategoryResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Removes up to 100 products from a category.
        /// </summary>
        /// <param name="categoryId">Category ID.</param>
        /// <param name="productIds">IDs of the products to remove.</param>
        public virtual async Task<BulkItemsToCategoryResponse> BulkRemoveProductsFromCategoryAsync(string categoryId, IEnumerable<string> productIds)
        {
            var req = PrepareWixApiRequest($"categories/v1/bulk/categories/{categoryId}/remove-items");
            var content = new JsonContent(new { items = ToItemReferences(productIds), treeReference = _StoresTreeReference });
            return await ExecuteRequestAsync<BulkItemsToCategoryResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Lists the items (products) in a category.
        /// </summary>
        /// <param name="categoryId">Category ID.</param>
        /// <param name="cursorPaging">Cursor paging options.</param>
        /// <param name="includeItemsFromSubcategories">Whether to include items from subcategories.</param>
        /// <param name="useCategoryArrangement">Whether manually arranged items are returned first, in their arranged order.</param>
        public virtual async Task<ListItemsInCategoryResponse> ListItemsInCategoryAsync(string categoryId, CursorPagingOptions cursorPaging = null, bool? includeItemsFromSubcategories = null, bool? useCategoryArrangement = null)
        {
            var req = PrepareWixApiRequest($"categories/v1/categories/{categoryId}/list-items");
            var content = new JsonContent(new
            {
                treeReference = _StoresTreeReference,
                cursorPaging,
                includeItemsFromSubcategories,
                useCategoryArrangement
            });
            return await ExecuteRequestAsync<ListItemsInCategoryResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Lists the categories a product belongs to.
        /// </summary>
        /// <param name="productId">Product ID.</param>
        public virtual async Task<ListCategoriesForItemResponse> ListCategoriesForProductAsync(string productId)
        {
            var req = PrepareWixApiRequest("categories/v1/categories/list-categories-for-item");
            var content = new JsonContent(new
            {
                item = ToItemReference(productId),
                treeReference = _StoresTreeReference
            });
            return await ExecuteRequestAsync<ListCategoriesForItemResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Retrieves a category by its slug.
        /// </summary>
        /// <param name="slug">Category slug.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedCategoryFields"/>.</param>
        public virtual async Task<Category> GetCategoryBySlugAsync(string slug, IEnumerable<string> fields = null)
        {
            var req = PrepareWixApiRequest($"categories/v1/categories/slug/{slug}");
            AddTreeReferenceQueryParam(req);

            if (fields != null && fields.Any())
            {
                req.QueryParams.Add("fields", fields);
            }

            var response = await ExecuteRequestAsync<CategoryEnvelope>(req, HttpMethod.Get);
            return response.Category;
        }

        /// <summary>
        /// Counts the categories that match the provided filter and search.
        /// </summary>
        /// <param name="filter">Filter object in Wix API query language.</param>
        /// <param name="search">Free-text search options.</param>
        /// <param name="returnNonVisibleCategories">Whether to also count hidden categories.</param>
        public virtual async Task<int> CountCategoriesAsync(object filter = null, SearchDetails search = null, bool? returnNonVisibleCategories = null)
        {
            var req = PrepareWixApiRequest("categories/v1/categories/count");
            var content = new JsonContent(new { filter, search, returnNonVisibleCategories, treeReference = _StoresTreeReference });
            var response = await ExecuteRequestAsync<CountEnvelope>(req, HttpMethod.Post, content);
            return response.Count;
        }

        /// <summary>
        /// Updates up to 100 categories. Each category requires its <c>Id</c> and current <c>Revision</c>.
        /// </summary>
        /// <param name="categories">Category fields to update.</param>
        /// <param name="returnEntity">Whether to return the full category entities in the response.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedCategoryFields"/>.</param>
        public virtual async Task<BulkCategoriesResponse> BulkUpdateCategoriesAsync(IEnumerable<Category> categories, bool? returnEntity = null, IEnumerable<string> fields = null)
        {
            var req = PrepareWixApiRequest("categories/v1/bulk/categories/update");
            var content = new JsonContent(new
            {
                categories = categories.Select(category => new { category }),
                treeReference = _StoresTreeReference,
                returnEntity,
                fields
            });
            return await ExecuteRequestAsync<BulkCategoriesResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Makes up to 100 categories visible to site visitors. Categories with a hidden parent category aren't updated.
        /// </summary>
        /// <param name="categoryIds">IDs of the categories to show.</param>
        /// <param name="returnEntity">Whether to return the full category entities in the response.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedCategoryFields"/>.</param>
        public virtual async Task<BulkCategoriesResponse> BulkShowCategoriesAsync(IEnumerable<string> categoryIds, bool? returnEntity = null, IEnumerable<string> fields = null)
        {
            var req = PrepareWixApiRequest("categories/v1/bulk/categories/show");
            var content = new JsonContent(new { categoryIds, treeReference = _StoresTreeReference, returnEntity, fields });
            return await ExecuteRequestAsync<BulkCategoriesResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Shows or hides a category. Hiding a category also hides its subcategories,
        /// and a subcategory can't be shown while a parent category is hidden.
        /// </summary>
        /// <param name="categoryId">Category ID.</param>
        /// <param name="visible">Whether the category is visible to site visitors.</param>
        /// <param name="revision">The category's current revision.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedCategoryFields"/>.</param>
        public virtual async Task<Category> UpdateCategoryVisibilityAsync(string categoryId, bool visible, string revision, IEnumerable<string> fields = null)
        {
            var req = PrepareWixApiRequest("categories/v1/categories/visibility");
            var content = new JsonContent(new { categoryId, visible, revision, treeReference = _StoresTreeReference, fields });
            var response = await ExecuteRequestAsync<CategoryEnvelope>(req, HttpMethod.Patch, content);
            return response.Category;
        }

        /// <summary>
        /// Moves a category within its parent category, or to a different parent category.
        /// </summary>
        /// <param name="categoryId">ID of the category to move.</param>
        /// <param name="position">Position within the parent category. See <see cref="CategoryMovePositions"/>.</param>
        /// <param name="parentCategoryId">ID of the target parent category. Omit to move the category to the top level.</param>
        /// <param name="moveAfterCategoryId">ID of the sibling category to move after. Required when <paramref name="position"/> is AFTER.</param>
        public virtual async Task<MoveCategoryResponse> MoveCategoryAsync(string categoryId, string position, string parentCategoryId = null, string moveAfterCategoryId = null)
        {
            var req = PrepareWixApiRequest($"categories/v1/categories/{categoryId}/move");
            var content = new JsonContent(new { position, parentCategoryId, moveAfterCategoryId, treeReference = _StoresTreeReference });
            return await ExecuteRequestAsync<MoveCategoryResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Adds a product to up to 100 categories.
        /// </summary>
        /// <param name="productId">ID of the product to add.</param>
        /// <param name="categoryIds">IDs of the categories to add the product to.</param>
        public virtual async Task<BulkActionResponse> BulkAddProductToCategoriesAsync(string productId, IEnumerable<string> categoryIds)
        {
            var req = PrepareWixApiRequest("categories/v1/bulk/categories/add-item");
            var content = new JsonContent(new { item = ToItemReference(productId), categoryIds, treeReference = _StoresTreeReference });
            return await ExecuteRequestAsync<BulkActionResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Removes a product from up to 100 categories.
        /// </summary>
        /// <param name="productId">ID of the product to remove.</param>
        /// <param name="categoryIds">IDs of the categories to remove the product from.</param>
        public virtual async Task<BulkActionResponse> BulkRemoveProductFromCategoriesAsync(string productId, IEnumerable<string> categoryIds)
        {
            var req = PrepareWixApiRequest("categories/v1/bulk/categories/remove-item");
            var content = new JsonContent(new { item = ToItemReference(productId), categoryIds, treeReference = _StoresTreeReference });
            return await ExecuteRequestAsync<BulkActionResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Lists the categories of up to 100 products.
        /// </summary>
        /// <param name="productIds">Product IDs.</param>
        public virtual async Task<ListCategoriesForItemsResponse> ListCategoriesForProductsAsync(IEnumerable<string> productIds)
        {
            var req = PrepareWixApiRequest("categories/v1/categories/list-categories-for-items");
            var content = new JsonContent(new { items = ToItemReferences(productIds), treeReference = _StoresTreeReference });
            return await ExecuteRequestAsync<ListCategoriesForItemsResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Retrieves the items that were manually arranged in a category with <see cref="SetArrangedItemsAsync"/>, in their arranged order.
        /// </summary>
        /// <param name="categoryId">Category ID.</param>
        public virtual async Task<List<ItemReference>> GetArrangedItemsAsync(string categoryId)
        {
            var req = PrepareWixApiRequest($"categories/v1/categories/{categoryId}/arranged-items");
            AddTreeReferenceQueryParam(req);
            var response = await ExecuteRequestAsync<ItemReferencesEnvelope>(req, HttpMethod.Get);
            return response.Items;
        }

        /// <summary>
        /// Sets the manual display order of up to 100 products in a category, replacing the existing arrangement.
        /// The order applies when items are listed with <c>useCategoryArrangement: true</c>.
        /// </summary>
        /// <param name="categoryId">Category ID.</param>
        /// <param name="productIds">Product IDs, in display order.</param>
        /// <returns>The arranged items.</returns>
        public virtual async Task<List<ItemReference>> SetArrangedItemsAsync(string categoryId, IEnumerable<string> productIds)
        {
            var req = PrepareWixApiRequest($"categories/v1/categories/{categoryId}/set-arranged-items");
            var content = new JsonContent(new { items = ToItemReferences(productIds), treeReference = _StoresTreeReference });
            var response = await ExecuteRequestAsync<ItemReferencesEnvelope>(req, HttpMethod.Post, content);
            return response.Items;
        }

        /// <summary>
        /// Lists the category trees installed on the site.
        /// </summary>
        public virtual async Task<List<TreeReference>> ListTreesAsync()
        {
            var req = PrepareWixApiRequest("categories/v1/categories/list-trees");
            var response = await ExecuteRequestAsync<TreesEnvelope>(req, HttpMethod.Get);
            return response.Trees;
        }

        private static ItemReference ToItemReference(string productId)
        {
            return new ItemReference { CatalogItemId = productId, AppId = WixStoresAppId };
        }

        private static IEnumerable<ItemReference> ToItemReferences(IEnumerable<string> productIds)
        {
            return productIds.Select(ToItemReference);
        }

        private static void AddTreeReferenceQueryParam(RequestUri req)
        {
            req.QueryParams.Add("treeReference.appNamespace", WixStoresAppNamespace);
        }
    }
}
