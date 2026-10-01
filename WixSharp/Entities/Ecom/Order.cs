using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WixSharp.Entities.Ecom
{
    // Usings are declared inside the namespace so that Common types take precedence over
    // legacy types with the same name in WixSharp.Entities.
    using WixSharp.Entities.Common;

    /// <summary>
    /// A Wix eCommerce order. Orders are shared by Wix Stores (Catalog V1 and V3), Bookings, Events and other Wix business solutions.
    /// </summary>
    public class Order
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Order number displayed in the site owner's dashboard.
        /// </summary>
        [JsonProperty("number")]
        public long? Number { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("updatedDate")]
        public DateTimeOffset? UpdatedDate { get; set; }

        /// <summary>
        /// Date and time the order was originally purchased. Differs from <see cref="CreatedDate"/> for imported orders.
        /// </summary>
        [JsonProperty("purchasedDate")]
        public DateTimeOffset? PurchasedDate { get; set; }

        [JsonProperty("lineItems")]
        public List<OrderLineItem> LineItems { get; set; }

        [JsonProperty("buyerInfo")]
        public BuyerInfo BuyerInfo { get; set; }

        /// <summary>
        /// See <see cref="OrderPaymentStatuses"/>.
        /// </summary>
        [JsonProperty("paymentStatus")]
        public string PaymentStatus { get; set; }

        /// <summary>
        /// See <see cref="OrderFulfillmentStatuses"/>.
        /// </summary>
        [JsonProperty("fulfillmentStatus")]
        public string FulfillmentStatus { get; set; }

        /// <summary>
        /// See <see cref="OrderStatuses"/>.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("buyerLanguage")]
        public string BuyerLanguage { get; set; }

        [JsonProperty("siteLanguage")]
        public string SiteLanguage { get; set; }

        /// <summary>
        /// "KG" or "LB".
        /// </summary>
        [JsonProperty("weightUnit")]
        public string WeightUnit { get; set; }

        /// <summary>
        /// ISO-4217 currency code.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("currencyConversionDetails")]
        public CurrencyConversionDetails CurrencyConversionDetails { get; set; }

        [JsonProperty("taxIncludedInPrices")]
        public bool? TaxIncludedInPrices { get; set; }

        [JsonProperty("priceSummary")]
        public PriceSummary PriceSummary { get; set; }

        [JsonProperty("billingInfo")]
        public AddressWithContact BillingInfo { get; set; }

        [JsonProperty("shippingInfo")]
        public ShippingInformation ShippingInfo { get; set; }

        /// <summary>
        /// The final recipient's address and contact details, when different from the buyer.
        /// </summary>
        [JsonProperty("recipientInfo")]
        public AddressWithContact RecipientInfo { get; set; }

        [JsonProperty("buyerNote")]
        public string BuyerNote { get; set; }

        /// <summary>
        /// Whether the order is archived (hidden from the main orders view in the dashboard).
        /// </summary>
        [JsonProperty("archived")]
        public bool? Archived { get; set; }

        [JsonProperty("taxInfo")]
        public OrderTaxInfo TaxInfo { get; set; }

        [JsonProperty("appliedDiscounts")]
        public List<AppliedDiscount> AppliedDiscounts { get; set; }

        [JsonProperty("activities")]
        public List<Activity> Activities { get; set; }

        [JsonProperty("attributionSource")]
        public string AttributionSource { get; set; }

        [JsonProperty("createdBy")]
        public CreatedBy CreatedBy { get; set; }

        [JsonProperty("channelInfo")]
        public ChannelInfo ChannelInfo { get; set; }

        [JsonProperty("seenByAHuman")]
        public bool? SeenByAHuman { get; set; }

        [JsonProperty("checkoutId")]
        public string CheckoutId { get; set; }

        /// <summary>
        /// ID correlating the cart, checkout and order of one purchase flow.
        /// </summary>
        [JsonProperty("purchaseFlowId")]
        public string PurchaseFlowId { get; set; }

        [JsonProperty("customFields")]
        public List<CustomField> CustomFields { get; set; }

        [JsonProperty("balanceSummary")]
        public BalanceSummary BalanceSummary { get; set; }

        [JsonProperty("additionalFees")]
        public List<AdditionalFee> AdditionalFees { get; set; }

        [JsonProperty("extendedFields")]
        public ExtendedFields ExtendedFields { get; set; }

        [JsonProperty("tags")]
        public OrderTags Tags { get; set; }

        [JsonProperty("businessLocation")]
        public Location BusinessLocation { get; set; }

        /// <summary>
        /// Price summary to be paid for subscriptions after a free trial period.
        /// </summary>
        [JsonProperty("payAfterFreeTrial")]
        public PriceSummary PayAfterFreeTrial { get; set; }

        [JsonProperty("platformFeeSummary")]
        public JObject PlatformFeeSummary { get; set; }

        /// <summary>
        /// Whether the order was imported from an external system.
        /// </summary>
        [JsonProperty("imported")]
        public bool? Imported { get; set; }
    }

    public class OrderLineItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("productName")]
        public TranslatableString ProductName { get; set; }

        /// <summary>
        /// Reference to the item in its origin catalog. Empty for custom line items.
        /// </summary>
        [JsonProperty("catalogReference")]
        public CatalogReference CatalogReference { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        [JsonProperty("totalDiscount")]
        public Price TotalDiscount { get; set; }

        [JsonProperty("descriptionLines")]
        public List<DescriptionLine> DescriptionLines { get; set; }

        [JsonProperty("image")]
        public WixImage Image { get; set; }

        [JsonProperty("physicalProperties")]
        public LineItemPhysicalProperties PhysicalProperties { get; set; }

        [JsonProperty("itemType")]
        public ItemType ItemType { get; set; }

        /// <summary>
        /// Fulfiller ID. Empty when the line item is self-fulfilled.
        /// </summary>
        [JsonProperty("fulfillerId")]
        public string FulfillerId { get; set; }

        [JsonProperty("refundQuantity")]
        public int? RefundQuantity { get; set; }

        [JsonProperty("restockQuantity")]
        public int? RestockQuantity { get; set; }

        /// <summary>
        /// Line item price after line item discounts, for display purposes.
        /// </summary>
        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("priceBeforeDiscounts")]
        public Price PriceBeforeDiscounts { get; set; }

        [JsonProperty("totalPriceBeforeTax")]
        public Price TotalPriceBeforeTax { get; set; }

        [JsonProperty("totalPriceAfterTax")]
        public Price TotalPriceAfterTax { get; set; }

        /// <summary>
        /// Total price after catalog discounts and line item discounts.
        /// </summary>
        [JsonProperty("lineItemPrice")]
        public Price LineItemPrice { get; set; }

        /// <summary>
        /// E.g. "FULL_PAYMENT_ONLINE", "FULL_PAYMENT_OFFLINE", "MEMBERSHIP", "DEPOSIT_ONLINE".
        /// </summary>
        [JsonProperty("paymentOption")]
        public string PaymentOption { get; set; }

        [JsonProperty("taxInfo")]
        public LineItemTaxInfo TaxInfo { get; set; }

        [JsonProperty("digitalFile")]
        public DigitalFile DigitalFile { get; set; }

        [JsonProperty("subscriptionInfo")]
        public SubscriptionInfo SubscriptionInfo { get; set; }

        [JsonProperty("priceDescription")]
        public TranslatableString PriceDescription { get; set; }

        [JsonProperty("depositAmount")]
        public Price DepositAmount { get; set; }

        [JsonProperty("locations")]
        public List<LocationAndQuantity> Locations { get; set; }

        [JsonProperty("priceUndetermined")]
        public bool? PriceUndetermined { get; set; }

        [JsonProperty("fixedQuantity")]
        public bool? FixedQuantity { get; set; }

        [JsonProperty("modifierGroups")]
        public List<JObject> ModifierGroups { get; set; }

        [JsonProperty("extendedFields")]
        public ExtendedFields ExtendedFields { get; set; }
    }

    public class CatalogReference
    {
        /// <summary>
        /// ID of the item within its catalog. For Wix Stores, the product ID.
        /// </summary>
        [JsonProperty("catalogItemId")]
        public string CatalogItemId { get; set; }

        /// <summary>
        /// ID of the app providing the catalog. For Wix Stores, "215238eb-22a5-4c36-9e7b-e7c08025e04e".
        /// </summary>
        [JsonProperty("appId")]
        public string AppId { get; set; }

        /// <summary>
        /// Catalog-specific item details. For Wix Stores this contains e.g. <c>variantId</c>,
        /// <c>options</c> (option name/key to choice) and <c>customTextFields</c>.
        /// </summary>
        [JsonProperty("options")]
        public JObject Options { get; set; }

        /// <summary>
        /// The Wix Stores variant ID, read from <see cref="Options"/>.
        /// </summary>
        [JsonIgnore]
        public string VariantId => Options?["variantId"]?.ToString();
    }

    public class TranslatableString
    {
        /// <summary>
        /// Value in the site's default language.
        /// </summary>
        [JsonProperty("original")]
        public string Original { get; set; }

        /// <summary>
        /// Value translated into the buyer's language. Defaults to <see cref="Original"/>.
        /// </summary>
        [JsonProperty("translated")]
        public string Translated { get; set; }
    }

    public class DescriptionLine
    {
        [JsonProperty("name")]
        public TranslatableString Name { get; set; }

        /// <summary>
        /// Plain text value. Set either this or <see cref="ColorInfo"/>.
        /// </summary>
        [JsonProperty("plainText")]
        public TranslatableString PlainText { get; set; }

        [JsonProperty("colorInfo")]
        public ColorInfo ColorInfo { get; set; }
    }

    public class ColorInfo : TranslatableString
    {
        /// <summary>
        /// HEX or RGB color code.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class LineItemPhysicalProperties
    {
        [JsonProperty("weight")]
        public decimal? Weight { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("shippable")]
        public bool? Shippable { get; set; }
    }

    public class ItemType
    {
        /// <summary>
        /// "PHYSICAL", "DIGITAL", "GIFT_CARD" or "SERVICE". Set either this or <see cref="Custom"/>.
        /// </summary>
        [JsonProperty("preset")]
        public string Preset { get; set; }

        [JsonProperty("custom")]
        public string Custom { get; set; }
    }

    public class LineItemTaxInfo
    {
        [JsonProperty("taxAmount")]
        public Price TaxAmount { get; set; }

        [JsonProperty("taxableAmount")]
        public Price TaxableAmount { get; set; }

        /// <summary>
        /// Tax rate as a decimal string, e.g. "0.13".
        /// </summary>
        [JsonProperty("taxRate")]
        public string TaxRate { get; set; }

        [JsonProperty("taxGroupId")]
        public string TaxGroupId { get; set; }

        [JsonProperty("taxIncludedInPrice")]
        public bool? TaxIncludedInPrice { get; set; }

        [JsonProperty("taxBreakdown")]
        public List<JObject> TaxBreakdown { get; set; }
    }

    public class DigitalFile
    {
        [JsonProperty("fileId")]
        public string FileId { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("expirationDate")]
        public DateTimeOffset? ExpirationDate { get; set; }
    }

    public class SubscriptionInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cycleNumber")]
        public int? CycleNumber { get; set; }

        [JsonProperty("subscriptionOptionTitle")]
        public string SubscriptionOptionTitle { get; set; }

        [JsonProperty("subscriptionOptionDescription")]
        public string SubscriptionOptionDescription { get; set; }

        [JsonProperty("subscriptionSettings")]
        public JObject SubscriptionSettings { get; set; }

        [JsonProperty("chargesDescription")]
        public string ChargesDescription { get; set; }
    }

    public class LocationAndQuantity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class BuyerInfo
    {
        [JsonProperty("contactId")]
        public string ContactId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Set when the buyer is a site member.
        /// </summary>
        [JsonProperty("memberId")]
        public string MemberId { get; set; }

        /// <summary>
        /// Set when the buyer is a site visitor who isn't logged in.
        /// </summary>
        [JsonProperty("visitorId")]
        public string VisitorId { get; set; }
    }

    public class Price
    {
        /// <summary>
        /// Amount as a decimal string, e.g. "3.99".
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Amount formatted with the currency symbol, e.g. "$3.99".
        /// </summary>
        [JsonProperty("formattedAmount")]
        public string FormattedAmount { get; set; }
    }

    public class CurrencyConversionDetails
    {
        [JsonProperty("originalCurrency")]
        public string OriginalCurrency { get; set; }

        [JsonProperty("conversionRate")]
        public string ConversionRate { get; set; }
    }

    public class PriceSummary
    {
        /// <summary>
        /// Subtotal of all line items, before discounts and tax.
        /// </summary>
        [JsonProperty("subtotal")]
        public Price Subtotal { get; set; }

        [JsonProperty("shipping")]
        public Price Shipping { get; set; }

        [JsonProperty("tax")]
        public Price Tax { get; set; }

        [JsonProperty("discount")]
        public Price Discount { get; set; }

        /// <summary>
        /// Order total after discounts and tax.
        /// </summary>
        [JsonProperty("total")]
        public Price Total { get; set; }

        [JsonProperty("totalAdditionalFees")]
        public Price TotalAdditionalFees { get; set; }
    }

    public class AddressWithContact
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("contactDetails")]
        public FullAddressContactDetails ContactDetails { get; set; }
    }

    public class Address
    {
        /// <summary>
        /// Two-letter ISO-3166 alpha-2 country code.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// ISO 3166-2 subdivision code, e.g. "US-NY".
        /// </summary>
        [JsonProperty("subdivision")]
        public string Subdivision { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("streetAddress")]
        public StreetAddress StreetAddress { get; set; }

        /// <summary>
        /// Main address line (usually street name and number).
        /// </summary>
        [JsonProperty("addressLine")]
        public string AddressLine { get; set; }

        /// <summary>
        /// Apartment, suite, floor etc.
        /// </summary>
        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("geocode")]
        public Geocode Geocode { get; set; }

        [JsonProperty("countryFullname")]
        public string CountryFullname { get; set; }

        [JsonProperty("subdivisionFullname")]
        public string SubdivisionFullname { get; set; }
    }

    public class StreetAddress
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Geocode
    {
        [JsonProperty("latitude")]
        public decimal? Latitude { get; set; }

        [JsonProperty("longitude")]
        public decimal? Longitude { get; set; }
    }

    public class FullAddressContactDetails
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// Tax information (Brazil only).
        /// </summary>
        [JsonProperty("vatId")]
        public VatId VatId { get; set; }
    }

    public class VatId
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// "CPF" or "CNPJ".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class ShippingInformation
    {
        /// <summary>
        /// App ID of the external shipping provider.
        /// </summary>
        [JsonProperty("carrierId")]
        public string CarrierId { get; set; }

        /// <summary>
        /// Code of the selected shipping option, e.g. "usps_std_overnight".
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("logistics")]
        public DeliveryLogistics Logistics { get; set; }

        [JsonProperty("cost")]
        public ShippingPrice Cost { get; set; }

        [JsonProperty("region")]
        public ShippingRegion Region { get; set; }
    }

    public class DeliveryLogistics
    {
        /// <summary>
        /// Shipping address and contact details. Set either this or <see cref="PickupDetails"/>.
        /// </summary>
        [JsonProperty("shippingDestination")]
        public AddressWithContact ShippingDestination { get; set; }

        [JsonProperty("pickupDetails")]
        public PickupDetails PickupDetails { get; set; }

        /// <summary>
        /// Expected delivery time in free text, e.g. "3-5 business days".
        /// </summary>
        [JsonProperty("deliveryTime")]
        public string DeliveryTime { get; set; }

        [JsonProperty("instructions")]
        public string Instructions { get; set; }

        [JsonProperty("deliveryTimeSlot")]
        public DeliveryTimeSlot DeliveryTimeSlot { get; set; }
    }

    public class PickupDetails
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        /// <summary>
        /// "STORE_PICKUP" or "PICKUP_POINT".
        /// </summary>
        [JsonProperty("pickupMethod")]
        public string PickupMethod { get; set; }
    }

    public class DeliveryTimeSlot
    {
        [JsonProperty("from")]
        public DateTimeOffset? From { get; set; }

        [JsonProperty("to")]
        public DateTimeOffset? To { get; set; }
    }

    public class ShippingPrice
    {
        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("totalPriceBeforeTax")]
        public Price TotalPriceBeforeTax { get; set; }

        [JsonProperty("totalPriceAfterTax")]
        public Price TotalPriceAfterTax { get; set; }

        [JsonProperty("taxInfo")]
        public LineItemTaxInfo TaxInfo { get; set; }

        [JsonProperty("discount")]
        public Price Discount { get; set; }
    }

    public class ShippingRegion
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class OrderTaxInfo
    {
        [JsonProperty("totalTax")]
        public Price TotalTax { get; set; }

        [JsonProperty("taxBreakdown")]
        public List<OrderTaxBreakdown> TaxBreakdown { get; set; }

        [JsonProperty("taxExempt")]
        public bool? TaxExempt { get; set; }
    }

    public class OrderTaxBreakdown
    {
        [JsonProperty("taxName")]
        public string TaxName { get; set; }

        [JsonProperty("taxType")]
        public string TaxType { get; set; }

        [JsonProperty("jurisdiction")]
        public string Jurisdiction { get; set; }

        [JsonProperty("jurisdictionType")]
        public string JurisdictionType { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("aggregatedTaxAmount")]
        public Price AggregatedTaxAmount { get; set; }
    }

    public class AppliedDiscount
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// "GLOBAL", "SPECIFIC_ITEMS" or "SHIPPING".
        /// </summary>
        [JsonProperty("discountType")]
        public string DiscountType { get; set; }

        /// <summary>
        /// Line items the discount applies to, with the discount amount for each.
        /// </summary>
        [JsonProperty("lineItemDiscounts")]
        public List<LineItemDiscount> LineItemDiscounts { get; set; }

        /// <summary>
        /// Set when the discount comes from a coupon.
        /// </summary>
        [JsonProperty("coupon")]
        public Coupon Coupon { get; set; }

        /// <summary>
        /// Set when the discount was applied manually by the merchant.
        /// </summary>
        [JsonProperty("merchantDiscount")]
        public MerchantDiscount MerchantDiscount { get; set; }

        /// <summary>
        /// Set when the discount comes from an automatic discount rule.
        /// </summary>
        [JsonProperty("discountRule")]
        public DiscountRule DiscountRule { get; set; }
    }

    public class LineItemDiscount
    {
        /// <summary>
        /// Line item ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("totalDiscount")]
        public Price TotalDiscount { get; set; }
    }

    public class Coupon
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public Price Amount { get; set; }
    }

    public class MerchantDiscount
    {
        [JsonProperty("amount")]
        public Price Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("discountReason")]
        public string DiscountReason { get; set; }
    }

    public class DiscountRule
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public TranslatableString Name { get; set; }

        [JsonProperty("amount")]
        public Price Amount { get; set; }
    }

    /// <summary>
    /// An order activity, such as a merchant comment, payment or refund event.
    /// </summary>
    public class Activity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("authorEmail")]
        public string AuthorEmail { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset? CreatedDate { get; set; }

        /// <summary>
        /// E.g. "ORDER_PLACED", "ORDER_PAID", "ORDER_FULFILLED", "MERCHANT_COMMENT", "PAYMENT_REFUNDED".
        /// </summary>
        [JsonProperty("activityType")]
        public string ActivityType { get; set; }

        /// <summary>
        /// Set when <see cref="ActivityType"/> is "MERCHANT_COMMENT".
        /// </summary>
        [JsonProperty("merchantComment")]
        public MerchantComment MerchantComment { get; set; }

        /// <summary>
        /// Set when <see cref="ActivityType"/> is "ORDER_REFUNDED".
        /// </summary>
        [JsonProperty("orderRefunded")]
        public OrderRefunded OrderRefunded { get; set; }

        /// <summary>
        /// Details of other activity types (e.g. <c>paymentRefunded</c>, <c>refundInitiated</c>, <c>receiptCreated</c>),
        /// keyed by their JSON property name.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }

    public class MerchantComment
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class OrderRefunded
    {
        [JsonProperty("manual")]
        public bool? Manual { get; set; }

        [JsonProperty("amount")]
        public Price Amount { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }

    /// <summary>
    /// The order's initiator. Exactly one of the IDs is set.
    /// </summary>
    public class CreatedBy
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("memberId")]
        public string MemberId { get; set; }

        [JsonProperty("visitorId")]
        public string VisitorId { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }
    }

    public class ChannelInfo
    {
        /// <summary>
        /// Sales channel, e.g. "WEB", "POS", "EBAY", "AMAZON", "FACEBOOK", "ETSY", "TIKTOK", "OTHER_PLATFORM".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("externalOrderId")]
        public string ExternalOrderId { get; set; }

        [JsonProperty("externalOrderUrl")]
        public string ExternalOrderUrl { get; set; }
    }

    public class CustomField
    {
        /// <summary>
        /// Custom field value. Can be any JSON value.
        /// </summary>
        [JsonProperty("value")]
        public JToken Value { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("translatedTitle")]
        public string TranslatedTitle { get; set; }
    }

    public class BalanceSummary
    {
        /// <summary>
        /// Amount left to pay. A negative amount is an amount to be refunded.
        /// </summary>
        [JsonProperty("balance")]
        public Price Balance { get; set; }

        [JsonProperty("paid")]
        public Price Paid { get; set; }

        [JsonProperty("refunded")]
        public Price Refunded { get; set; }

        [JsonProperty("authorized")]
        public Price Authorized { get; set; }

        [JsonProperty("pendingRefund")]
        public Price PendingRefund { get; set; }

        [JsonProperty("pending")]
        public Price Pending { get; set; }

        [JsonProperty("chargeback")]
        public Price Chargeback { get; set; }

        [JsonProperty("chargebackReversal")]
        public Price ChargebackReversal { get; set; }
    }

    public class AdditionalFee
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("priceBeforeTax")]
        public Price PriceBeforeTax { get; set; }

        [JsonProperty("priceAfterTax")]
        public Price PriceAfterTax { get; set; }

        [JsonProperty("taxInfo")]
        public LineItemTaxInfo TaxInfo { get; set; }

        [JsonProperty("providerAppId")]
        public string ProviderAppId { get; set; }

        [JsonProperty("lineItemIds")]
        public List<string> LineItemIds { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public class OrderTags
    {
        [JsonProperty("privateTags")]
        public TagList PrivateTags { get; set; }

        [JsonProperty("tags")]
        public TagList Tags { get; set; }
    }

    public class Location
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public static class OrderStatuses
    {
        public const string Initialized = "INITIALIZED";
        public const string Approved = "APPROVED";
        public const string Canceled = "CANCELED";
        public const string Pending = "PENDING";
        public const string Rejected = "REJECTED";
    }

    public static class OrderPaymentStatuses
    {
        public const string NotPaid = "NOT_PAID";
        public const string Paid = "PAID";
        public const string PartiallyRefunded = "PARTIALLY_REFUNDED";
        public const string FullyRefunded = "FULLY_REFUNDED";
        public const string Pending = "PENDING";
        public const string PartiallyPaid = "PARTIALLY_PAID";
        public const string PendingMerchant = "PENDING_MERCHANT";
        public const string Canceled = "CANCELED";
        public const string Declined = "DECLINED";
    }

    public static class OrderFulfillmentStatuses
    {
        public const string NotFulfilled = "NOT_FULFILLED";
        public const string Fulfilled = "FULFILLED";
        public const string PartiallyFulfilled = "PARTIALLY_FULFILLED";
    }
}
