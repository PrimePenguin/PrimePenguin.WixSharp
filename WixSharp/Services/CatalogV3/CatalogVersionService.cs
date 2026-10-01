using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Entities.CatalogV3;

namespace WixSharp.Services.CatalogV3
{
    /// <summary>
    /// A service for determining which Wix Stores catalog version (V1 or V3) a site uses.
    /// The two versions aren't backwards compatible, so call this at the start of a flow to choose between
    /// the V1 services (ProductService, InventoryItemService, CollectionService) and the V3 services
    /// (<see cref="ProductV3Service"/>, <see cref="InventoryItemV3Service"/>, <see cref="CategoryService"/>).
    /// A site's catalog version only ever changes from V1 to V3.
    /// </summary>
    public class CatalogVersionService : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="CatalogVersionService" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public CatalogVersionService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Retrieves the version of the Stores catalog installed on the site.
        /// </summary>
        public virtual async Task<GetCatalogVersionResponse> GetCatalogVersionAsync()
        {
            var req = PrepareRequestV3("provision/version");
            return await ExecuteRequestAsync<GetCatalogVersionResponse>(req, HttpMethod.Get);
        }
    }
}
