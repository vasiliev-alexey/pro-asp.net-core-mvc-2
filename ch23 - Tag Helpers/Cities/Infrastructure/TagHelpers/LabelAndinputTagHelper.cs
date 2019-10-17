using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project

    [HtmlTargetElement("label", Attributes = "helper-for")]
    [HtmlTargetElement("input", Attributes = "helper-for")]
    public class LabelAndinputTagHelper : TagHelper
    {
        public ModelExpression HelperFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output.TagName == "label")
            {
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Content.Append(HelperFor.Name);
                output.Attributes.SetAttribute("for", HelperFor.Name);
            }
            else if (output.TagName == "input")
            {
                output.TagMode = TagMode.SelfClosing;
                output.Attributes.SetAttribute("name", HelperFor.Name);
                output.Attributes.SetAttribute("class", "form-control");
                if (HelperFor.Metadata.ModelType == typeof(int?))
                {
                    output.Attributes.SetAttribute("type", "number");
                }
            }
        }
    }
}
