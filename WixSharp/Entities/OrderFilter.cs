using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public  class OrderFilter
    {
        [JsonProperty("search")]
        public Search Search { get; set; }
    }

    public  class Search
    {
        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("sort")]
        public Sort[] Sort { get; set; }

        [JsonProperty("cursor_paging")]
        public CursorPaging CursorPaging { get; set; }
    }

    public  class CursorPaging
    {
        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }
    }

    public  class Sort
    {
        [JsonProperty("fieldName")]
        public string FieldName { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }
    }
}
