using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using WixSharp.Entities;
using WixSharp.Infrastructure;

namespace WixSharp.Services.Product
{
    /// <summary>
    /// A service for manipulating wix products.
    /// </summary>
    public class ProductService : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="ProductService" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public ProductService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Retrieves the <see cref="Product"/> with the given id.
        /// </summary>
        /// <param name="productId">The id of the product to retrieve.</param>
        /// <returns>The <see cref="Product"/>.</returns>
        public virtual async Task<ProductResponse> GetAsync(string productId)
        {
            var req = PrepareRequest($"products/{productId}");
            return await ExecuteRequestAsync<ProductResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a list of up to 100 products, given the provided paging, sorting and filtering.Hidden products are not returned.
        /// </summary>
        /// <param name="query">provided paging, sorting and filtering.</param>
        /// <returns>The new <see cref="ProductQueryResponse"/>.</returns>
        public virtual async Task<ProductQueryResponse> GetProductsAsync(ProductRootQuery query)
        {
            var req = PrepareRequest("products/query");
            HttpContent content = null;

            if (query != null)
            {
                var body = query.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<ProductQueryResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Gets the availability of relevant product variants based on the product ID and selections provided. 
        /// </summary>
        /// <param name="productId">Requested product ID.</param>
        /// <param name="options">Array containing the selected options (e.g, color: Blue, size: Large)</param>
        /// <returns>The new <see cref="ProductOptionsAvailabilityResponse"/>.</returns>
        public virtual async Task<ProductOptionsAvailabilityResponse> GetProductOptionsAvailability(string productId, IDictionary<string, string> options)
        {
            var req = PrepareRequest($"products/{productId}/productOptionsAvailability");
            HttpContent content = null;

            if (options != null)
            {
                var body = options.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<ProductOptionsAvailabilityResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Returns product variants, based on either choices (option-choice key-value pairs) or variant IDs.
        /// </summary>
        /// <param name="productId">Requested product ID.</param>
        /// <param name="query">provided paging, sorting and filtering.</param>
        /// <returns>The new <see cref="ProductQueryResponse"/>.</returns>
        public virtual async Task<QueryVariantsResponse> GetQueryProductVariantsAsync(string productId, ProductQueryVariant query)
        {
            var req = PrepareRequest($"products/{productId}/variants/query");
            HttpContent content = null;

            if (query != null)
            {
                var body = query.ToDictionary();
                content = new JsonContent(new
                {
                    productVariant = body
                });
            }
            return await ExecuteRequestAsync<QueryVariantsResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Deletes a product by ID
        /// </summary>
        /// <param name="productId"> ID of product to be deleted</param>
        /// <returns>Returns an empty object.</returns>
        public virtual async Task DeleteProductById(string productId)
        {
            var req = PrepareRequest($"products/{productId}");
            await ExecuteRequestAsync<object>(req, HttpMethod.Delete);
        }

        /// <summary>
        /// Removes specified media items from a specific product
        /// </summary>
        /// <param name="productId"> ID of product to be deleted</param>
        /// <param name="mediaIds">Media ids to remove. If not specified, all media items are removed</param>
        /// <returns>Returns an empty object.</returns>
        public virtual async Task RemoveProductMedia(string productId, List<string> mediaIds)
        {
            var req = PrepareRequest($"products/{productId}/media/delete");
            HttpContent content = null;

            if (mediaIds != null)
            {
                var body = mediaIds.ToDictionary(x => x);
                content = new JsonContent(body);
            }
            await ExecuteRequestAsync<object>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Creates new product
        /// </summary>
        /// <param name="product">Product to be created</param>
        /// <returns>The new <see cref="Entities.Product"/>.</returns>
        public virtual async Task<Entities.Product> CreateProduct(Entities.Product product)
        {
            var req = PrepareRequest($"products");
            HttpContent content = null;

            if (product != null)
            {
                var body = product.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<Entities.Product>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Delete all options from a specific product (only available when variant management is disabled)
        /// </summary>
        /// <param name="productId">Product ID</param>
        /// <returns>Returns an empty object.</returns>
        public virtual async Task DeleteProductOptions(string productId)
        {
            var req = PrepareRequest($"products/{productId}/options");
            await ExecuteRequestAsync<object>(req, HttpMethod.Delete);
        }

        /// <summary>
        /// Updates specified fields in product
        /// </summary>
        /// <param name="productId">Product ID</param>
        /// <param name="product">Product to be updated</param>
        /// <returns>The new <see cref="UpdateProductResponse"/>.</returns>
        public virtual async Task<UpdateProductResponse> UpdateProduct(string productId, Entities.Product product)
        {
            var req = PrepareRequest($"products/{productId}");
            HttpContent content = null;

            if (product != null)
            {
                var body = product.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<UpdateProductResponse>(req, HttpMethod.Patch, content);
        }

        /// <summary>
        /// Adds media items to a specified product, either via URL or existing media ID
        /// </summary>
        /// <param name="productId">Product ID</param>
        /// <param name="media">Media to be added to the product</param>
        /// <returns>Returns an empty object.</returns>
        public virtual async Task AddProductMedia(string productId, List<AddProductMedia> media)
        {
            var req = PrepareRequest($"products/{productId}/media");
            HttpContent content = null;

            if (media != null)
            {
                var body = media.ToDictionary(x => x);
                content = new JsonContent(body);
            }
            await ExecuteRequestAsync<object>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Resets all variant data to default values (price = current product price; weight = current product weight; SKU = current product SKU; visibility = true)
        /// </summary>
        /// <param name="productId">Product ID</param>
        /// <returns>Returns an empty object.</returns>
        public virtual async Task ResetAllVariantData(string productId)
        {
            var req = PrepareRequest($"products/{productId}/variants/resetToDefault");
            await ExecuteRequestAsync<object>(req, HttpMethod.Post);
        }

        /// <summary>
        /// Updates data for the specified product variant
        /// </summary>
        /// <param name="productId">Product ID</param>
        /// <param name="variants">Media to be added to the product</param>
        /// <returns>Returns an empty object.</returns>
        public virtual async Task UpdateProductVariant(string productId, List<UpdateVariantRequest> variants)
        {
            var req = PrepareRequest($"products/{productId}/variants");
            HttpContent content = null;

            if (variants != null)
            {
                var body = variants.ToDictionary(x => x);
                content = new JsonContent(body);
            }
            await ExecuteRequestAsync<object>(req, HttpMethod.Post, content);
        }
    }
}