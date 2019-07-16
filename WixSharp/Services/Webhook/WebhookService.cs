using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WixSharp.Entities;
using WixSharp.Infrastructure;

namespace WixSharp.Services.Webhook
{
    public class WebhookService : WixService
    {
        /// <summary>
        ///     Creates a new instance of <see cref="WebhookService" />.
        /// </summary>
        /// <param name="myWixUrl"></param>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public WebhookService(string myWixUrl, string shopAccessToken) : base(myWixUrl, shopAccessToken)
        {
        }

        /// <summary>
        ///     Gets a list of webhooks.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<WebHookModel>> ListAsync()
        {
            var req = PrepareRequest("web-hooks");
            return await ExecuteRequestAsync<List<WebHookModel>>(req, HttpMethod.Get, rootElement: "data");
        }

        /// <summary>
        ///     Retrieves the <see cref="WebHookModel" /> with the given id.
        /// </summary>
        /// <param name="webhookId">The id of the webhook to retrieve.</param>
        /// <returns>The <see cref="WebHookModel" />.</returns>
        public virtual async Task<WebHookModel> GetAsync(int webhookId)
        {
            var req = PrepareRequest($"web-hooks/{webhookId}");
            return await ExecuteRequestAsync<WebHookModel>(req, HttpMethod.Get, rootElement: "data");
        }

        /// <summary>
        ///     Creates a new <see cref="WebHookModel" /> on the store.
        ///     Please note that you should always use HTTPS when adding Webhooks in order to ensure security.
        ///     Also, there is no way to validate that the request originate from Wix, so it is important that you always
        ///     validate these event with an API call.
        ///     For example, if you receive a Webhook event regarding an order status update, validate this and retrieve the actual
        ///     data of that order using a GET to /api/v2/orders/{order-id}
        ///     All Webhook events will retry up to 10 times or until they get a 20x response. If they don't get a 20x response
        ///     they will retry again after 30 min.
        /// </summary>
        /// <param name="webhook">A new <see cref="WebHookModel" />. Id should be set to null.</param>
        /// <returns>The new <see cref="WebHookModel" />.</returns>
        public virtual async Task<WebHookModel> CreateAsync(WebHookModel webhook)
        {
            var req = PrepareRequest("web-hooks");
            var body = webhook.ToDictionary();
            var content = new JsonContent(body);

            return await ExecuteRequestAsync<WebHookModel>(req, HttpMethod.Post, content, "data");
        }

        /// <summary>
        ///     Updates the given <see cref="WebHookModel" />.
        ///     Please note that you should always use HTTPS when adding Webhooks in order to ensure security.
        ///     Also, there is no way to validate that the request originate from Wixweb, so it is important that you always
        ///     validate these event with an API call.
        ///     For example, if you receive a Webhook event regarding an order status update, validate this and retrieve the actual
        ///     data of that order using a GET to /api/v2/orders/{order-id}
        ///     All Webhook events will retry up to 10 times or until they get a 20x response. If they don't get a 20x response
        ///     they will retry again after 30 min.
        /// </summary>
        /// <param name="webhookId">Id of the object being updated.</param>
        /// <param name="webhook">The <see cref="WebHookModel" /> to update.</param>
        /// <returns>The updated <see cref="WebHookModel" />.</returns>
        public virtual async Task<WebHookModel> UpdateAsync(int webhookId, WebHookModel webhook)
        {
            var req = PrepareRequest($"web-hooks/{webhookId}");
            var body = webhook.ToDictionary();
            var content = new JsonContent(body);

            return await ExecuteRequestAsync<WebHookModel>(req, HttpMethod.Put, content, "data");
        }

        /// <summary>
        ///     Updates the given <see cref="WebHookModel" />.
        ///     Please note that you should always use HTTPS when adding Webhooks in order to ensure security.
        ///     Also, there is no way to validate that the request originate from Wixweb, so it is important that you always
        ///     validate these event with an API call.
        ///     For example, if you receive a Webhook event regarding an order status update, validate this and retrieve the actual
        ///     data of that order using a GET to /api/v2/orders/{order-id}
        ///     All Webhook events will retry up to 10 times or until they get a 20x response. If they don't get a 20x response
        ///     they will retry again after 30 min.
        /// </summary>
        /// <param name="webhookId">Id of the object being updated.</param>
        /// <param name="webhook">The <see cref="WebHookModel" /> to update.</param>
        /// <returns>The updated <see cref="WebHookModel" />.</returns>
        public virtual async Task<WebHookModel> PatchAsync(int webhookId, WebHookModel webhook)
        {
            var req = PrepareRequest($"web-hooks/{webhookId}");
            var body = webhook.ToDictionary();
            var content = new JsonContent(body);

            return await ExecuteRequestAsync<WebHookModel>(req, HttpMethod.Patch, content, "data");
        }

        /// <summary>
        ///     Deletes a webhook with the given Id.
        /// </summary>
        /// <param name="webhookId">The webhook object's Id.</param>
        public virtual async Task DeleteAsync(int webhookId)
        {
            var req = PrepareRequest($"web-hooks/{webhookId}");

            await ExecuteRequestAsync(req, HttpMethod.Delete);
        }

    }
}
