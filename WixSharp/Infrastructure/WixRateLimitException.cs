using System.Collections.Generic;
using System.Net;

namespace WixSharp
{
    /// <summary>
    /// An exception thrown when an API call has reached Wix's rate limit.
    /// </summary>
    public class WixRateLimitException : WixException
    {
        public WixRateLimitException()
        { }

        public WixRateLimitException(string message): base(message) { }

        public WixRateLimitException(HttpStatusCode httpStatusCode, Dictionary<string, IEnumerable<string>> errors, string message, string jsonError, string requestId) : base(httpStatusCode, errors, message, jsonError, requestId) { }
    }
}
