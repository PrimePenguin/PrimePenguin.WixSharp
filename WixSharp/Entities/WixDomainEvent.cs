using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WixSharp.Entities
{
    /// <summary>
    /// The data of a Wix domain event webhook, such as the Catalog V3 and eCommerce order events in <see cref="WixHookEventType"/>.
    /// </summary>
    public class WixDomainEvent
    {
        private static readonly JsonSerializerSettings _Settings = new JsonSerializerSettings
        {
            // Keep date strings as strings so they deserialize exactly into the entity's properties.
            DateParseHandling = DateParseHandling.None
        };

        /// <summary>
        /// Unique event ID. Use it to ignore duplicate events.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Fully qualified domain name of the entity, e.g. "wix.stores.catalog.v3.product".
        /// </summary>
        [JsonProperty("entityFqdn")]
        public string EntityFqdn { get; set; }

        /// <summary>
        /// Event name, e.g. "created", "updated", "deleted", "approved".
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// ID of the entity the event is about.
        /// </summary>
        [JsonProperty("entityId")]
        public string EntityId { get; set; }

        [JsonProperty("eventTime")]
        public DateTimeOffset? EventTime { get; set; }

        [JsonProperty("triggeredByAnonymizeRequest")]
        public bool? TriggeredByAnonymizeRequest { get; set; }

        [JsonProperty("originatedFrom")]
        public string OriginatedFrom { get; set; }

        [JsonProperty("createdEvent")]
        public JObject CreatedEvent { get; set; }

        [JsonProperty("updatedEvent")]
        public JObject UpdatedEvent { get; set; }

        [JsonProperty("deletedEvent")]
        public JObject DeletedEvent { get; set; }

        [JsonProperty("actionEvent")]
        public JObject ActionEvent { get; set; }

        /// <summary>
        /// For update events, the fields that changed and their values before the update.
        /// </summary>
        [JsonIgnore]
        public JObject ModifiedFields => UpdatedEvent?["modifiedFields"] as JObject;

        /// <summary>
        /// For delete events, whether the entity was moved to the trash rather than permanently deleted.
        /// </summary>
        [JsonIgnore]
        public bool? MovedToTrash => DeletedEvent?["movedToTrash"]?.Value<bool?>();

        /// <summary>
        /// Parses the <see cref="WixHookPayload.Data"/> of a domain event webhook.
        /// </summary>
        public static WixDomainEvent Parse(string data)
        {
            return JsonConvert.DeserializeObject<WixDomainEvent>(data, _Settings);
        }

        /// <summary>
        /// Returns the event's entity: the created entity, the entity after an update, the deleted entity,
        /// or the body of an action event. Returns default if the event has none.
        /// </summary>
        /// <typeparam name="T">
        /// Entity type, e.g. <c>WixSharp.Entities.CatalogV3.Product</c>, <c>WixSharp.Entities.Ecom.Order</c>,
        /// or <c>WixSharp.Entities.Ecom.OrderActionEventBody</c> for order action events such as Order Approved.
        /// </typeparam>
        public T GetEntity<T>()
        {
            // Wix sends either the "...AsJson" or the plain property name, depending on the event.
            var token = CreatedEvent?["entityAsJson"] ?? CreatedEvent?["entity"]
                ?? UpdatedEvent?["currentEntityAsJson"] ?? UpdatedEvent?["currentEntity"]
                ?? DeletedEvent?["deletedEntityAsJson"] ?? DeletedEvent?["deletedEntity"]
                ?? ActionEvent?["bodyAsJson"] ?? ActionEvent?["body"];

            if (token == null || token.Type == JTokenType.Null)
            {
                return default(T);
            }

            // Depending on the delivery, the entity is either a JSON object or a JSON string containing the object.
            if (token.Type == JTokenType.String)
            {
                return JsonConvert.DeserializeObject<T>(token.Value<string>(), _Settings);
            }

            return token.ToObject<T>();
        }
    }
}
