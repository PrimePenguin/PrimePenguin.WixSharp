using System;
using Newtonsoft.Json;

namespace WixSharp.Entities
{
    public class OrderResponse
    {
        [JsonProperty("order")] 
        public OrderDetail Order { get; set; }
    }

    public class OrderActivity
    {
        [JsonProperty("createdDate")] 
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("type")] 
        public string Type { get; set; }
    }

    public class BalanceSummary
    {
        [JsonProperty("balance")] 
        public Balance Balance { get; set; }

        [JsonProperty("paid")]
        public Balance Paid { get; set; }

        [JsonProperty("refunded")] 
        public Balance Refunded { get; set; }
    }

    public class Balance
    {
        [JsonProperty("amount")] 
        public string Amount { get; set; }

        [JsonProperty("formattedAmount")] 
        public string FormattedAmount { get; set; }
    }

    public class OrderBillingInfo
    {
        [JsonProperty("address")] 
        public OrderAddress Address { get; set; }

        [JsonProperty("contactDetails")] 
        public ContactDetails ContactDetails { get; set; }
    }

   
    public class OrderBuyerInfo
    {
        [JsonProperty("contactId")] 
        public Guid ContactId { get; set; }

        [JsonProperty("email")] 
        public string Email { get; set; }

        [JsonProperty("memberId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? MemberId { get; set; }

        [JsonProperty("visitorId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? VisitorId { get; set; }
    }

    public class OrderChannelInfo
    {
        [JsonProperty("type")] 
        public string Type { get; set; }
    }

    public class CreatedBy
    {
        [JsonProperty("visitorId")] 
        public Guid VisitorId { get; set; }
    }

    public class CatalogReference
    {
        [JsonProperty("catalogItemId")] 
        public Guid CatalogItemId { get; set; }

        [JsonProperty("appId")] 
        public Guid AppId { get; set; }

        [JsonProperty("options")] 
        public CatalogReferenceOptions Options { get; set; }
    }

    public class CatalogReferenceOptions
    {
        [JsonProperty("options")] 
        public OptionsOptions Options { get; set; }

        [JsonProperty("variantId")] 
        public Guid VariantId { get; set; }
    }

    public class OptionsOptions
    {
        [JsonProperty("Color")] 
        public string Color { get; set; }

        [JsonProperty("Size", NullValueHandling = NullValueHandling.Ignore)]
        public string Size { get; set; }
    }

    public class DescriptionLine
    {
        [JsonProperty("name")] 
        public ProductName Name { get; set; }

        [JsonProperty("colorInfo", NullValueHandling = NullValueHandling.Ignore)]
        public ProductName ColorInfo { get; set; }

        [JsonProperty("plainText", NullValueHandling = NullValueHandling.Ignore)]
        public ProductName PlainText { get; set; }
    }

    public class ProductName
    {
        [JsonProperty("original")] 
        public string Original { get; set; }

        [JsonProperty("translated")] 
        public string Translated { get; set; }
    }

    public class OrderImage
    {
        [JsonProperty("id")] 
        public string Id { get; set; }

        [JsonProperty("url")] 
        public Uri Url { get; set; }

        [JsonProperty("height")] 
        public long Height { get; set; }

        [JsonProperty("width")] 
        public long Width { get; set; }
    }

    public class ItemType
    {
        [JsonProperty("preset")] 
        public string Preset { get; set; }
    }

    public class PhysicalProperties
    {
        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public long? Weight { get; set; }

        [JsonProperty("sku")] 
        public string Sku { get; set; }

        [JsonProperty("shippable")] 
        public bool Shippable { get; set; }
    }

    public class LineItemTaxDetails
    {
        [JsonProperty("taxableAmount")] 
        public Balance TaxableAmount { get; set; }

        [JsonProperty("taxRate")] 
        public string TaxRate { get; set; }

        [JsonProperty("totalTax")] 
        public Balance TotalTax { get; set; }
    }

    public class PayNow
    {
        [JsonProperty("subtotal")] 
        public Balance Subtotal { get; set; }

        [JsonProperty("shipping")] 
        public Balance Shipping { get; set; }

        [JsonProperty("tax")] 
        public Balance Tax { get; set; }

        [JsonProperty("discount")] 
        public Balance Discount { get; set; }

        [JsonProperty("total")] 
        public Balance Total { get; set; }

        [JsonProperty("totalAdditionalFees", NullValueHandling = NullValueHandling.Ignore)]
        public Balance TotalAdditionalFees { get; set; }
    }

    public class OrderShippingInfo
    {
        [JsonProperty("carrierId")] 
        public Guid CarrierId { get; set; }

        [JsonProperty("code")] 
        public Guid Code { get; set; }

        [JsonProperty("title")] 
        public string Title { get; set; }

        [JsonProperty("logistics")] 
        public Logistics Logistics { get; set; }

        [JsonProperty("cost")] 
        public Cost Cost { get; set; }

        [JsonProperty("region")] 
        public Region Region { get; set; }
    }

    public class Cost
    {
        [JsonProperty("price")] 
        public Balance Price { get; set; }

        [JsonProperty("totalPriceBeforeTax")] 
        public Balance TotalPriceBeforeTax { get; set; }

        [JsonProperty("totalPriceAfterTax")] 
        public Balance TotalPriceAfterTax { get; set; }

        [JsonProperty("taxDetails")] 
        public CostTaxDetails TaxDetails { get; set; }

        [JsonProperty("discount")] 
        public Balance Discount { get; set; }
    }

    public class CostTaxDetails
    {
        [JsonProperty("taxRate")] 
        public string TaxRate { get; set; }

        [JsonProperty("totalTax")] 
        public Balance TotalTax { get; set; }
    }

    public class Logistics
    {
        [JsonProperty("deliveryTime")] 
        public string DeliveryTime { get; set; }

        [JsonProperty("shippingDestination")] 
        public BillingInfo ShippingDestination { get; set; }
    }

    public class Region
    {
        [JsonProperty("name")] 
        public string Name { get; set; }
    }

    public enum PaymentStatus
    {
        UNSPECIFIED_PAYMENT_STATUS,
        NOT_PAID,
        PAID,
        PARTIALLY_REFUNDED,
        FULLY_REFUNDED,
        PENDING
    }

    public enum WeightUnit
    {
        UNSPECIFIED_WEIGHT_UNIT,
        KG,
        LB
    }

    public enum FulfillmentStatus
    {
        PENDING,
        ACCEPTED,
        READY,
        IN_DELIVERY,
        FULFILLED
    }

}