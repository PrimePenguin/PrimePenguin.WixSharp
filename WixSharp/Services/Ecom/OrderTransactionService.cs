using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Entities.Ecom;
using WixSharp.Infrastructure;

namespace WixSharp.Services.Ecom
{
    /// <summary>
    /// A service for retrieving the payments and refunds of Wix eCommerce orders.
    /// </summary>
    public class OrderTransactionService : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="OrderTransactionService" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public OrderTransactionService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Retrieves the payments and refunds of an order.
        /// </summary>
        /// <param name="orderId">Order ID.</param>
        public virtual async Task<OrderTransactions> ListTransactionsForSingleOrderAsync(string orderId)
        {
            var req = PrepareEcomRequestV1($"payments/orders/{orderId}");
            var response = await ExecuteRequestAsync<OrderTransactionsEnvelope>(req, HttpMethod.Get);
            return response.OrderTransactions;
        }

        /// <summary>
        /// Retrieves the payments and refunds of up to 100 orders.
        /// </summary>
        /// <param name="orderIds">Order IDs.</param>
        public virtual async Task<List<OrderTransactions>> ListTransactionsForMultipleOrdersAsync(IEnumerable<string> orderIds)
        {
            var req = PrepareEcomRequestV1("payments/list-by-ids");
            var content = new JsonContent(new { orderIds });
            var response = await ExecuteRequestAsync<OrderTransactionsListEnvelope>(req, HttpMethod.Post, content);
            return response.OrderTransactions;
        }
    }
}
