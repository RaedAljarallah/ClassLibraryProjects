using Moasher.APIs.Middlewares.SecurityHeaders.Constants;
using System.Collections.Generic;

namespace RJ.SecurityHeaders
{
    public class SecurityHeadersPolicy
    {
        private IDictionary<string, string> headers = new Dictionary<string, string>();
        public IDictionary<string, string> GetHeaders() => headers;


        public void AddDefaultSecurePolicy()
        {
            AddContentTypeOptions()
                .AddFrameOptionsDeny()
                .AddContentSecurityPolicy()
                .AddReferrerPolicy();
        }

        /// <summary>
        /// Add X-Frame-Options DENY to all requests.
        /// The page cannot be displayed in a frame, regardless of the site attempting to do so
        /// </summary>
        public SecurityHeadersPolicy AddFrameOptionsDeny()
        {
            AddHeader(FrameOptionsConstants.Header, FrameOptionsConstants.Deny);
            return this;
        }

        /// <summary>
        /// Add X-Frame-Options SAMEORIGIN to all requests.
        /// The page can only be displayed in a frame on the same origin as the page itself.
        /// </summary>
        public SecurityHeadersPolicy AddFrameOptionsSameOrigin()
        {
            AddHeader(FrameOptionsConstants.Header, FrameOptionsConstants.SameOrigin);
            return this;
        }

        /// <summary>
        /// Add X-Frame-Options ALLOW-FROM {uri} to all requests, where the uri is provided
        /// The page can only be displayed in a frame on the specified origin.
        /// </summary>
        /// <param name="uri">The uri of the origin in which the page may be displayed in a frame</param>
        public SecurityHeadersPolicy AddFrameOptionsSameOrigin(string uri)
        {
            AddHeader(FrameOptionsConstants.Header, string.Format(FrameOptionsConstants.AllowFromUri, uri));
            return this;
        }

        /// <summary>
        /// Add Content-Security-Policy and X-Content-Security-Policy to all requests.
        /// </summary>
        public SecurityHeadersPolicy AddContentSecurityPolicy()
        {
            AddHeader(ContentSecurityPolicyConstant.Header, ContentSecurityPolicyConstant.Csp);
            AddHeader($"X-{ContentSecurityPolicyConstant.Header}", ContentSecurityPolicyConstant.Csp);
            return this;
        }

        /// <summary>
        /// Add X-Content-Type-Options to all requests.
        /// </summary>
        public SecurityHeadersPolicy AddContentTypeOptions()
        {
            AddHeader(ContentTypeOptionsConstants.Header, ContentTypeOptionsConstants.NoSniff);
            return this;
        }

        /// <summary>
        /// Add Referrer-Policy to all requests.
        /// </summary>
        public SecurityHeadersPolicy AddReferrerPolicy()
        {
            AddHeader(ReferrerPolicyConstant.Header, ReferrerPolicyConstant.NoReferrer);
            return this;
        }

        private void AddHeader(string key, string value)
        {
            if (!headers.ContainsKey(key))
            {
                headers.Add(key, value);
            }
        }
    }
}
