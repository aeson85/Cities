using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes="theme")]
    public class ButtonGroupThemeTagHelpers : TagHelper
    {
        public string Theme { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            context.Items["theme"] = this.Theme;
        }
    }

    [HtmlTargetElement("button", ParentTag="div")]
    [HtmlTargetElement("a", ParentTag="div")]
    public class ButtonThemeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context.Items.TryGetValue("theme", out var theme))
            {
                output.Attributes.SetAttribute("class", $"btn btn-{theme}");
            }
        }
    }
}