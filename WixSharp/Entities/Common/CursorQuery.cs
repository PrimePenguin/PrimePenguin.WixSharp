using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities.Common
{
    /// <summary>
    /// Cursor paging options used by the newer Wix APIs (Catalog V3, Categories, eCommerce).
    /// </summary>
    public class CursorPagingOptions
    {
        /// <summary>
        /// Maximum number of items to return in the results.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Pointer to the next or previous page in the list of results.
        /// Pass the relevant cursor token from the <c>pagingMetadata</c> object in the previous call's response.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; set; }
    }

    public class Sorting
    {
        /// <summary>
        /// Name of the field to sort by, e.g. "createdDate".
        /// </summary>
        [JsonProperty("fieldName")]
        public string FieldName { get; set; }

        /// <summary>
        /// Sort order. See <see cref="SortOrder"/>.
        /// </summary>
        [JsonProperty("order")]
        public string Order { get; set; }
    }

    public static class SortOrder
    {
        public const string Ascending = "ASC";
        public const string Descending = "DESC";
    }

    /// <summary>
    /// Query object used by the newer Wix "Query" endpoints.
    /// </summary>
    public class CursorQuery
    {
        [JsonProperty("cursorPaging")]
        public CursorPagingOptions CursorPaging { get; set; }

        /// <summary>
        /// Filter object in Wix API query language, e.g. <c>{ "id": { "$in": ["..."] } }</c>.
        /// Accepts anything that serializes to that JSON shape, such as a <see cref="Newtonsoft.Json.Linq.JObject"/> or a dictionary.
        /// </summary>
        [JsonProperty("filter")]
        public object Filter { get; set; }

        [JsonProperty("sort")]
        public List<Sorting> Sort { get; set; }
    }

    /// <summary>
    /// Search object used by the newer Wix "Search" endpoints. Supports free-text search and aggregations on top of query filters.
    /// </summary>
    public class CursorSearch : CursorQuery
    {
        /// <summary>
        /// Free-text search options.
        /// </summary>
        [JsonProperty("search")]
        public SearchDetails Search { get; set; }

        /// <summary>
        /// Aggregations in Wix API query language. Accepts anything that serializes to the documented JSON shape.
        /// </summary>
        [JsonProperty("aggregations")]
        public List<object> Aggregations { get; set; }

        /// <summary>
        /// Time zone for date-time filters and aggregations, as an ISO 8601 offset or an IANA time zone.
        /// </summary>
        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }
    }

    public class SearchDetails
    {
        /// <summary>
        /// How separate search terms are combined: "OR" (any term must be present) or "AND" (all terms must be present).
        /// </summary>
        [JsonProperty("mode")]
        public string Mode { get; set; }

        /// <summary>
        /// Search term or expression.
        /// </summary>
        [JsonProperty("expression")]
        public string Expression { get; set; }

        /// <summary>
        /// Fields to search in. If empty, the endpoint's default fields are searched.
        /// </summary>
        [JsonProperty("fields")]
        public List<string> Fields { get; set; }

        /// <summary>
        /// Whether to use fuzzy search, allowing typos and a flexible search.
        /// </summary>
        [JsonProperty("fuzzy")]
        public bool? Fuzzy { get; set; }
    }
}
