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

            return await ExecuteRequestAsync<Entities.GetOrderResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a list of up to 100 orders, given the provided paging, sorting and filters. Hidden orders are not returned.
        /// </summary>
        /// <param name="query">provided paging, sorting and filtering.</param>
        /// <returns>The new <see cref="OrderQueryResponse"/>.</returns>
        public virtual async Task<OrderQueryResponse> GetQueryOrdersAsync(OrderQuery query)
        {
            var req = PrepareRequestForOrders("orders/query");
            HttpContent content = null;

            if (query != null)
            {
                var body = query.ToDictionary();
                content = new JsonContent(new
                {
                    productVariant = body
                });
            }

            return await ExecuteRequestAsync<OrderQueryResponse>(req, HttpMethod.Post, content);
        }
    }
}