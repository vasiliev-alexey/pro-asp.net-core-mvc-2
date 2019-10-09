using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    using System.Text;

    using Microsoft.AspNetCore.Mvc.Filters;

    public class DiagnosticsFilter : IAsyncResultFilter
    {
        private readonly IFilterDiagnostics diagnostics;

        public DiagnosticsFilter(IFilterDiagnostics diagnostics)
        {
            this.diagnostics = diagnostics;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();

            foreach (string message in diagnostics?.Messages)
            {
                byte[] bytes = Encoding.ASCII.GetBytes($"<div>{message}</div>");
                await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}