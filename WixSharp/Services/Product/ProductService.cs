using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
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
        /// <param name="myWixUrl">The shop's *.mywix.com URL.</param>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public ProductService(string myWixUrl, string shopAccessToken) : base(shopAccessToken, myWixUrl)
        {
        }

        /// <summary>
        /// Retrieves the <see cref="WixSharp.Services.Product"/> with the given id.
        /// </summary>
        /// <param name="productId">The id of the product to retrieve.</param>
        /// <returns>The <see cref="WixSharp.Services.Product"/>.</returns>
        public virtual async Task<ProductResponse> GetAsync(string productId)
        {
            var req = PrepareRequest($"products/{productId}");

            return await ExecuteRequestAsync<ProductResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Gets the availability of relevant product variants based on the product ID and selections provided. 
        /// </summary>
        /// <param name="productId">The id of the product to retrieve.</param>
        /// <param name="options">Array containing the selected options (e.g, color: Blue, size: Large)</param>
        /// <returns>The new <see cref="Entities.ProductOptionsAvailabilityResponse"/>.</returns>
        public virtual async Task<ProductOptionsAvailabilityResponse> GetProductOptionsAvailability(string productId,
            List<string> options)
        {
            var req = PrepareRequest($"products/{productId}/productOptionsAvailability");
            HttpContent content = null;

            if (options != null)
            {
                var body = options.ToDictionary();
                 content = new JsonContent(new
                {
                    productVariant = body
                });
            }

            return await ExecuteRequestAsync<ProductOptionsAvailabilityResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Returns a list of up to 100 products, given the provided paging, sorting and filtering.Hidden products are not returned.
        /// </summary>
        /// <param name="query">provided paging, sorting and filtering.</param>
        /// <returns>The new <see cref="Entities.ProductQueryResponse"/>.</returns>
        public virtual async Task<ProductQueryResponse> GetQueryProductsAsync(ProductQuery query)
        {
            var req = PrepareRequest("products/query");
            var body = query.ToDictionary();

            var content = new JsonContent(new
            {
                productVariant = body
            });

            return await ExecuteRequestAsync<ProductQueryResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Returns product variants, based on either choices (option-choice key-value pairs) or variant IDs.
        /// </summary>
        /// <param name="productId">Requested product ID.</param>
        /// <param name="query">provided paging, sorting and filtering.</param>
        /// <returns>The new <see cref="Entities.ProductQueryResponse"/>.</returns>
        public virtual async Task<QueryVariantsResponse> GetQueryProductVariantsAsync(string productId,
            ProductQueryVariant query)
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
    }
}