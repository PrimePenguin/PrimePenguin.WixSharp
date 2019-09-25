using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class MediaChoice
    {
        [JsonProperty("option")] public string Option { get; set; }

        [JsonProperty("choice")] public string Choice { get; set; }
    }
}