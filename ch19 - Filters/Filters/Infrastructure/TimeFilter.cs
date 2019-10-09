using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc.Filters;

    public class TimeFilter : IAsyncActionFilter, IAsyncResultFilter
    {
        

        private Stopwatch timer;

        private IFilterDiagnostics diagnostics;

        public TimeFilter(IFilterDiagnostics filterDiagnostics)
        {
            this.diagnostics = filterDiagnostics;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();
            await next();
            diagnostics.AddMessage($@"Action time:{timer.Elapsed.TotalMilliseconds}");
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            timer.Stop();
            diagnostics.AddMessage($@"Result time:{timer.Elapsed.TotalMilliseconds}");
        }
    }
}