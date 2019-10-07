using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace UrlsAndRoutes.Controllers
{
    using UrlsAndRoutes.Models;

    public class AdminController : Controller
    {
        public ViewResult Index()
        {
            return View("Result", new Result { Controller = nameof(AdminController), Action = nameof(Index) });
        }
    }
}