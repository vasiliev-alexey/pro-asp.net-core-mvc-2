using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlsAndRoutes.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using UrlsAndRoutes.Models;
    
    public class CustomerController : Controller
    {
        //[Route("myroute")]
        [Route("[controller]/МyAction")]
        public ViewResult Index() =>
            View("Result", new Result { Controller = nameof(CustomerController), Action = nameof(Index) });

        public ViewResult List(string id)
        {
            Result r = new Result { 
                Controller = nameof(HomeController),
                Action = nameof(List),
        };
        r.Data["Id"] = id ?? "<no value>";
        r.Data["catchall"] = RouteData.Values["catchall"];

            return  View("Result", r);
        }
          
    }
}