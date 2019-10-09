using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Filters.Infrastructure
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public class ViewResultDetailsAttribute : ResultFilterAttribute
    {
        public   void OnResultExecutingSync(ResultExecutingContext context)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
                                                  {
                                                      ["Result Туре"] = context.Result.GetType().Name
                                                  };
            ViewResult vr;
            if ((vr = context.Result as ViewResult) != null)
            {
                dict["View Name"] = vr.ViewName;
                dict["Model Туре"] = vr.ViewData.Model.GetType().Name;
                dict["Model Data"] = vr.ViewData.Model.ToString();
                context.Result = new ViewResult
                                     {
                                         ViewName = "Message",
                                         ViewData = new ViewDataDictionary(
                                                        new EmptyModelMetadataProvider(),
                                                        new ModelStateDictionary()) {
                                                                                       Model = dict 
                                                                                    }
                                     };
            }
        }

        public async override  Task OnResultExecutionAsync(ResultExecutingContext context, 
                                                           ResultExecutionDelegate next)
        {

            Console.WriteLine("************* OnResultExecutionAsync ");
            OnResultExecutingSync(context);
            await next();

        }
    }
}