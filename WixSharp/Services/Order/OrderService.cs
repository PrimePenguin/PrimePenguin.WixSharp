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
            var req = PrepareEcomRequestV1($"orders/{orderId}");
            return await ExecuteRequestAsync<GetOrderResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a list of up to 100 orders, given the provided paging, sorting and filters. Hidden orders are not returned.
        /// </summary>
        /// <param name="query">provided paging, sorting and filtering.</param>
        /// <returns>The new <see cref="OrderQueryResponse"/>.</returns>
        public virtual async Task<OrderQueryResponse> QueryOrders(OrderRootQuery query)
        {
            var req = PrepareEcomRequestV1("orders/search");
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
            var req = PrepareEcomRequestV1($"fulfillments/orders/{orderId}/create-fulfillment");
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
        public virtual async Task<Entities.Order> UpdateFulfillment(string orderId, string fulfillmentId, FulfillmentTrackingInfo fulfillmentTrackingInfo)
        {
            var req = PrepareEcomRequestV1($"fulfillments/{fulfillmentId}/orders/{orderId}");
            HttpContent content = null;

            if (fulfillmentTrackingInfo != null)
            {
                var body = fulfillmentTrackingInfo.ToDictionary();
                content = new JsonContent(body);
            }
            return await ExecuteRequestAsync<Entities.Order>(req, HttpMethod.Put, content);
        }

        /// <summary>
        /// Deletes an existing fulfillment
        /// </summary>
        /// <param name="orderId">Order ID</param>
        /// <param name="fulfillmentId">Fulfillment ID</param>
        /// <returns>Returns Updated order data.</returns>
        public virtual async Task<Entities.Order> DeleteFulfillment(string orderId, string fulfillmentId)
        {
            var req = PrepareRequestV2($"fulfillments/{fulfillmentId}/orders/{orderId}");
            return await ExecuteRequestAsync<Entities.Order>(req, HttpMethod.Delete);
        }
    }
}