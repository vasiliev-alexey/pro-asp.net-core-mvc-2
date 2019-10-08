using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllersAndActions.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class ExampleController:Controller
    {
        public ViewResult Index()
        {
            ViewBag.Мessage = "Hello";
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public JsonResult Index2() => Json(new[] { "Alice", "ВоЬ", "Joe" }) ;

        public ContentResult Index3()
            => Content(" [ \"Alice\",  \"ВоЬ\",  \"Joe\"]", "application/json");


        public ObjectResult Index4() => Ok(new string[] { "Alice", "ВоЬ", "Joe" });


        public VirtualFileResult Index5()
            => File("/lib/bootstrap/dist/css/bootstrap.css", "text/css");
        public StatusCodeResult Index6()
            => StatusCode(StatusCodes.Status404NotFound);
        //  public RedirectResult Redirect() => RedirectPermanent(" /Example/Index");

        public RedirectToRouteResult Redirect() =>
            RedirectToRoute(new
                                {
                                    controller = "Example",
                                    action = "Index",
                                    ID = "МyID"
                                });

    }
}
