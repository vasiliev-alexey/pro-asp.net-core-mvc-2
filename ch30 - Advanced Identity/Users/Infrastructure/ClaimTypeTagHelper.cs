﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Users.Infrastructure
{
    using System.Reflection;
    using System.Security.Claims;

    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("td", Attributes = "identity-claim-type ")]
   
    public class ClaimTypeTagHelper : TagHelper
    {
        [HtmlAttributeName("identity-claim-type")]
        public string ClaimType { get; set; }


        public override void Process(TagHelperContext context,
                                     TagHelperOutput output)
        {
            bool foundType = false;
            FieldInfo[] fields = typeof(ClaimTypes).GetFields();
            foreach (FieldInfo field in fields)
            {
                if (field.GetValue(null).ToString() == ClaimType)
                {
                    output.Content.SetContent(field.Name);
                    foundType = true;
                }
            }
            if (!foundType)
            {
                output.Content.SetContent(ClaimType.Split('/', '.').Last());
            }
        }
    }
}
