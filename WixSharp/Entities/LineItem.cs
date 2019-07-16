using System.Collections.Generic;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class LineItem
    {
        /// <summary>
        /// Line item weight
        /// </summary>
        [JsonProperty("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// Line item name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Line item quantity
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Line item sku
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Line item type(may be extended)
        /// </summary>
        [JsonProperty("lineItemType")]
        public LineItemType LineItemType { get; set; }

        /// <summary>
        /// Line item price
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }

        /// <summary>
        /// Total price charged to the customer (for all line items) after computation of quantity and discount
        /// </summary>
        [JsonProperty("totalPrice")]
        public string TotalPrice { get; set; }

        /// <summary>
        /// Line item options ordered
        /// </summary>
        [JsonProperty("options")]
        public IEnumerable<LineItemOption> Options { get; set; }

        /// <summary>
        /// Line item's custom text field selections
        /// </summary>
        [JsonProperty("customTextFields")]
        public IEnumerable<CustomTextField> CustomTextFields { get; set; }

        /// <summary>
        /// Line item product ID (optional for POS orders)
        /// </summary>
        [JsonProperty("productId")]
        public string ProductId { get; set; }

        /// <summary>
        /// Line item notes
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Line item's primary media for preview
        /// </summary>
        [JsonProperty("mediaItem")]
        public MediaItem MediaItem { get; set; }
    }

    public enum LineItemType
    {
        UNSPECIFIED_LINE_ITEM_TYPE = 0,
        PHYSICAL = 1,
        DIGITAL = 2,
        CUSTOM_AMOUNT_ITEM = 3
    }
}