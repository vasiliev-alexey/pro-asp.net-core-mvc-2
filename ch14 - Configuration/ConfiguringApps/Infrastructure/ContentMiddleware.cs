using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    using System.Diagnostics.Eventing.Reader;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;

        private readonly UptimeService uptimeService;

        public ContentMiddleware(RequestDelegate next ,   UptimeService uptimeService)
        {
            nextDelegate = next;
            this.uptimeService = uptimeService;
        }

        /// <summary>
        /// The invoke.
        /// </summary>
        /// <param name="httpContext">
        /// The http context.
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync("Вызвано из промежуточного слоя" +
                    $"{uptimeService.Uptime}ms"
                    , Encoding.UTF8);
            }
            else
            {
                await this.nextDelegate.Invoke(httpContext);
            }
        }
    }
}

 