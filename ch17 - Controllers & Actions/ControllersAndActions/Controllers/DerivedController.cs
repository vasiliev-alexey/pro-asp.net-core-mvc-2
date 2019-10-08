﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllersAndActions.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DerivedController : Controller
    {
        public ViewResult Index() => View("Result", $"This is а derived controller");

        public ViewResult Headers() => View("DictionaryResult",
            Request.Headers.ToDictionary(kvp => kvp.Key,
                kvp => kvp.Value.First()));

    }
}