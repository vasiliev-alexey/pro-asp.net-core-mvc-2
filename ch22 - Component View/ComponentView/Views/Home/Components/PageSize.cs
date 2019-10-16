﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using Microsoft.AspNetCore.Mvc;


namespace UsingViewComponents.Views.Home.Components
{
  

    public class PageSize : ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(
                "http://apress.com");
                return View(response.Content.Headers.ContentLength);
             
        }
    }
}
