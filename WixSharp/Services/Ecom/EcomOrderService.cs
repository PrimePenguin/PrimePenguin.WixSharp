using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Infrastructure;

namespace WixSharp.Services.Ecom
{
    // Usings are declared inside the namespace so that "Order" resolves to the eCommerce entity
    // rather than the WixSharp.Services.Order namespace.
    using WixSharp.Entities.Common;
    using WixSharp.Entities.Ecom;

    /// <summary>
    /// A service for managing Wix eCommerce orders. Works for both Catalog V1 and Catalog V3 sites.
    /// </summary>
    public class EcomOrderService : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="EcomOrderService" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public EcomOrderService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Retrieves an order.
        /// </summary>
        /// <param name="orderId">Order ID.</param>
        public virtual async Task<Order> GetOrderAsync(string orderId)
        {
            var req = PrepareEcomRequestV1($"orders/{orderId}");
            var response = await ExecuteRequestAsync<OrderEnvelope>(req, HttpMethod.Get);
            return response.Order;
        }

        /// <summary>
        /// Retrieves a list of up to 100 orders, given the provided paging, filtering, and sorting.
        /// </summary>
        /// <param name="search">
        /// Paging, filtering and sorting, e.g. a filter of <c>{ "paymentStatus": "PAID" }</c>.
        /// Pass <c>CursorPaging.Cursor</c> from the previous response's metadata to get the next page.
        /// </param>
        public virtual async Task<SearchOrdersResponse> SearchOrdersAsync(CursorSearch search = null)
        {
            var req = PrepareEcomRequestV1("orders/search");
            var content = new JsonContent(new { search });
            return await ExecuteRequestAsync<SearchOrdersResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Creates an order, for example for a phone sale or to record a sale made on an external platform.
        /// Apps not yet published in the Wix App Market are limited to 5 calls per hour per site.
        /// </summary>
        /// <param name="order">
        /// Order to create. Requires <c>ChannelInfo</c>, <c>PriceSummary</c>, and line items with quantity, product name,
        /// item type, price and tax info. Currency, weight unit and buyer language default to the site's settings.
        /// </param>
        /// <param name="settings">Order creation settings.</param>
        public virtual async Task<Order> CreateOrderAsync(Order order, OrderCreationSettings settings = null)
        {
            var req = PrepareEcomRequestV1("orders");
            var content = new JsonContent(new { order, settings });
            var response = await ExecuteRequestAsync<OrderEnvelope>(req, HttpMethod.Post, content);
            return response.Order;
        }

        /// <summary>
        /// Updates an order. Only the fields that are set are updated, e.g. <c>Archived</c>, <c>BuyerInfo</c> or shipping details.
        /// </summary>
        /// <param name="order">Order fields to update. <c>Id</c> is required.</param>
        public virtual async Task<Order> UpdateOrderAsync(Order order)
        {
            var req = PrepareEcomRequestV1($"orders/{order.Id}");
            var content = new JsonContent(new { order });
            var response = await ExecuteRequestAsync<OrderEnvelope>(req, HttpMethod.Patch, content);
            return response.Order;
        }

        /// <summary>
        /// Updates up to 100 orders. Each order requires its <c>Id</c>.
        /// </summary>
        /// <param name="orders">Order fields to update.</param>
        /// <param name="returnEntity">Whether to return the full order entities in the response.</param>
        public virtual async Task<BulkResponse<Order>> BulkUpdateOrdersAsync(IEnumerable<Order> orders, bool? returnEntity = null)
        {
            var req = PrepareEcomRequestV1("bulk/orders/update");
            var content = new JsonContent(new
            {
                orders = orders.Select(order => new { order }),
                returnEntity
            });
            return await ExecuteRequestAsync<BulkResponse<Order>>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Cancels an order.
        /// </summary>
        /// <param name="orderId">Order ID.</param>
        /// <param name="sendOrderCanceledEmail">Whether to send an order canceled email to the buyer.</param>
        /// <param name="customMessage">Custom message added to the order canceled email.</param>
        /// <param name="restockAllItems">Whether to restock all line items.</param>
        public virtual async Task<Order> CancelOrderAsync(string orderId, bool? sendOrderCanceledEmail = null, string customMessage = null, bool? restockAllItems = null)
        {
            var req = PrepareEcomRequestV1($"orders/{orderId}/cancel");
            var content = new JsonContent(new { sendOrderCanceledEmail, customMessage, restockAllItems });
            var response = await ExecuteRequestAsync<OrderEnvelope>(req, HttpMethod.Post, content);
            return response.Order;
        }

        /// <summary>
        /// Adds activities, such as merchant comments, to an order.
        /// </summary>
        /// <param name="orderId">Order ID.</param>
        /// <param name="orderActivities">Activities to add. Each requires <c>ActivityType</c>, e.g. "MERCHANT_COMMENT" with a <c>MerchantComment</c>.</param>
        public virtual async Task<AddActivitiesResponse> AddActivitiesAsync(string orderId, IEnumerable<Activity> orderActivities)
        {
            var req = PrepareEcomRequestV1($"orders/{orderId}/activities/add");
            var content = new JsonContent(new { orderId, orderActivities });
            return await ExecuteRequestAsync<AddActivitiesResponse>(req, HttpMethod.Post, content);
        }
    }
}
