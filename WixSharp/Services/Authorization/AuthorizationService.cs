﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WixSharp.Infrastructure;

namespace WixSharp.Services.Authorization
{
    public class AuthorizationService
    {
        private static readonly Regex _querystringRegex = new Regex(@"[?|&]([\w\.]+)=([^?|^&]+)", RegexOptions.Compiled);

       /// <remarks>
        /// Source for this method: https://stackoverflow.com/a/22046389
        /// </remarks>
        public static IDictionary<string, string> ParseRawQuerystring(string qs)
        {
            // Must use an absolute uri, else Uri.Query throws an InvalidOperationException
            var uri = new UriBuilder("http://localhost:3000")
            {
                Query = Uri.UnescapeDataString(qs)
            }.Uri;
            var match = _querystringRegex.Match(uri.PathAndQuery);
            var paramaters = new Dictionary<string, string>();
            while (match.Success)
            {
                paramaters.Add(match.Groups[1].Value, match.Groups[2].Value);
                match = match.NextMatch();
            }
            return paramaters;
        }
        private static string EncodeQuery(StringValues values, bool isKey)
        {
            string s = values.FirstOrDefault();

            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            //Important: Replace % before replacing &. Else second replace will replace those %25s.
            string output = (s.Replace("%", "%25").Replace("&", "%26")) ?? "";

            if (isKey)
            {
                output = output.Replace("=", "%3D");
            }

            return output;
        }

        private static string PrepareQuerystring(IEnumerable<KeyValuePair<string, StringValues>> querystring, string joinWith)
        {
            var kvps = querystring.Select(kvp => new
            {
                Key = EncodeQuery(kvp.Key, true),
                Value = EncodeQuery(kvp.Value, false)
            })
                .Where(kvp => kvp.Key != "signature" && kvp.Key != "hmac")
                .OrderBy(kvp => kvp.Key, StringComparer.Ordinal)
                .Select(kvp => $"{kvp.Key}={kvp.Value}");

            return string.Join(joinWith, kvps);
        }

        /// <summary>
        /// Authorizes an application installation, generating an access token for the given shop.
        /// </summary>
        /// <param name="code">The authorization code generated by Wix, which should be a parameter named 'code' on the request querystring.</param>
        /// <param name="wixAppKey">Your app's public API key.</param>
        /// <param name="wixAppSecretKey">Your app's secret key.</param>
        /// <returns>The authorization result.</returns>
        public static async Task<WixAuthorizationResult> AuthorizeWithResult(string code, string wixAppKey, string wixAppSecretKey)
        {
            var ub = new UriBuilder(WixService.BuildWixUri("www.wix.com"))
            {
                Path = "oauth/access"
            };
            var content = new JsonContent(new
            {
                code,
                client_secret = wixAppSecretKey,
                client_id = wixAppKey,
                grant_type = "authorization_code"
            });

            using (var client = new HttpClient())
            using (var msg = new CloneableRequestMessage(ub.Uri, HttpMethod.Post, content))
            {
                var request = client.SendAsync(msg);
                var response = await request;
                var rawDataString = await response.Content.ReadAsStringAsync();

                WixService.CheckResponseExceptions(response, rawDataString);
                return JsonConvert.DeserializeObject<WixAuthorizationResult>(rawDataString);
            }
        }

        /// <summary>
        /// Authorizes an application installation, generating an access token for the given shop.
        /// </summary>
        /// <param name="code">The authorization code generated by Wix, which should be a parameter named 'code' on the request querystring.</param>
        /// <param name="wixUrl">The store's *.myWixUrl.com URL, which should be a parameter named 'shop' on the request querystring.</param>
        /// <param name="wixAppKey">Your app's public API key.</param>
        /// <param name="wixAppSecretKey">Your app's secret key.</param>
        /// <returns>The shop access token.</returns>
        public static async Task<WixAuthorizationResult> Authorize(string code, string wixAppKey, string wixAppSecretKey)
        {
            return (await AuthorizeWithResult(code, wixAppKey, wixAppSecretKey));
        }

        /// <summary>
        /// Determines if an incoming request is authentic.
        /// </summary>
        /// <param name="querystring">A dictionary containing the keys and values from the request's querystring.</param>
        /// <param name="wixAppSecretKey">Your app's secret key.</param>
        /// <returns>A boolean indicating whether the request is authentic or not.</returns>
        public static bool IsAuthenticRequest(IDictionary<string, string> querystring, string wixAppSecretKey)
        {
            var qs = querystring.Select(kvp => new KeyValuePair<string, StringValues>(kvp.Key, kvp.Value));

            return IsAuthenticRequest(qs, wixAppSecretKey);
        }

        /// <summary>
        /// Determines if an incoming request is authentic.
        /// </summary>
        /// <param name="querystring">The request's raw querystring.</param>
        /// <param name="wixAppSecretKey">Your app's secret key.</param>
        /// <returns>A boolean indicating whether the request is authentic or not.</returns>
        public static bool IsAuthenticRequest(string querystring, string wixAppSecretKey)
        {
            return IsAuthenticRequest(ParseRawQuerystring(querystring), wixAppSecretKey);
        }

