namespace WixSharp.Services.Authorization
{
    public class AuthorizationResult
    {
        public string AccessToken { get; }

        private string refreshToken { get; }

        public string[] GrantedScopes { get; }

        internal AuthorizationResult(string accessToken,string refreshToken, string[] grantedScopes)
        {
            AccessToken = accessToken;
            this.refreshToken = refreshToken;
            GrantedScopes = grantedScopes;
        }
    }

    public class WixAuthorizationResult
    {
        public string refresh_token { get; set; }
        public string access_token { get; set; }

        internal WixAuthorizationResult(string accessToken, string refreshToken)
        {
            refresh_token = refreshToken;
            access_token = accessToken;
        }
    }
}
