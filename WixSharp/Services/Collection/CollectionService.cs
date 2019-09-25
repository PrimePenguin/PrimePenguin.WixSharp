using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Entities;
using WixSharp.Infrastructure;

namespace WixSharp.Services.Collection
{
    /// <summary>
    /// A service for manipulating wix collection products.
    /// </summary>
    public class CollectionService : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="CollectionService" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public CollectionService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Returns a collection with the provided ID.
        /// </summary>
        /// <param name="collectionId">Requested collection ID</param>
        /// <returns>The <see cref="CollectionResponse"/>.</returns>
        public virtual async Task<CollectionResponse> GetAsync(string collectionId)
        {
            var req = PrepareRequest($"collections/{collectionId}");
            return await ExecuteRequestAsync<CollectionResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a list of up to 100 collections, given the provided paging, sorting and filtering.
        /// </summary>
        /// <param name="query">provided paging, sorting and filtering.</param>
        /// <returns>The new <see cref="CollectionQueryResponse"/>.</returns>
        public virtual async Task<CollectionQueryResponse> GetQueryCollectionsAsync(CollectionQuery query)
        {
            var req = PrepareRequest("collections/query");
            HttpContent content = null;

            if (query != null)
            {
                var body = query.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<CollectionQueryResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Adds products to a specified collection
        /// </summary>
        /// <param name="collectionId"> Id of the collection</param>
        /// <param name="productIds">IDs of products to add to the collection</param>
        /// <returns>Returns an empty object.</returns>
        public virtual async Task AddProductsToCollection(string collectionId, List<string> productIds)
        {
            var req = PrepareRequest($"collections/{collectionId}/productIds");
            HttpContent content = null;

            if (productIds != null)
            {
                var body = productIds.ToDictionary();
                content = new JsonContent(body);
            }
            await ExecuteRequestAsync<object>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Deletes products from a specified collection
        /// </summary>
        /// <param name="collectionId"> Id of the collection</param>
        /// <param name="productIds">IDs of products that will be be deleted from collection, if not provided all are deleted</param>
        /// <returns>Returns an empty object.</returns>
        public virtual async Task RemoveProductsFromCollection(string collectionId, List<string> productIds)
        {
            var req = PrepareRequest($"collections/{collectionId}/productIds/delete");
            HttpContent content = null;

            if (productIds != null)
            {
                var body = productIds.ToDictionary();
                content = new JsonContent(body);
            }
            await ExecuteRequestAsync<object>(req, HttpMethod.Post, content);
        }
    }
}