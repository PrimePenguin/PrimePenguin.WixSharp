using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class QueryInventoryRequest
    {
        [JsonProperty("query")] public Query Query { get; set; }
    }
}
