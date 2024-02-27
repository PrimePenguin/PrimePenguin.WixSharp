using Newtonsoft.Json;
using System;

namespace WixSharp.Entities
{
    public class SearchOrderResponse
    {
        [JsonProperty("orders")]
        public OrderListItem[] Orders { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }

    public  class Metadata
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("cursors")]
        public Cursors Cursors { get; set; }

        [JsonProperty("hasNext")]
        public bool HasNext { get; set; }
    }

    public  class Cursors
    {
        [JsonProperty("next")]
        public string Next { get; set; }
    }

    public  class AppliedDiscount
    {
        [JsonProperty("discountType")]
        public string DiscountType { get; set; }

        [JsonProperty("lineItemIds")]
        public Guid[] LineItemIds { get; set; }

        [JsonProperty("merchantDiscount", NullValueHandling = NullValueHandling.Ignore)]
        public MerchantDiscount MerchantDiscount { get; set; }

        [JsonProperty("coupon", NullValueHandling = NullValueHandling.Ignore)]
        public Coupon Coupon { get; set; }
    }

    public  class Coupon
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public Balance Amount { get; set; }
    }

    public  class MerchantDiscount
    {
        [JsonProperty("amount")]
        public Balance Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
    
    public  class OrderCatalogReferenceOptions
    {
        [JsonProperty("variantId")]
        public Guid VariantId { get; set; }

        [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
        public OrderOptionsOptions Options { get; set; }

        [JsonProperty("customTextFields", NullValueHandling = NullValueHandling.Ignore)]
        public CustomTextFields CustomTextFields { get; set; }
    }

    public  class CustomTextFields
    {
        [JsonProperty("What would you like us to print on the custom label?")]
        public string WhatWouldYouLikeUsToPrintOnTheCustomLabel { get; set; }
    }

    public  class OrderOptionsOptions
    {
        [JsonProperty("Weight", NullValueHandling = NullValueHandling.Ignore)]
        public string Weight { get; set; }

        [JsonProperty("Ground for", NullValueHandling = NullValueHandling.Ignore)]
        public string GroundFor { get; set; }
    }

    public  class TaxSummary
    {
        [JsonProperty("totalTax")]
        public Balance TotalTax { get; set; }

        [JsonProperty("manualTaxRate", NullValueHandling = NullValueHandling.Ignore)]
        public string ManualTaxRate { get; set; }
    }

}
