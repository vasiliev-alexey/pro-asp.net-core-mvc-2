using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    using Microsoft.AspNetCore.Http;

    public class ShortCircuitMiddleware

    {
        private RequestDelegate nextDelegate;

        public ShortCircuitMiddleware(RequestDelegate requestDelegate) => nextDelegate = requestDelegate;


        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Items["EdgeBrowser"] as bool? == true)
            {
                httpContext.Response.StatusCode = 403;
            }
            else
            {
                await this.nextDelegate.Invoke(httpContext);
            }
        }

    }
}
