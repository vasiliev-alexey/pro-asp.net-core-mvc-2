using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllersAndActions.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public class PocoController
    {
        [ControllerContext]
        public ControllerContext ControllerContext { get; set; }

        // : Controller
        public ViewResult Index() =>
            new ViewResult()
                {
                    ViewName = "Result",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                                   {
                                       Model = $"This is а РОСО controller 2"
                                   }
                };

        public ViewResult Headers() =>
            new ViewResult()
                {
                    ViewName = "DictionaryResult",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                                   {
                                       Model = ControllerContext.HttpContext.Request.Headers.ToDictionary(
                                           kvp => kvp.Key,
                                           kvp => kvp.Value.First())
                                   }
                };
    }
}