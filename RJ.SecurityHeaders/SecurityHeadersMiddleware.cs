using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace RJ.SecurityHeaders
{
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate next;
        private readonly SecurityHeadersPolicy policy;

        public SecurityHeadersMiddleware(RequestDelegate next, SecurityHeadersPolicy policy)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            this.policy = policy ?? throw new ArgumentNullException(nameof(policy));
        }

        public async Task Invoke(HttpContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var headers = context.Response.Headers;

            foreach (var headerValuePair in policy.GetHeaders())
            {
                headers[headerValuePair.Key] = headerValuePair.Value;
            }

            await next(context);
        }
    }
}
