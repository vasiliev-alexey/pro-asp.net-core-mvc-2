using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ClaimsController :Controller
    {
        [Authorize]
        public ViewResult Index() => View(User?.Claims);
    }
}
