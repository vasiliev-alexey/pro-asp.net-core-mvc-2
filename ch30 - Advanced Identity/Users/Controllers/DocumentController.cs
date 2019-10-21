using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Users.Models;

    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IAuthorizationService authService;

        private ProtectedDocument[] docs = new ProtectedDocument[]
                                               {
                                                   new ProtectedDocument
                                                       {
                                                           Title = "QЗ Budget", Author = "Alice", Editor = "Joe"
                                                       },
                                                   new ProtectedDocument
                                                       {
                                                           Title = "Project Plan", Author = "ВоЬ", Editor = "Alice"
                                                       }
                                               };

        public DocumentController(IAuthorizationService auth)
        {
            this.authService = auth;
        }

        public ViewResult Index() => View(docs);

        public async Task<IActionResult> Edit(string title)
        {
            ProtectedDocument doc = docs.FirstOrDefault(d => d.Title == title);
            AuthorizationResult authorized = await authService.AuthorizeAsync(User, doc, "AuthorsAndEditors");
            if (authorized.Succeeded)
            {
                return View("Index", doc);
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }
}