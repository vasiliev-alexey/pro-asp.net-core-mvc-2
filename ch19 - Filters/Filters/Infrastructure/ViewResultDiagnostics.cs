using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ViewResultDiagnostics : IActionFilter
    {
        private readonly IFilterDiagnostics diagnostics;

        public ViewResultDiagnostics(IFilterDiagnostics diagnostics)
        {
            this.diagnostics = diagnostics;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            ViewResult vr;
            if ((vr = context.Result as ViewResult) != null)
            {
                diagnostics.AddMessage($"View name: {vr.ViewName}");
                diagnostics.AddMessage($@"Model type:{vr.ViewData.Model.GetType().Name}");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           
        }
    }
}