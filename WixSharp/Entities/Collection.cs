using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class Collection
    {
        /// <summary>
        /// Collection ID (generated automatically by the catalog)
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Collection name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Media items(images, videos etc) associated with this collection
        /// </summary>
        [JsonProperty("media")]
        public Media Media { get; set; }
    }

    public class CollectionResponse
    {
        /// <summary>
        /// collection object
        /// </summary>
        [JsonProperty("collection")]
        public Collection Collection { get; set; }
    }
}