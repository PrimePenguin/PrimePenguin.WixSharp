using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WixSharp.Entities
{
    public class OrderLineItem
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("productName")]
        public ProductName ProductName { get; set; }

        [JsonProperty("catalogReference", NullValueHandling = NullValueHandling.Ignore)]
        public OrderCatalogReferenceOptions CatalogReference { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("totalDiscount", NullValueHandling = NullValueHandling.Ignore)]
        public Balance TotalDiscount { get; set; }

        [JsonProperty("descriptionLines")]
        public DescriptionLine[] DescriptionLines { get; set; }

        [JsonProperty("image")]
        public OrderImage Image { get; set; }

        [JsonProperty("physicalProperties", NullValueHandling = NullValueHandling.Ignore)]
        public PhysicalProperties PhysicalProperties { get; set; }

        [JsonProperty("itemType", NullValueHandling = NullValueHandling.Ignore)]
        public ItemType ItemType { get; set; }

        [JsonProperty("refundQuantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? RefundQuantity { get; set; }

        [JsonProperty("price")]
        public Balance Price { get; set; }

        [JsonProperty("priceBeforeDiscounts", NullValueHandling = NullValueHandling.Ignore)]
        public Balance PriceBeforeDiscounts { get; set; }

        [JsonProperty("totalPriceBeforeTax")]
        public Balance TotalPriceBeforeTax { get; set; }

        [JsonProperty("totalPriceAfterTax")]
        public Balance TotalPriceAfterTax { get; set; }

        [JsonProperty("paymentOption")]
        public string PaymentOption { get; set; }

        [JsonProperty("taxDetails", NullValueHandling = NullValueHandling.Ignore)]
        public LineItemTaxDetails TaxDetails { get; set; }
    }

}
