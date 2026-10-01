using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WixSharp.Entities.Common
{
    /// <summary>
    /// Response of a Wix bulk endpoint.
    /// </summary>
    /// <typeparam name="T">The entity type returned for each item when <c>returnEntity</c> is <c>true</c>.</typeparam>
    public class BulkResponse<T>
    {
        [JsonProperty("results")]
        public List<BulkItemResult<T>> Results { get; set; }

        [JsonProperty("bulkActionMetadata")]
        public BulkActionMetadata BulkActionMetadata { get; set; }
    }

    public class BulkItemResult<T>
    {
        /// <summary>
        /// Information about a successful action or the error for a failure.
        /// </summary>
        [JsonProperty("itemMetadata")]
        public ItemMetadata ItemMetadata { get; set; }

        /// <summary>
        /// The full entity. Returned only when <c>returnEntity: true</c> is passed in the request.
        /// </summary>
        [JsonProperty("item")]
        public T Item { get; set; }
    }

    /// <summary>
    /// Response of a Wix bulk endpoint that doesn't return entities.
    /// </summary>
    public class BulkActionResponse
    {
        [JsonProperty("results")]
        public List<BulkActionResult> Results { get; set; }

        [JsonProperty("bulkActionMetadata")]
        public BulkActionMetadata BulkActionMetadata { get; set; }
    }

    public class BulkActionResult
    {
        [JsonProperty("itemMetadata")]
        public ItemMetadata ItemMetadata { get; set; }
    }

    public class ItemMetadata
    {
        /// <summary>
        /// Item ID. Not returned when an item couldn't be created.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Index of the item within the request array.
        /// </summary>
        [JsonProperty("originalIndex")]
        public int? OriginalIndex { get; set; }

        /// <summary>
        /// Whether the requested action was successful for this item.
        /// </summary>
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Details about the error in case of failure.
        /// </summary>
        [JsonProperty("error")]
        public ApplicationError Error { get; set; }
    }

    public class BulkActionMetadata
    {
        [JsonProperty("totalSuccesses")]
        public int? TotalSuccesses { get; set; }

        [JsonProperty("totalFailures")]
        public int? TotalFailures { get; set; }

        /// <summary>
        /// Number of failures without details because the detailed failure threshold was exceeded.
        /// </summary>
        [JsonProperty("undetailedFailures")]
        public int? UndetailedFailures { get; set; }
    }

    public class ApplicationError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("data")]
        public JObject Data { get; set; }
    }
}
