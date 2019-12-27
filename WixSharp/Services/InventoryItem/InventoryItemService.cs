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
        /// Get item inventory status
        /// </summary>
        /// <param name="productInventoryItemId">Inventory item ID.</param>
        /// <returns>The <see cref="Entities.InventoryItem"/>.</returns>
        public virtual async Task<InventoryItemStatus> GetItemInventoryStatus(string productInventoryItemId)
        {
            var req = PrepareRequest($"inventoryItems/{productInventoryItemId}");
            return await ExecuteRequestAsync<InventoryItemStatus>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Get variant inventory status
        /// </summary>
        /// <param name="productInventoryItemId">Inventory item ID.</param>
        /// <param name="variantId">Variant ID.</param>
        /// <returns>The <see cref="VariantInventoryRequestResponse"/>.</returns>
        public virtual async Task<VariantInventoryResponse> GetVariantInventoryStatus(string productInventoryItemId, string variantId)
        {
            var req = PrepareRequest($"inventoryItems/{productInventoryItemId}/variants/{variantId}");
            return await ExecuteRequestAsync<VariantInventoryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Updates the given Item Inventory status.
        /// </summary>
        /// <param name="productInventoryItemId">Inventory item id</param>
        /// <param name="itemInventoryStatus">The <see cref="ItemInventoryStatus"/> to update.</param>
        /// <returns>Returns an empty object..</returns>
        public virtual async Task UpdateItemInventoryStatus(string productInventoryItemId, ItemInventoryStatus itemInventoryStatus)
        {
            var req = PrepareRequest($"inventoryItems/{productInventoryItemId}");
            HttpContent content = null;

            if (itemInventoryStatus != null)
            {
                var body = itemInventoryStatus.ToDictionary();
                content = new JsonContent(body);
            }
            await ExecuteRequestAsync<object>(req, new HttpMethod("Patch"), content);
        }

        /// <summary>
        /// Updates the given <see cref="Order"/>.
        /// </summary>
        /// <param name="productInventoryItemId">Inventory item id</param>
        /// <param name="variantId">Variant id</param>
        /// <param name="variantInventoryRequest">The <see cref="ItemInventoryStatus"/> to update.</param>
        /// <returns>Returns an empty object..</returns>
        public virtual async Task<object> UpdateVariantInventoryStatusAsync(string productInventoryItemId,
            string variantId, VariantInventoryResponse variantInventoryRequest)
        {
            var req = PrepareRequest($"inventoryItems/{productInventoryItemId}/variants/{variantId}");
            HttpContent content = null;

            if (variantInventoryRequest != null)
            {
                var body = variantInventoryRequest.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<object>(req, new HttpMethod("Patch"), content);
        }

        /// <summary>
        /// Get Inventory Variants  
        /// </summary>
        /// <param name="productInventoryItemId">Inventory item ID.</param>
        /// <param name="request">Inventory variants request.</param>
        /// <returns>The <see cref="VariantInventoryRequestResponse"/>.</returns>
        public virtual async Task<InventoryVariantsResponse> GetInventoryVariants(string productInventoryItemId, InventoryVariantsRequest request)
        {
            var req = PrepareRequestV2($"inventoryItems/{productInventoryItemId}/getVariants");
            HttpContent content = null;

            if (request != null)
            {
                var body = request.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<InventoryVariantsResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Query Inventory 
        /// </summary>
        /// <param name="request">Query inventory request.</param>
        /// <returns>The <see cref="VariantInventoryRequestResponse"/>.</returns>
        public virtual async Task<QueryInventoryResponse> QueryInventory(QueryInventoryRequest request)
        {
            var req = PrepareRequestV2($"inventoryItems/query");
            HttpContent content = null;

            if (request != null)    
            {
                var body = request.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<QueryInventoryResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Update Inventory Variants  
        /// </summary>
        /// <param name="productInventoryItemId">Inventory item ID.</param>
        /// <param name="request">Inventory variants request.</param>
        /// <returns>The <see cref="VariantInventoryRequestResponse"/>.</returns>
        public virtual async Task<InventoryVariantsResponse> UpdateInventoryVariants(string productInventoryItemId, UpdateInventoryVariantsRequest request)
        {
            var req = PrepareRequestV2($"inventoryItems/{productInventoryItemId}");
            HttpContent content = null;

            if (request != null)
            {
                var body = request.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<InventoryVariantsResponse>(req, HttpMethod.Post, content);
        }
    }
}