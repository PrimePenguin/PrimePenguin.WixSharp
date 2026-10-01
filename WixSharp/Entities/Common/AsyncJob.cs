using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WixSharp.Entities.Common
{
    /// <summary>
    /// An asynchronous job, such as one started by a Wix "by filter" bulk endpoint.
    /// </summary>
    public class AsyncJob
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Job metadata, such as the parameters used during job execution.
        /// </summary>
        [JsonProperty("metadata")]
        public JObject Metadata { get; set; }

        /// <summary>
        /// See <see cref="AsyncJobStatuses"/>.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("updatedDate")]
        public DateTimeOffset? UpdatedDate { get; set; }

        [JsonProperty("createdBy")]
        public JObject CreatedBy { get; set; }

        [JsonProperty("counts")]
        public AsyncJobCounts Counts { get; set; }
    }

    public class AsyncJobCounts
    {
        /// <summary>
        /// Number of items to process, when known. Can be used for progress bars.
        /// </summary>
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("successCount")]
        public int? SuccessCount { get; set; }

        [JsonProperty("failCount")]
        public int? FailCount { get; set; }

        /// <summary>
        /// Number of failures per error code.
        /// </summary>
        [JsonProperty("errorByCodeCount")]
        public JObject ErrorByCodeCount { get; set; }
    }

    public class AsyncJobItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The processed item, e.g. the updated product.
        /// </summary>
        [JsonProperty("data")]
        public JObject Data { get; set; }

        [JsonProperty("entityId")]
        public string EntityId { get; set; }

        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("error")]
        public ApplicationError Error { get; set; }
    }

    public class ListAsyncJobItemsResponse
    {
        [JsonProperty("results")]
        public List<AsyncJobItem> Results { get; set; }

        [JsonProperty("pagingMetadata")]
        public PagingMetadataV2 PagingMetadata { get; set; }
    }

    public static class AsyncJobStatuses
    {
        public const string Initialized = "INITIALIZED";
        public const string Processing = "PROCESSING";
        public const string Finished = "FINISHED";
        public const string Failed = "FAILED";
    }

    /// <summary>
    /// Values for the <c>statusFilter</c> parameter of List Async Job Items.
    /// </summary>
    public static class AsyncJobItemStatusFilters
    {
        public const string All = "ALL";
        public const string FailedOnly = "FAILED_ONLY";
        public const string SuccessfulOnly = "SUCCESSFUL_ONLY";
    }

    internal class AsyncJobEnvelope
    {
        [JsonProperty("job")]
        public AsyncJob Job { get; set; }
    }

    internal class JobIdEnvelope
    {
        [JsonProperty("jobId")]
        public string JobId { get; set; }
    }
}
