using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WixSharp.Infrastructure
{
    public class RequestUri
    {
        public RequestUri(Uri uri)
        {
            Url = uri;
        }

        private Uri Url;

        public Dictionary<string, object> QueryParams { get; } = new Dictionary<string, object>();

        public Uri ToUri()
        {
            // Combine the url and the query param dictionary into a uri.
            // Collection values are sent as repeated keys (e.g. fields=URL&fields=CURRENCY), as Wix expects for array params.
            var query = QueryParams.SelectMany(kvp =>
            {
                var values = kvp.Value is IEnumerable enumerable && !(kvp.Value is string)
                    ? enumerable.Cast<object>()
                    : new[] { kvp.Value };

                return values.Select(value => $"{kvp.Key}={Uri.EscapeDataString(value.ToString())}");
            });
            var ub = new UriBuilder(Url)
            {
                Query = string.Join("&", query)
            };

            return ub.Uri;
        }

        public override string ToString() => ToUri().ToString();
    }
}