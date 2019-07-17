using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Entities;
using WixSharp.Infrastructure;

namespace WixSharp.Services.InventoryItem
{
    /// <summary>
    /// A service for manipulating wix inventory items.
    /// </summary>
    public class InventoryItemService : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="InventoryItemService" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public InventoryItemService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Get the Inventory Item
        /// </summary>
        /// <param name="productInventoryItemId">Inventory item ID.</param>
        /// <returns>The <see cref="InventoryItem"/>.</returns>
        public virtual async Task<Entities.InventoryItem> GetInventoryItemAsync(string productInventoryItemId)
        {
            var req = PrepareRequest($"inventoryItems/{productInventoryItemId}");

            return await ExecuteRequestAsync<Entities.InventoryItem>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Get variant inventory status
        /// </summary>
        /// <param name="productInventoryItemId">Inventory item ID.</param>
        /// <param name="variantId">Variant ID.</param>
        /// <returns>The <see cref="VariantInventoryRequestResponse"/>.</returns>
        public virtual async Task<VariantInventoryRequestResponse> GetVariantInventoryAsync(string productInventoryItemId,
            string variantId)
        {
            var req = PrepareRequest($"inventoryItems/{productInventoryItemId}/variants/{variantId}");

            return await ExecuteRequestAsync<VariantInventoryRequestResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Updates the given <see cref="Order"/>.
        /// </summary>
        /// <param name="productInventoryItemId">Inventory item id</param>
        /// <param name="itemInventoryStatus">The <see cref="ItemInventoryStatus"/> to update.</param>
        /// <returns>Returns an empty object..</returns>
        public virtual async Task<object> UpdateItemInventoryStatusAsync(string productInventoryItemId, 
            ItemInventoryStatus itemInventoryStatus)
        {
            var req = PrepareRequest($"inventoryItems/{productInventoryItemId}");
            var content = new JsonContent(new
            {
                itemInventoryStatus
            });

            return await ExecuteRequestAsync<object>(req, HttpMethod.Patch, content);
        }

        /// <summary>
        /// Updates the given <see cref="Order"/>.
        /// </summary>
        /// <param name="productInventoryItemId">Inventory item id</param>
        /// <param name="variantId">Variant id</param>
        /// <param name="variantInventoryRequest">The <see cref="ItemInventoryStatus"/> to update.</param>
        /// <returns>Returns an empty object..</returns>
        public virtual async Task<object> UpdateVariantInventoryStatusAsync(long productInventoryItemId,
            long variantId, VariantInventoryRequestResponse variantInventoryRequest)
        {
            var req = PrepareRequest($"inventoryItems/{productInventoryItemId}/variants/{variantId}");
            var content = new JsonContent(new
            {
                variantInventoryRequest
            });

            return await ExecuteRequestAsync<object>(req, HttpMethod.Patch, content);
        }
    }
}