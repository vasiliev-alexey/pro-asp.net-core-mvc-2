using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Views.Infrastructure
{
    using System.Text;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewEngines;

    public class DebugDataView : IView
    {
        public async Task RenderAsync(ViewContext context)
        {
            context.HttpContext.Response.ContentType = "text/plain";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---Routing Data---"); //Данные маршрутизации

            foreach (var kvp in context.RouteData.Values)
            {
                sb.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
            sb.AppendLine("---View Data---"); //Данные представления

            foreach (var kvp in context.ViewData)
            {
                sb.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            await context.Writer.WriteAsync(sb.ToString());
        }

        public string Path => String.Empty;
    }
}
