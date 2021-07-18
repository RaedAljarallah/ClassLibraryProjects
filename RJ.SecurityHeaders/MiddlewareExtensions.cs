using Microsoft.AspNetCore.Builder;
using System;

namespace RJ.SecurityHeaders
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder app, Action<SecurityHeadersPolicy> builder = null)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var policy = new SecurityHeadersPolicy();

            if (builder == null)
            {
                policy.AddDefaultSecurePolicy();
            }
            else
            {
                builder(policy);
            }

            return app.UseMiddleware<SecurityHeadersMiddleware>(policy);
        }
    }
}
