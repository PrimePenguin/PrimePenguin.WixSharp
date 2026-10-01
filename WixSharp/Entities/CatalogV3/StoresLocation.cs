using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities.CatalogV3
{
    using WixSharp.Entities.Common;

    /// <summary>
    /// A Wix Stores inventory location. Read-only: locations are created and updated with the Wix Locations API,
    /// and appear here when their location types include INVENTORY.
    /// </summary>
    public class StoresLocation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("revision")]
        public string Revision { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("updatedDate")]
        public DateTimeOffset? UpdatedDate { get; set; }

        /// <summary>
        /// ID of the location in the Wix Locations API.
        /// </summary>
        [JsonProperty("wixLocationId")]
        public string WixLocationId { get; set; }

        /// <summary>
        /// "VIRTUAL" (online store) or "PHYSICAL" (for example, POS).
        /// </summary>
        [JsonProperty("locationType")]
        public string LocationType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Whether this is the store's default location, from which online orders deduct inventory.
        /// </summary>
        [JsonProperty("defaultLocation")]
        public bool? DefaultLocation { get; set; }
    }

    public class QueryStoresLocationsResponse
    {
        [JsonProperty("storesLocations")]
        public List<StoresLocation> StoresLocations { get; set; }

        [JsonProperty("pagingMetadata")]
        public CursorPagingMetadata PagingMetadata { get; set; }
    }

    internal class StoresLocationEnvelope
    {
        [JsonProperty("storesLocation")]
        public StoresLocation StoresLocation { get; set; }
    }
}
