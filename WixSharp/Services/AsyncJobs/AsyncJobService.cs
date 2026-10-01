using System.Net.Http;
using System.Threading.Tasks;
using WixSharp.Entities.Common;

namespace WixSharp.Services.AsyncJobs
{
    /// <summary>
    /// A service for tracking Wix asynchronous jobs, such as the jobs started by the Catalog V3 "by filter" bulk endpoints.
    /// </summary>
    public class AsyncJobService : WixService
    {
        /// <summary>
        /// Creates a new instance of <see cref="AsyncJobService" />.
        /// </summary>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public AsyncJobService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Retrieves a job's status and counts of processed items.
        /// </summary>
        /// <param name="jobId">Job ID, as returned by a "by filter" bulk endpoint.</param>
        public virtual async Task<AsyncJob> GetAsyncJobAsync(string jobId)
        {
            var req = PrepareWixApiRequest($"async-jobs/v1/async-jobs/{jobId}");
            var response = await ExecuteRequestAsync<AsyncJobEnvelope>(req, HttpMethod.Get);
            return response.Job;
        }

        /// <summary>
        /// Retrieves the items processed by a job, such as the updated products, with any errors.
        /// </summary>
        /// <param name="jobId">Job ID.</param>
        /// <param name="paging">Cursor paging options. Up to 100 items per page.</param>
        /// <param name="statusFilter">Which items to return. See <see cref="AsyncJobItemStatusFilters"/>.</param>
        public virtual async Task<ListAsyncJobItemsResponse> ListAsyncJobItemsAsync(string jobId, CursorPagingOptions paging = null, string statusFilter = null)
        {
            var req = PrepareWixApiRequest($"async-jobs/v1/async-jobs/{jobId}/items");

            if (paging?.Limit != null)
            {
                req.QueryParams.Add("paging.limit", paging.Limit);
            }

            if (!string.IsNullOrEmpty(paging?.Cursor))
            {
                req.QueryParams.Add("paging.cursor", paging.Cursor);
            }

            if (!string.IsNullOrEmpty(statusFilter))
            {
                req.QueryParams.Add("statusFilter", statusFilter);
            }

            return await ExecuteRequestAsync<ListAsyncJobItemsResponse>(req, HttpMethod.Get);
        }
    }
}
