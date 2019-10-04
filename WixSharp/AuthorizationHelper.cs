using System;
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
        public const string OrderCreated = "com.wix.ecommerce.orders.api.v2.OrderEvent";
        public const string AppRemoved = "AppRemoved";
    }
}
