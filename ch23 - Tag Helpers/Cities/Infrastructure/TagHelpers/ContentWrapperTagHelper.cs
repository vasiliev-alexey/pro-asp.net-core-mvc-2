using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("div", Attributes = "title")]
    public class ContentWrapperTagHelper : TagHelper
    {
        public bool IncludeHeader { get; set; } = true;

        public bool IncludeFooter { get; set; } = true;

        public string Title { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "m-1 p-1");
            var title = new TagBuilder("hl");
            title.InnerHtml.Append(Title);
            var container = new TagBuilder("div");
            container.Attributes["class"] = "bg-info m-1 p-1";
            container.InnerHtml.AppendHtml(title);

            if (IncludeHeader)
            {
                output.PreElement.SetHtmlContent(container);
            }
            if (IncludeFooter)
            {
                output.PostElement.SetHtmlContent(container);
            }

        }
    }
}