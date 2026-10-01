using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Infrastructure;

namespace WixSharp.Services.CatalogV3
{
    // Usings are declared inside the namespace so that "InventoryItem" resolves to the V3 entity
    // rather than the WixSharp.Services.InventoryItem namespace.
    using WixSharp.Entities.CatalogV3;
    using WixSharp.Entities.Common;

    /// <summary>
    /// A service for managing inventory items in a Wix Stores Catalog V3.
    /// An inventory item holds the stock of one product variant at one location.
    /// Only use it for sites where <see cref="CatalogVersionService"/> reports V3_CATALOG.
    /// </summary>
    public class InventoryItemV3Service : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="InventoryItemV3Service" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public InventoryItemV3Service(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Creates an inventory item.
        /// </summary>
        /// <param name="inventoryItem">Inventory item to create. Requires <c>VariantId</c>, <c>ProductId</c>, and either <c>InStock</c> or <c>Quantity</c>.</param>
        public virtual async Task<InventoryItem> CreateInventoryItemAsync(InventoryItem inventoryItem)
        {
            var req = PrepareRequestV3("inventory-items");
            var content = new JsonContent(new { inventoryItem });
            var response = await ExecuteRequestAsync<InventoryItemEnvelope>(req, HttpMethod.Post, content);
            return response.InventoryItem;
        }

        /// <summary>
        /// Retrieves an inventory item.
        /// </summary>
        /// <param name="inventoryItemId">Inventory item ID.</param>
        public virtual async Task<InventoryItem> GetInventoryItemAsync(string inventoryItemId)
        {
            var req = PrepareRequestV3($"inventory-items/{inventoryItemId}");
            var response = await ExecuteRequestAsync<InventoryItemEnvelope>(req, HttpMethod.Get);
            return response.InventoryItem;
        }

        /// <summary>
        /// Updates an inventory item. Only the fields that are set are updated.
        /// To change the tracking method, set <c>Quantity</c> (track quantity) or <c>InStock</c> (track status).
        /// </summary>
        /// <param name="inventoryItem">Inventory item fields to update. <c>Id</c> and the current <c>Revision</c> are required.</param>
        /// <param name="reason">Reason for the change. See <see cref="InventoryChangeReasons"/>.</param>
        public virtual async Task<InventoryItem> UpdateInventoryItemAsync(InventoryItem inventoryItem, string reason = null)
        {
            var req = PrepareRequestV3($"inventory-items/{inventoryItem.Id}");
            var content = new JsonContent(new { inventoryItem, reason });
            var response = await ExecuteRequestAsync<InventoryItemEnvelope>(req, HttpMethod.Patch, content);
            return response.InventoryItem;
        }

        /// <summary>
        /// Deletes an inventory item.
        /// </summary>
        /// <param name="inventoryItemId">ID of the inventory item to delete.</param>
        public virtual async Task DeleteInventoryItemAsync(string inventoryItemId)
        {
            var req = PrepareRequestV3($"inventory-items/{inventoryItemId}");
            await ExecuteRequestAsync<object>(req, HttpMethod.Delete);
        }

        /// <summary>
        /// Retrieves a list of up to 1,000 inventory items, given the provided paging, filtering, and sorting.
        /// For example, filter by <c>productId</c> to get all inventory items of a product.
        /// </summary>
        /// <param name="query">Paging, filtering and sorting.</param>
        public virtual async Task<QueryInventoryItemsResponse> QueryInventoryItemsAsync(CursorQuery query = null)
        {
            var req = PrepareRequestV3("inventory-items/query");
            var content = new JsonContent(new { query });
            return await ExecuteRequestAsync<QueryInventoryItemsResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Retrieves a list of inventory items, given the provided free-text search, filtering, sorting, and aggregations.
        /// </summary>
        /// <param name="search">Search, paging, filtering, sorting and aggregations.</param>
        public virtual async Task<SearchInventoryItemsResponse> SearchInventoryItemsAsync(CursorSearch search = null)
        {
            var req = PrepareRequestV3("inventory-items/search");
            var content = new JsonContent(new { search });
            return await ExecuteRequestAsync<SearchInventoryItemsResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Creates up to 1,000 inventory items.
        /// </summary>
        /// <param name="inventoryItems">Inventory items to create.</param>
        /// <param name="returnEntity">Whether to return the full inventory item entities in the response.</param>
        public virtual async Task<BulkResponse<InventoryItem>> BulkCreateInventoryItemsAsync(IEnumerable<InventoryItem> inventoryItems, bool? returnEntity = null)
        {
            var req = PrepareRequestV3("bulk/inventory-items/create");
            var content = new JsonContent(new { inventoryItems, returnEntity });
            return await ExecuteRequestAsync<BulkResponse<InventoryItem>>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Updates up to 1,000 inventory items. Each item requires its <c>Id</c> and current <c>Revision</c>.
        /// </summary>
        /// <param name="inventoryItems">Inventory item fields to update.</param>
        /// <param name="reason">Reason for the change. See <see cref="InventoryChangeReasons"/>.</param>
        /// <param name="returnEntity">Whether to return the full inventory item entities in the response.</param>
        public virtual async Task<BulkResponse<InventoryItem>> BulkUpdateInventoryItemsAsync(IEnumerable<InventoryItem> inventoryItems, string reason = null, bool? returnEntity = null)
        {
            var req = PrepareRequestV3("bulk/inventory-items/update");
            var content = new JsonContent(new
            {
                inventoryItems = inventoryItems.Select(inventoryItem => new { inventoryItem }),
                reason,
                returnEntity
            });
            return await ExecuteRequestAsync<BulkResponse<InventoryItem>>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Deletes up to 1,000 inventory items.
        /// </summary>
        /// <param name="inventoryItemIds">IDs of the inventory items to delete.</param>
        public virtual async Task<BulkResponse<InventoryItem>> BulkDeleteInventoryItemsAsync(IEnumerable<string> inventoryItemIds)
        {
            var req = PrepareRequestV3("bulk/inventory-items/delete");
            var content = new JsonContent(new { inventoryItemIds });
            return await ExecuteRequestAsync<BulkResponse<InventoryItem>>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Updates all inventory items that match the filter, as an asynchronous job.
        /// </summary>
        /// <param name="inventoryItem">Inventory item fields to set on every matching item, e.g. <c>InStock</c> or <c>PreorderInfo</c>.</param>
        /// <param name="filter">Filter object in Wix API query language, e.g. <c>{ "productId": "..." }</c>.</param>
        /// <param name="search">Free-text search options.</param>
        /// <returns>The job ID. Track it with <see cref="AsyncJobs.AsyncJobService"/>.</returns>
        public virtual async Task<string> BulkUpdateInventoryItemsByFilterAsync(InventoryItem inventoryItem, object filter, SearchDetails search = null)
        {
            var req = PrepareRequestV3("bulk/inventory-items/update-by-filter");
            var content = new JsonContent(new { inventoryItem, filter, search });
            var response = await ExecuteRequestAsync<JobIdEnvelope>(req, HttpMethod.Post, content);
            return response.JobId;
        }

        /// <summary>
        /// Increments the quantities of up to 300 inventory items, identified by inventory item ID.
        /// The items must be tracking quantity.
        /// </summary>
        /// <param name="incrementData">Inventory item IDs and amounts to increment by.</param>
        /// <param name="reason">Reason for the change. See <see cref="InventoryChangeReasons"/>.</param>
        /// <param name="returnEntity">Whether to return the full inventory item entities in the response.</param>
        public virtual async Task<BulkResponse<InventoryItem>> BulkIncrementInventoryItemsAsync(IEnumerable<InventoryIncrementData> incrementData, string reason = null, bool? returnEntity = null)
        {
            var req = PrepareRequestV3("bulk/inventory-items/increment");
            var content = new JsonContent(new { incrementData, reason, returnEntity });
            return await ExecuteRequestAsync<BulkResponse<InventoryItem>>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Decrements the quantities of up to 300 inventory items, identified by inventory item ID.
        /// The items must be tracking quantity.
        /// </summary>
        /// <param name="decrementData">Inventory item IDs and amounts to decrement by.</param>
        /// <param name="reason">Reason for the change. See <see cref="InventoryChangeReasons"/>.</param>
        /// <param name="restrictInventory">
        /// <c>true</c>: the request fails with INSUFFICIENT_INVENTORY when an amount exceeds the stock.
        /// <c>false</c>: quantities may go negative. When unset, Wix doesn't allow negative inventory.
        /// </param>
        /// <param name="returnEntity">Whether to return the full inventory item entities in the response.</param>
        public virtual async Task<BulkResponse<InventoryItem>> BulkDecrementInventoryItemsAsync(IEnumerable<InventoryDecrementData> decrementData, string reason = null, bool? restrictInventory = null, bool? returnEntity = null)
        {
            var req = PrepareRequestV3("bulk/inventory-items/decrement");
            var content = new JsonContent(new { decrementData, reason, restrictInventory, returnEntity });
            return await ExecuteRequestAsync<BulkResponse<InventoryItem>>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Increments the quantities of up to 300 inventory items, identified by variant ID and location ID
        /// (the default location when no location ID is passed). The items must be tracking quantity.
        /// </summary>
        /// <param name="incrementData">Variant and location IDs and amounts to increment by.</param>
        /// <param name="reason">Reason for the change. See <see cref="InventoryChangeReasons"/>.</param>
        /// <param name="returnEntity">Whether to return the full inventory item entities in the response.</param>
        public virtual async Task<BulkResponse<InventoryItem>> BulkIncrementInventoryItemsByVariantAndLocationAsync(IEnumerable<VariantLocationIncrementData> incrementData, string reason = null, bool? returnEntity = null)
        {
            var req = PrepareRequestV3("bulk/inventory-items/increment-by-variant-and-location");
            var content = new JsonContent(new { incrementData, reason, returnEntity });
            return await ExecuteRequestAsync<BulkResponse<InventoryItem>>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Decrements the quantities of up to 300 inventory items, identified by variant ID and location ID
        /// (the default location when no location ID is passed). The items must be tracking quantity.
        /// </summary>
        /// <param name="decrementData">Variant and location IDs and amounts to decrement by.</param>
        /// <param name="reason">Reason for the change. See <see cref="InventoryChangeReasons"/>.</param>
        /// <param name="restrictInventory">
        /// <c>true</c>: the request fails with INSUFFICIENT_INVENTORY when an amount exceeds the stock.
        /// <c>false</c>: quantities may go negative. When unset, Wix doesn't allow negative inventory.
        /// </param>
        /// <param name="returnEntity">Whether to return the full inventory item entities in the response.</param>
        public virtual async Task<BulkResponse<InventoryItem>> BulkDecrementInventoryItemsByVariantAndLocationAsync(IEnumerable<VariantLocationDecrementData> decrementData, string reason = null, bool? restrictInventory = null, bool? returnEntity = null)
        {
            var req = PrepareRequestV3("bulk/inventory-items/decrement-by-variant-and-location");
            var content = new JsonContent(new { decrementData, reason, restrictInventory, returnEntity });
            return await ExecuteRequestAsync<BulkResponse<InventoryItem>>(req, HttpMethod.Post, content);
        }
    }
}
