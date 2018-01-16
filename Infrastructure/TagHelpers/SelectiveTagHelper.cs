using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    [HtmlTargetElement(Attributes="show-for-action")]
    public class SelectiveTagHelper : TagHelper
    {
        public string ShowForAction { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.Equals(this.ViewContext.RouteData.Values["action"] as string, this.ShowForAction, StringComparison.OrdinalIgnoreCase))
            {
                output.SuppressOutput();
            }
        }
    }
}