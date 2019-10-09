using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    using System.Diagnostics;
    using System.Text;
    using System.Threading;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ProfileAttribute : ActionFilterAttribute
    {
        private Stopwatch timer;

        private double actionTime;

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();

            timer.Stop();
            string result = "<div>Action time: " + $"{actionTime} ms</div><div>Total time: "
                                                 + $"{timer.Elapsed.TotalMilliseconds} ms</div>";
            byte[] bytes = Encoding.ASCII.GetBytes(result);

            await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();

            await next();

            actionTime = timer.Elapsed.TotalMilliseconds;
        }
    }
}