using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using WixSharp.Entities;

namespace WixSharp
{
    public static class AuthorizationHelper
    {
        public static TokenValidationParameters GetTokenValidationParameters(string key)
        {
            var rs256Token = key.Replace("-----BEGIN PUBLIC KEY-----", "");
            rs256Token = rs256Token.Replace("-----END PUBLIC KEY-----", "");
            rs256Token = rs256Token.Replace("\n", "");

            var keyBytes = Convert.FromBase64String(rs256Token);

            var asymmetricKeyParameter = PublicKeyFactory.CreateKey(keyBytes);
            var rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
            var rsaParameters = new RSAParameters
            {
                Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned(),
                Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned()
            };
            var rsa = new RSACryptoServiceProvider();

            rsa.ImportParameters(rsaParameters);

            var validationParameters = new TokenValidationParameters()
            {
                RequireExpirationTime = false,
                RequireSignedTokens = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new RsaSecurityKey(rsa)
            };

            return validationParameters;
        }

        public static WixHookPayload GetRequestPayload(string requestBody, string publicKey)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetTokenValidationParameters(publicKey);

            jwtHandler.ValidateToken(requestBody, validationParameters, out var _);

            var securityToken = jwtHandler.ReadToken(requestBody);

            var payload = ((JwtSecurityToken)securityToken).Payload["data"].ToString();
            if (string.IsNullOrEmpty(payload)) return null;

            return JsonConvert.DeserializeObject<WixHookPayload>(payload);
        }
    }

    public static class WixHookEventType
    {
        public const string ProductChanged = "com.wix.ecommerce.catalog.api.v1.ProductChanged";
        public const string ProductCreated = "com.wix.ecommerce.catalog.api.v1.ProductCreated";
        public const string ProductDeleted = "com.wix.ecommerce.catalog.api.v1.ProductDeleted";
        public const string VariantsChanged = "com.wix.ecommerce.catalog.api.v1.VariantsChanged";
        public const string InventoryVariantsChanged = "com.wix.ecommerce.inventory.api.v1.InventoryVariantsChanged";

        public static List<string> OrderEvents = new List<string> {"OrderPaid", "OrderEvent" , "OrderCanceled", "OrderRefunded", "FulfillmentCreated" };
        public const string AppRemoved = "AppRemoved";

        // Domain events, named "{entityFqdn}_{slug}". Their data can be parsed with WixDomainEvent.Parse.
        // Sites on Catalog V3 only send the V3 catalog events, so subscribe to both V1 and V3 events to support all sites.
        public const string ProductV3Created = "wix.stores.catalog.v3.product_created";
        public const string ProductV3Updated = "wix.stores.catalog.v3.product_updated";
        public const string ProductV3Deleted = "wix.stores.catalog.v3.product_deleted";
        public const string InventoryItemV3Created = "wix.stores.catalog.v3.inventory_item_created";
        public const string InventoryItemV3Updated = "wix.stores.catalog.v3.inventory_item_updated";
        public const string InventoryItemV3Deleted = "wix.stores.catalog.v3.inventory_item_deleted";
        public const string InventoryItemV3UpdatedWithReason = "wix.stores.catalog.v3.inventory_item_updated_with_reason";
        public const string CategoryCreated = "wix.categories.v1.category_created";
        public const string CategoryUpdated = "wix.categories.v1.category_updated";
        public const string CategoryDeleted = "wix.categories.v1.category_deleted";
        // Wix documents these action event slugs, but not full example event types; they follow the "{entityFqdn}_{slug}" rule.
        public const string CategoryMoved = "wix.categories.v1.category_category_moved";
        public const string CategoryItemAdded = "wix.categories.v1.category_item_added_to_category";
        public const string CategoryItemRemoved = "wix.categories.v1.category_item_removed_from_category";
        public const string CategoryItemsArranged = "wix.categories.v1.category_items_arranged_in_category";
        public const string EcomOrderCreated = "wix.ecom.v1.order_created";
        public const string EcomOrderUpdated = "wix.ecom.v1.order_updated";
        public const string EcomOrderApproved = "wix.ecom.v1.order_approved";
        public const string EcomOrderCanceled = "wix.ecom.v1.order_canceled";
        public const string EcomOrderPaymentStatusUpdated = "wix.ecom.v1.order_payment_status_updated";
        public const string EcomOrderFulfillmentsUpdated = "wix.ecom.v1.fulfillments_updated";
    }
}
