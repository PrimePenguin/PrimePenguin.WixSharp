using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Entities;
using WixSharp.Infrastructure;

namespace WixSharp.Services.Order
{
    public class OrderService : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="OrderService" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public OrderService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Returns an order with the provided ID
        /// </summary>
        /// <param name="orderId">The id of the order to retrieve.</param>
        public virtual async Task<GetOrderResponse> GetAsync(string orderId)
        {
            var req = PrepareRequestForOrders($"orders/{orderId}");
            return await ExecuteRequestAsync<GetOrderResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a list of up to 100 orders, given the provided paging, sorting and filters. Hidden orders are not returned.
        /// </summary>
        /// <param name="query">provided paging, sorting and filtering.</param>
        /// <returns>The new <see cref="OrderQueryResponse"/>.</returns>
        public virtual async Task<OrderQueryResponse> GetQueryOrdersAsync(OrderRootQuery query)
        {
            var req = PrepareRequestForOrders("orders/query");
            HttpContent content = null;

            if (query != null)
            {
                var body = query.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<OrderQueryResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Creates a fulfillment (a subset of an order, with line items that are being shipped together) based on the body paramaters passed with the request. If the site owner has requested it, calling this request will trigger an email to the customer (based on the Wix store settings)
        /// </summary>
        /// <param name="orderId">Order ID to which the fulfillment will be related</param>
        /// <param name="fulfillment">Fulfillment to be created in the service</param>
        /// <returns>The new <see cref="Entities.Product"/>.</returns>
        public virtual async Task<FulFillmentResponse> CreateFulfillment(string orderId, CreateFulFillment fulfillment)
        {
            var req = PrepareRequestForOrders($"orders/{orderId}/fulfillments");
            HttpContent content = null;

            if (fulfillment != null)
            {
                var body = fulfillment.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<FulFillmentResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Updates an existing fulfillment
        /// </summary>
        /// <param name="orderId">Order ID</param>
        /// <param name="fulfillmentId">Fulfillment ID</param>
        /// <param name="fulfillmentTrackingInfo">Updated tracking info</param>
        /// <returns>Returns an empty object.</returns>
        public virtual async Task UpdateFulfillment(string orderId, string fulfillmentId,
            FulfillmentTrackingInfo fulfillmentTrackingInfo)
        {
            var req = PrepareRequestForOrders($"orders/{orderId}/fulfillments/{fulfillmentId}");
            await ExecuteRequestAsync<object>(req, HttpMethod.Put);
        }
    }
}