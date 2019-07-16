using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Entities;
using WixSharp.Infrastructure;

namespace WixSharp.Services.Collection
{
    public class CollectionService : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="CollectionService" />.
        /// </summary>
        /// <param name="myWixUrl">The shop's *.mywix.com URL.</param>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public CollectionService(string myWixUrl, string shopAccessToken) : base(shopAccessToken, myWixUrl)
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
                content = new JsonContent(new
                {
                    productVariant = body
                });
            }

            return await ExecuteRequestAsync<CollectionQueryResponse>(req, HttpMethod.Post, content);
        }
    }
}
