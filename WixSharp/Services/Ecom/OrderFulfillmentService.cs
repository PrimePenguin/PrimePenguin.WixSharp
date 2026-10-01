using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Entities.Ecom;
using WixSharp.Infrastructure;

namespace WixSharp.Services.Ecom
{
    /// <summary>
    /// A service for managing the fulfillments of Wix eCommerce orders.
    /// </summary>
    public class OrderFulfillmentService : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="OrderFulfillmentService" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public OrderFulfillmentService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Retrieves the fulfillments of an order.
        /// </summary>
        /// <param name="orderId">Order ID.</param>
        public virtual async Task<OrderWithFulfillments> ListFulfillmentsForSingleOrderAsync(string orderId)
        {
            var req = PrepareEcomRequestV1($"fulfillments/orders/{orderId}");
            var response = await ExecuteRequestAsync<FulfillmentResponse>(req, HttpMethod.Get);
            return response.OrderWithFulfillments;
        }

        /// <summary>
        /// Retrieves the fulfillments of up to 100 orders.
        /// </summary>
        /// <param name="orderIds">Order IDs.</param>
        public virtual async Task<ListFulfillmentsForMultipleOrdersResponse> ListFulfillmentsForMultipleOrdersAsync(IEnumerable<string> orderIds)
        {
            var req = PrepareEcomRequestV1("fulfillments/list-by-ids");
            var content = new JsonContent(new { orderIds });
            return await ExecuteRequestAsync<ListFulfillmentsForMultipleOrdersResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Creates a fulfillment for an order. Depending on the store's settings, this may email the buyer.
        /// </summary>
        /// <param name="orderId">Order ID.</param>
        /// <param name="fulfillment">Fulfillment to create. Requires line items; set <c>TrackingInfo</c> for shipped items.</param>
        /// <returns>The order's fulfillments and the ID of the new fulfillment.</returns>
        public virtual async Task<FulfillmentResponse> CreateFulfillmentAsync(string orderId, Fulfillment fulfillment)
        {
            var req = PrepareEcomRequestV1($"fulfillments/orders/{orderId}/create-fulfillment");
            var content = new JsonContent(new { fulfillment });
            return await ExecuteRequestAsync<FulfillmentResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Updates a fulfillment, e.g. its tracking info or status.
        /// </summary>
        /// <param name="orderId">Order ID.</param>
        /// <param name="fulfillment">Fulfillment fields to update. <c>Id</c> is required.</param>
        public virtual async Task<OrderWithFulfillments> UpdateFulfillmentAsync(string orderId, Fulfillment fulfillment)
        {
            var req = PrepareEcomRequestV1($"fulfillments/{fulfillment.Id}/orders/{orderId}");
            var content = new JsonContent(new { fulfillment });
            var response = await ExecuteRequestAsync<FulfillmentResponse>(req, HttpMethod.Patch, content);
            return response.OrderWithFulfillments;
        }

        /// <summary>
        /// Deletes a fulfillment.
        /// </summary>
        /// <param name="orderId">Order ID.</param>
        /// <param name="fulfillmentId">ID of the fulfillment to delete.</param>
        /// <returns>The order's remaining fulfillments.</returns>
        public virtual async Task<OrderWithFulfillments> DeleteFulfillmentAsync(string orderId, string fulfillmentId)
        {
            var req = PrepareEcomRequestV1($"fulfillments/{fulfillmentId}/orders/{orderId}");
            var response = await ExecuteRequestAsync<FulfillmentResponse>(req, HttpMethod.Delete);
            return response.OrderWithFulfillments;
        }

        /// <summary>
        /// Creates fulfillments for up to 100 orders.
        /// </summary>
        /// <param name="ordersWithFulfillments">Order IDs and the fulfillments to create for each.</param>
        public virtual async Task<BulkCreateFulfillmentsResponse> BulkCreateFulfillmentsAsync(IEnumerable<OrderWithFulfillments> ordersWithFulfillments)
        {
            var req = PrepareEcomRequestV1("fulfillments/orders/bulk/create-fulfillments");
            var content = new JsonContent(new { ordersWithFulfillments });
            return await ExecuteRequestAsync<BulkCreateFulfillmentsResponse>(req, HttpMethod.Post, content);
        }
    }
}