        /// <summary>
        /// Determines if an incoming request is authentic.
        /// </summary>
        /// <param name="querystring">The collection of querystring parameters from the request. Hint: use Request.QueryString if you're calling this from an ASP.NET MVC controller.</param>
        /// <param name="wixAppSecretKey">Your app's secret key.</param>
        /// <returns>A boolean indicating whether the request is authentic or not.</returns>
        public static bool IsAuthenticRequest(IEnumerable<KeyValuePair<string, StringValues>> querystring, string wixAppSecretKey)
        {
            // To calculate HMAC signature:
            // 1. Cast querystring to KVP pairs.
            // 2. Remove `signature` and `hmac` keys.
            // 3. Replace & with %26, % with %25 in keys and values.
            // 4. Replace = with %3D in keys only.
            // 5. Join each key and value with = (key=value).
            // 6. Sorty kvps alphabetically.
            // 7. Join kvps together with & (key=value&key=value&key=value).
            // 8. Compute the kvps with an HMAC-SHA256 using the secret key.
            // 9. Request is authentic if the computed string equals the `hash` in query string.
            // Reference: https://docs.shopify.com/api/guides/authentication/oauth#making-authenticated-requests
            var hmacValues = querystring.FirstOrDefault(kvp => kvp.Key == "hmac").Value;

            if (string.IsNullOrEmpty(hmacValues) || hmacValues.Count() < 1)
            {
                return false;
            }

            string hmac = hmacValues.First();
            string kvps = PrepareQuerystring(querystring, "&");
            var hmacHasher = new HMACSHA256(Encoding.UTF8.GetBytes(wixAppSecretKey));
            var hash = hmacHasher.ComputeHash(Encoding.UTF8.GetBytes(string.Join("&", kvps)));

            //Convert bytes back to string, replacing dashes, to get the final signature.
            var calculatedSignature = BitConverter.ToString(hash).Replace("-", "");

            //Request is valid if the calculated signature matches the signature from the querystring.
            return calculatedSignature.ToUpper() == hmac.ToUpper();
        }

        /// <summary>
        /// Builds an authorization URL for Wix OAuth integration.
        /// </summary>
        /// <param name="wixUrl">The shop's *.mywix.com URL.</param>
        /// <param name="wixAppId">Your wix app Id</param>
        /// <param name="redirectUrl">URL to redirect the user to after integration.</param>
        /// <param name="state">An optional, random string value provided by your application which is unique for each authorization request. During the OAuth callback phase, your application should check that this value matches the one you provided to this method.</param>
        /// <returns>The authorization url.</returns>
        public static Uri BuildAuthorizationUrlUsingToken(string wixUrl,string wixAppId, string redirectUrl, string state = null)
        {
            if (string.IsNullOrEmpty(wixUrl)) wixUrl = "www.wix.com";

            //Prepare a uri builder for the shop URL
            var builder = new UriBuilder(WixService.BuildWixUri(wixUrl));

            //Build the querystring
            var qs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("appId", wixAppId),
                new KeyValuePair<string, string>("redirectUrl", redirectUrl)
            };

            if (string.IsNullOrEmpty(state) == false)
            {
                qs.Add(new KeyValuePair<string, string>("state", state));
            }

            builder.Path = "/app-oauth-installation/consent";
            builder.Query = string.Join("&", qs.Select(s => $"{s.Key}={s.Value}"));

            return builder.Uri;
        }

        /// <summary>
        /// Builds an authorization URL for Wix OAuth integration.
        /// </summary>
        /// <param name="wixUrl">The shop's *.mywix.com URL.</param>
        /// <param name="wixAppId">Your wix app Id</param>
        /// <param name="redirectUrl">URL to redirect the user to after integration.</param>
        /// <param name="state">An optional, random string value provided by your application which is unique for each authorization request. During the OAuth callback phase, your application should check that this value matches the one you provided to this method.</param>
        /// <returns>The authorization url.</returns>
        public static Uri BuildAuthorizationUrl(string wixUrl, string wixAppId, string redirectUrl, string state = null)
        {
            return BuildAuthorizationUrlUsingToken(wixUrl, wixAppId, redirectUrl, state);
        }

        /// <summary>
        /// Authorizes an application installation, generating an access token for the given shop.
        /// </summary>
        /// <param name="clientId">App id</param>
        /// <param name="clientSecret">App secret key</param>
        /// <param name="refreshToken">refresh token.</param>
        /// <returns>The shop access token.</returns>
        public static async Task<WixAuthorizationResult> GenerateNewAccessToken
            (string clientId, string clientSecret, string refreshToken)
        {
            var ub = new UriBuilder(WixService.BuildWixUri("www.wix.com"))
            {
                Path = "oauth/access"
            };

            var content = new JsonContent(new
            {
                refresh_token = refreshToken,
                client_secret = clientSecret,
                client_id = clientId,
                grant_type = "refresh_token"
            });

            using (var client = new HttpClient())
            using (var msg = new CloneableRequestMessage(ub.Uri, HttpMethod.Post, content))
            {
                var request = client.SendAsync(msg);
                var response = await request;
                var rawDataString = await response.Content.ReadAsStringAsync();

                WixService.CheckResponseExceptions(response, rawDataString);
                return JsonConvert.DeserializeObject<WixAuthorizationResult>(rawDataString);
            }
        }

        /// <summary>
        /// Generate new access token using refresh token
        /// </summary>
        /// <param name="clientId">App id</param>
        /// <param name="clientSecret">App secret key</param>
        /// <param name="refreshToken">refresh token.</param>
        /// <returns>The access token.</returns>
        public static async Task<WixAuthorizationResult> GetAccessToken(string clientId, string clientSecret,string refreshToken)
        {
            return (await GenerateNewAccessToken(clientId, clientSecret, refreshToken));
        }
    }
}