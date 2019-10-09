using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public class RangeExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentOutOfRangeException)
            {
                context.Result = new ViewResult()
                                     {
                                         ViewName = "Message",
                                         ViewData = new ViewDataDictionary(
                                                        new EmptyModelMetadataProvider(),
                                                        new ModelStateDictionary())
                                                        {
                                                            Model =
                                                                @"The data received Ьу the application cannot Ье processed"
                                                        }
                                     };
            }
        }
    }
}