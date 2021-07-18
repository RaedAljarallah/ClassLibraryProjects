namespace Moasher.APIs.Middlewares.SecurityHeaders.Constants
{
    public static class ContentSecurityPolicyConstant
    {
        /// <summary>
        /// Header value for Content-Security-Policy
        /// </summary>
        public static readonly string Header = "Content-Security-Policy";

        /// <summary>
        /// Disables all Content-Security-Policy content
        /// </summary>
        public static readonly string Csp = "default-src 'self'; object-src 'none'; frame-ancestors 'none'; sandbox allow-forms allow-same-origin allow-scripts; base-uri 'self'; upgrade-insecure-requests;";
    }
}
