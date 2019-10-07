using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlsAndRoutes.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class LegacyController  :Controller
    {
        public ViewResult GetLegacyUrl(string legacyUrl)
            => View((object)legacyUrl);
    }
}
