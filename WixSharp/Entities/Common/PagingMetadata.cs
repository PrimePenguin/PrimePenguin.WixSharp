using Newtonsoft.Json;

namespace WixSharp.Entities.Common
{
    public class CursorPagingMetadata
    {
        /// <summary>
        /// Number of items returned in the response.
        /// </summary>
        [JsonProperty("count")]
        public int? Count { get; set; }

        /// <summary>
        /// Cursors to navigate through the result pages.
        /// </summary>
        [JsonProperty("cursors")]
        public PagingCursors Cursors { get; set; }

        /// <summary>
        /// Whether there are more pages to retrieve following the current page.
        /// </summary>
        [JsonProperty("hasNext")]
        public bool? HasNext { get; set; }
    }

    public class PagingMetadataV2 : CursorPagingMetadata
    {
        /// <summary>
        /// Offset that was requested.
        /// </summary>
        [JsonProperty("offset")]
        public int? Offset { get; set; }

        /// <summary>
        /// Total number of items that match the query. Returned only if offset paging was used.
        /// </summary>
        [JsonProperty("total")]
        public int? Total { get; set; }
    }

    public class PagingCursors
    {
        /// <summary>
        /// Cursor string pointing to the next page in the list of results.
        /// </summary>
        [JsonProperty("next")]
        public string Next { get; set; }

        /// <summary>
        /// Cursor pointing to the previous page in the list of results.
        /// </summary>
        [JsonProperty("prev")]
        public string Prev { get; set; }
    }
}
