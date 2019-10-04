using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class WixHookPayload
    {
        [JsonProperty("data")] public string Data { get; set; }
        [JsonProperty("instanceId")] public string InstanceId { get; set; }
        [JsonProperty("eventType")] public string EventType { get; set; }
    }
}