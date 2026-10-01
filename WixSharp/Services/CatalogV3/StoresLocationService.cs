using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Infrastructure;

namespace WixSharp.Services.CatalogV3
{
    using WixSharp.Entities.CatalogV3;
    using WixSharp.Entities.Common;

    /// <summary>
    /// A read-only service for the inventory locations of a Wix Stores Catalog V3.
    /// Use the location IDs with <see cref="InventoryItemV3Service"/> to manage stock per location.
    /// Locations are created and updated with the Wix Locations API (with INVENTORY in their location types).
    /// </summary>
    public class StoresLocationService : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="StoresLocationService" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public StoresLocationService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Retrieves a Stores location.
        /// </summary>
        /// <param name="storesLocationId">Stores location ID.</param>
        public virtual async Task<StoresLocation> GetStoresLocationAsync(string storesLocationId)
        {
            var req = PrepareRequestV3($"locations/{storesLocationId}");
            var response = await ExecuteRequestAsync<StoresLocationEnvelope>(req, HttpMethod.Get);
            return response.StoresLocation;
        }

        /// <summary>
        /// Retrieves a list of up to 100 Stores locations, given the provided paging, filtering, and sorting,
        /// e.g. a filter of <c>{ "name": "Main Street" }</c>. The store's default location has <c>DefaultLocation</c> set to true.
        /// </summary>
        /// <param name="query">Paging, filtering and sorting.</param>
        public virtual async Task<QueryStoresLocationsResponse> QueryStoresLocationsAsync(CursorQuery query = null)
        {
            var req = PrepareRequestV3("locations/query");
            var content = new JsonContent(new { query });
            return await ExecuteRequestAsync<QueryStoresLocationsResponse>(req, HttpMethod.Post, content);
        }
    }
}
