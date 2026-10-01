using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Infrastructure;

namespace WixSharp.Services.CatalogV3
{
    // Usings are declared inside the namespace so that "Product" resolves to the V3 entity
    // rather than the WixSharp.Services.Product namespace.
    using WixSharp.Entities.CatalogV3;
    using WixSharp.Entities.Common;

    /// <summary>
    /// A service for managing products in a Wix Stores Catalog V3.
    /// Only use it for sites where <see cref="CatalogVersionService"/> reports V3_CATALOG.
    /// </summary>
    public class ProductV3Service : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="ProductV3Service" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public ProductV3Service(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Creates a product. Inventory items aren't created; use <see cref="CreateProductWithInventoryAsync"/> to create both.
        /// </summary>
        /// <param name="product">Product to create. Requires name, productType, and variantsInfo with at least one variant with an actual price.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        public virtual async Task<Product> CreateProductAsync(Product product, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3("products");
            var content = new JsonContent(new { product, fields });
            var response = await ExecuteRequestAsync<ProductEnvelope>(req, HttpMethod.Post, content);
            return response.Product;
        }

        /// <summary>
        /// Retrieves a product.
        /// </summary>
        /// <param name="productId">Product ID.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        public virtual async Task<Product> GetProductAsync(string productId, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3($"products/{productId}");
            AddFieldsQueryParam(req, fields);
            var response = await ExecuteRequestAsync<ProductEnvelope>(req, HttpMethod.Get);
            return response.Product;
        }

        /// <summary>
        /// Retrieves a product by its slug.
        /// </summary>
        /// <param name="slug">Product slug.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        public virtual async Task<Product> GetProductBySlugAsync(string slug, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3($"products/slug/{slug}");
            AddFieldsQueryParam(req, fields);
            var response = await ExecuteRequestAsync<ProductEnvelope>(req, HttpMethod.Get);
            return response.Product;
        }

        /// <summary>
        /// Updates a product. Top-level fields that aren't set are left unchanged, but array fields
        /// (<c>options</c>, <c>modifiers</c>, <c>variantsInfo.variants</c>) are replaced as a whole, so pass the entire array.
        /// Variants and options must be passed together, and existing variants must include their ID
        /// (a variant without an ID is created as a new variant).
        /// </summary>
        /// <param name="product">Product fields to update. <c>Id</c> and the current <c>Revision</c> are required.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        public virtual async Task<Product> UpdateProductAsync(Product product, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3($"products/{product.Id}");
            var content = new JsonContent(new { product, fields });
            var response = await ExecuteRequestAsync<ProductEnvelope>(req, HttpMethod.Patch, content);
            return response.Product;
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="productId">ID of the product to delete.</param>
        public virtual async Task DeleteProductAsync(string productId)
        {
            var req = PrepareRequestV3($"products/{productId}");
            await ExecuteRequestAsync<object>(req, HttpMethod.Delete);
        }

        /// <summary>
        /// Retrieves a list of up to 100 products, given the provided paging, filtering, and sorting.
        /// The response doesn't include variants; use <see cref="QueryVariantsAsync"/> for variant data.
        /// </summary>
        /// <param name="query">Paging, filtering and sorting. Pass <c>CursorPaging.Cursor</c> from the previous response to get the next page.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        public virtual async Task<QueryProductsResponse> QueryProductsAsync(CursorQuery query = null, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3("products/query");
            var content = new JsonContent(new { query, fields });
            return await ExecuteRequestAsync<QueryProductsResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Retrieves a list of up to 100 products, given the provided free-text search, filtering, sorting, and aggregations.
        /// The response doesn't include variants; use <see cref="SearchVariantsAsync"/> for variant data.
        /// </summary>
        /// <param name="search">Search, paging, filtering, sorting and aggregations.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        public virtual async Task<SearchProductsResponse> SearchProductsAsync(CursorSearch search = null, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3("products/search");
            var content = new JsonContent(new { search, fields });
            return await ExecuteRequestAsync<SearchProductsResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Counts the products that match the provided filter and search.
        /// </summary>
        /// <param name="filter">Filter object in Wix API query language.</param>
        /// <param name="search">Free-text search options.</param>
        /// <param name="returnNonVisibleProducts">Whether to count non-visible products. Requires the 'Product v3 read admin' permission.</param>
        public virtual async Task<int> CountProductsAsync(object filter = null, SearchDetails search = null, bool? returnNonVisibleProducts = null)
        {
            var req = PrepareRequestV3("products/count");
            var content = new JsonContent(new { filter, search, returnNonVisibleProducts });
            var response = await ExecuteRequestAsync<CountEnvelope>(req, HttpMethod.Post, content);
            return response.Count;
        }

        /// <summary>
        /// Creates a product together with inventory items for its variants in the default location.
        /// Set <c>Variant.InventoryItem</c> on each variant to define its stock.
        /// </summary>
        /// <param name="product">Product to create.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        /// <param name="returnEntity">Whether to return the full inventory item entities in the response.</param>
        public virtual async Task<ProductWithInventoryResponse> CreateProductWithInventoryAsync(Product product, IEnumerable<string> fields = null, bool? returnEntity = null)
        {
            var req = PrepareRequestV3("products-with-inventory");
            var content = new JsonContent(new { product, fields, returnEntity });
            return await ExecuteRequestAsync<ProductWithInventoryResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Updates a product together with the inventory items of its variants in the default location.
        /// </summary>
        /// <param name="product">Product fields to update. <c>Id</c> and the current <c>Revision</c> are required.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        /// <param name="returnEntity">Whether to return the full inventory item entities in the response.</param>
        public virtual async Task<ProductWithInventoryResponse> UpdateProductWithInventoryAsync(Product product, IEnumerable<string> fields = null, bool? returnEntity = null)
        {
            var req = PrepareRequestV3($"products-with-inventory/{product.Id}");
            var content = new JsonContent(new { product, fields, returnEntity });
            return await ExecuteRequestAsync<ProductWithInventoryResponse>(req, HttpMethod.Patch, content);
        }

        /// <summary>
        /// Creates up to 100 products.
        /// </summary>
        /// <param name="products">Products to create.</param>
        /// <param name="returnEntity">Whether to return the full product entities in the response.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        public virtual async Task<BulkResponse<Product>> BulkCreateProductsAsync(IEnumerable<Product> products, bool? returnEntity = null, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3("bulk/products/create");
            var content = new JsonContent(new { products, returnEntity, fields });
            return await ExecuteRequestAsync<BulkResponse<Product>>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Updates up to 100 products. Each product requires its <c>Id</c> and current <c>Revision</c>.
        /// </summary>
        /// <param name="products">Product fields to update.</param>
        /// <param name="returnEntity">Whether to return the full product entities in the response.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        public virtual async Task<BulkResponse<Product>> BulkUpdateProductsAsync(IEnumerable<Product> products, bool? returnEntity = null, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3("bulk/products/update");
            var content = new JsonContent(new
            {
                products = products.Select(product => new { product }),
                returnEntity,
                fields
            });
            return await ExecuteRequestAsync<BulkResponse<Product>>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Deletes up to 100 products.
        /// </summary>
        /// <param name="productIds">IDs of the products to delete.</param>
        public virtual async Task<BulkResponse<Product>> BulkDeleteProductsAsync(IEnumerable<string> productIds)
        {
            var req = PrepareRequestV3("bulk/products/delete");
            var content = new JsonContent(new { productIds });
            return await ExecuteRequestAsync<BulkResponse<Product>>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Creates up to 100 products together with inventory items for their variants in the default location.
        /// Set <c>Variant.InventoryItem</c> on each variant to define its stock.
        /// </summary>
        /// <param name="products">Products to create.</param>
        /// <param name="returnEntity">Whether to return the full product and inventory item entities in the response.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        public virtual async Task<BulkProductsWithInventoryResponse> BulkCreateProductsWithInventoryAsync(IEnumerable<Product> products, bool? returnEntity = null, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3("bulk/products-with-inventory/create");
            var content = new JsonContent(new { products, returnEntity, fields });
            return await ExecuteRequestAsync<BulkProductsWithInventoryResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Updates up to 100 products together with the inventory items of their variants in the default location.
        /// Each product requires its <c>Id</c> and current <c>Revision</c>.
        /// </summary>
        /// <param name="products">Product fields to update.</param>
        /// <param name="returnEntity">Whether to return the full product and inventory item entities in the response.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        public virtual async Task<BulkProductsWithInventoryResponse> BulkUpdateProductsWithInventoryAsync(IEnumerable<Product> products, bool? returnEntity = null, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3("bulk/products-with-inventory/update");
            var content = new JsonContent(new
            {
                products = products.Select(product => new { product }),
                returnEntity,
                fields
            });
            return await ExecuteRequestAsync<BulkProductsWithInventoryResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Updates all products that match the filter, as an asynchronous job.
        /// <c>slug</c>, <c>options</c>, <c>modifiers</c> and <c>variantsInfo</c> can't be updated this way.
        /// To update <c>infoSections</c>, <c>brand</c> or <c>ribbon</c>, pass their existing IDs.
        /// </summary>
        /// <param name="product">Product fields to set on every matching product.</param>
        /// <param name="filter">Filter object in Wix API query language.</param>
        /// <param name="search">Free-text search options.</param>
        /// <returns>The job ID. Track it with <see cref="AsyncJobs.AsyncJobService"/>.</returns>
        public virtual async Task<string> BulkUpdateProductsByFilterAsync(Product product, object filter = null, SearchDetails search = null)
        {
            var req = PrepareRequestV3("bulk/products/update-by-filter");
            var content = new JsonContent(new { product, filter, search });
            return await ExecuteJobRequestAsync(req, content);
        }

        /// <summary>
        /// Deletes all products that match the filter, as an asynchronous job.
        /// </summary>
        /// <param name="filter">Filter object in Wix API query language.</param>
        /// <param name="search">Free-text search options.</param>
        /// <returns>The job ID. Track it with <see cref="AsyncJobs.AsyncJobService"/>.</returns>
        public virtual async Task<string> BulkDeleteProductsByFilterAsync(object filter, SearchDetails search = null)
        {
            var req = PrepareRequestV3("bulk/products/delete-by-filter");
            var content = new JsonContent(new { filter, search });
            return await ExecuteJobRequestAsync(req, content);
        }

        /// <summary>
        /// Sets variant fields on all variants of the products that match the filter, as an asynchronous job.
        /// Only <c>Visible</c>, <c>Price</c>, <c>RevenueDetails.Cost</c> and <c>PhysicalProperties</c> can be set.
        /// Use <see cref="BulkAdjustProductVariantsByFilterAsync"/> for relative price changes.
        /// </summary>
        /// <param name="variant">Variant fields to set.</param>
        /// <param name="filter">Filter object in Wix API query language.</param>
        /// <param name="search">Free-text search options.</param>
        /// <returns>The job ID. Track it with <see cref="AsyncJobs.AsyncJobService"/>.</returns>
        public virtual async Task<string> BulkUpdateProductVariantsByFilterAsync(Variant variant, object filter, SearchDetails search = null)
        {
            var req = PrepareRequestV3("bulk/products/update-variants-by-filter");
            var content = new JsonContent(new { variant, filter, search });
            return await ExecuteJobRequestAsync(req, content);
        }

        /// <summary>
        /// Increases or decreases the prices and costs of all variants of the products that match the filter,
        /// by an amount or percentage, as an asynchronous job. For example, increase all prices by 10%.
        /// </summary>
        /// <param name="adjustment">The adjustments to apply and the rounding strategy.</param>
        /// <param name="filter">Filter object in Wix API query language.</param>
        /// <param name="search">Free-text search options.</param>
        /// <returns>The job ID. Track it with <see cref="AsyncJobs.AsyncJobService"/>.</returns>
        public virtual async Task<string> BulkAdjustProductVariantsByFilterAsync(VariantPriceAdjustment adjustment, object filter, SearchDetails search = null)
        {
            var req = PrepareRequestV3("bulk/products/adjust-variants-by-filter");
            var content = new JsonContent(new
            {
                filter,
                search,
                actualPrice = adjustment.ActualPrice,
                compareAtPrice = adjustment.CompareAtPrice,
                compareAtPriceDiscount = adjustment.CompareAtPriceDiscount,
                cost = adjustment.Cost,
                rounding = adjustment.Rounding
            });
            return await ExecuteJobRequestAsync(req, content);
        }

        /// <summary>
        /// Adds up to 10 info sections to up to 100 products.
        /// </summary>
        /// <param name="products">Product IDs with their current revisions.</param>
        /// <param name="infoSectionIds">IDs of the info sections to add.</param>
        /// <param name="returnEntity">Whether to return the full product entities in the response.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        public virtual async Task<BulkResponse<Product>> BulkAddInfoSectionsToProductsAsync(IEnumerable<ProductIdWithRevision> products, IEnumerable<string> infoSectionIds, bool? returnEntity = null, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3("bulk/products/add-info-sections");
            var content = new JsonContent(new { products, infoSectionIds, returnEntity, fields });
            return await ExecuteRequestAsync<BulkResponse<Product>>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Adds up to 10 info sections to all products that match the filter, as an asynchronous job.
        /// </summary>
        /// <param name="infoSectionIds">IDs of the info sections to add.</param>
        /// <param name="filter">Filter object in Wix API query language.</param>
        /// <param name="search">Free-text search options.</param>
        /// <returns>The job ID. Track it with <see cref="AsyncJobs.AsyncJobService"/>.</returns>
        public virtual async Task<string> BulkAddInfoSectionsToProductsByFilterAsync(IEnumerable<string> infoSectionIds, object filter, SearchDetails search = null)
        {
            var req = PrepareRequestV3("bulk/products/add-info-sections-by-filter");
            var content = new JsonContent(new { infoSectionIds, filter, search });
            return await ExecuteJobRequestAsync(req, content);
        }

        /// <summary>
        /// Removes up to 10 info sections from up to 100 products.
        /// </summary>
        /// <param name="products">Product IDs with their current revisions.</param>
        /// <param name="infoSectionIds">IDs of the info sections to remove.</param>
        /// <param name="returnEntity">Whether to return the full product entities in the response.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedProductFields"/>.</param>
        public virtual async Task<BulkResponse<Product>> BulkRemoveInfoSectionsFromProductsAsync(IEnumerable<ProductIdWithRevision> products, IEnumerable<string> infoSectionIds, bool? returnEntity = null, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3("bulk/products/remove-info-sections");
            var content = new JsonContent(new { products, infoSectionIds, returnEntity, fields });
            return await ExecuteRequestAsync<BulkResponse<Product>>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Removes up to 10 info sections from all products that match the filter, as an asynchronous job.
        /// </summary>
        /// <param name="infoSectionIds">IDs of the info sections to remove.</param>
        /// <param name="filter">Filter object in Wix API query language.</param>
        /// <param name="search">Free-text search options.</param>
        /// <returns>The job ID. Track it with <see cref="AsyncJobs.AsyncJobService"/>.</returns>
        public virtual async Task<string> BulkRemoveInfoSectionsFromProductsByFilterAsync(IEnumerable<string> infoSectionIds, object filter, SearchDetails search = null)
        {
            var req = PrepareRequestV3("bulk/products/remove-info-sections-by-filter");
            var content = new JsonContent(new { infoSectionIds, filter, search });
            return await ExecuteJobRequestAsync(req, content);
        }

        /// <summary>
        /// Adds all products that match the filter to up to 5 categories, as an asynchronous job.
        /// </summary>
        /// <param name="categoryIds">IDs of the categories to add the products to.</param>
        /// <param name="filter">Filter object in Wix API query language.</param>
        /// <param name="search">Free-text search options.</param>
        /// <returns>The job ID. Track it with <see cref="AsyncJobs.AsyncJobService"/>.</returns>
        public virtual async Task<string> BulkAddProductsToCategoriesByFilterAsync(IEnumerable<string> categoryIds, object filter = null, SearchDetails search = null)
        {
            var req = PrepareRequestV3("bulk/products/add-to-categories-by-filter");
            var content = new JsonContent(new { categoryIds, filter, search });
            return await ExecuteJobRequestAsync(req, content);
        }

        /// <summary>
        /// Removes all products that match the filter from up to 5 categories, as an asynchronous job.
        /// </summary>
        /// <param name="categoryIds">IDs of the categories to remove the products from.</param>
        /// <param name="filter">Filter object in Wix API query language.</param>
        /// <param name="search">Free-text search options.</param>
        /// <returns>The job ID. Track it with <see cref="AsyncJobs.AsyncJobService"/>.</returns>
        public virtual async Task<string> BulkRemoveProductsFromCategoriesByFilterAsync(IEnumerable<string> categoryIds, object filter = null, SearchDetails search = null)
        {
            var req = PrepareRequestV3("bulk/products/remove-from-categories-by-filter");
            var content = new JsonContent(new { categoryIds, filter, search });
            return await ExecuteJobRequestAsync(req, content);
        }

        /// <summary>
        /// Assigns and unassigns tags on up to 100 products.
        /// </summary>
        /// <param name="productIds">IDs of the products to update.</param>
        /// <param name="assignTags">Tags to assign.</param>
        /// <param name="unassignTags">Tags to unassign.</param>
        public virtual async Task<BulkActionResponse> BulkUpdateProductTagsAsync(IEnumerable<string> productIds, ProductTags assignTags = null, ProductTags unassignTags = null)
        {
            var req = PrepareRequestV3("bulk/products/update-tags");
            var content = new JsonContent(new { productIds, assignTags, unassignTags });
            return await ExecuteRequestAsync<BulkActionResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Assigns and unassigns tags on all products that match the filter, as an asynchronous job.
        /// </summary>
        /// <param name="filter">Filter object in Wix API query language.</param>
        /// <param name="assignTags">Tags to assign.</param>
        /// <param name="unassignTags">Tags to unassign.</param>
        /// <returns>The job ID. Track it with <see cref="AsyncJobs.AsyncJobService"/>.</returns>
        public virtual async Task<string> BulkUpdateProductTagsByFilterAsync(object filter, ProductTags assignTags = null, ProductTags unassignTags = null)
        {
            var req = PrepareRequestV3("bulk/products/update-tags-by-filter");
            var content = new JsonContent(new { filter, assignTags, unassignTags });
            return await ExecuteJobRequestAsync(req, content);
        }

        /// <summary>
        /// Retrieves the ID of the "All Products" category, which contains every product in the store.
        /// </summary>
        public virtual async Task<GetAllProductsCategoryResponse> GetAllProductsCategoryAsync()
        {
            var req = PrepareRequestV3("all-products-category");
            return await ExecuteRequestAsync<GetAllProductsCategoryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Retrieves a list of product variants, given the provided paging, filtering, and sorting.
        /// For example, filter by <c>productData.productId</c> to get the variants of one product.
        /// </summary>
        /// <param name="query">Paging, filtering and sorting.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedVariantFields"/>.</param>
        public virtual async Task<QueryVariantsResponse> QueryVariantsAsync(CursorQuery query = null, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3("products/query-variants");
            var content = new JsonContent(new { query, fields });
            return await ExecuteRequestAsync<QueryVariantsResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Retrieves a list of product variants, given the provided free-text search, filtering, sorting, and aggregations.
        /// </summary>
        /// <param name="search">Search, paging, filtering, sorting and aggregations.</param>
        /// <param name="fields">Additional fields to return. See <see cref="RequestedVariantFields"/>.</param>
        public virtual async Task<SearchVariantsResponse> SearchVariantsAsync(CursorSearch search = null, IEnumerable<string> fields = null)
        {
            var req = PrepareRequestV3("products/search-variants");
            var content = new JsonContent(new { search, fields });
            return await ExecuteRequestAsync<SearchVariantsResponse>(req, HttpMethod.Post, content);
        }

        private async Task<string> ExecuteJobRequestAsync(RequestUri req, HttpContent content)
        {
            var response = await ExecuteRequestAsync<JobIdEnvelope>(req, HttpMethod.Post, content);
            return response.JobId;
        }

        private static void AddFieldsQueryParam(RequestUri req, IEnumerable<string> fields)
        {
            if (fields != null && fields.Any())
            {
                req.QueryParams.Add("fields", fields);
            }
        }
    }
}
