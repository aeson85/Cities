using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    [HtmlTargetElement("a", Attributes="bs-button-color", ParentTag="form")]
    [HtmlTargetElement("button", Attributes="bs-button-COlor", ParentTag="form")]
    public class ButtonTagHelper : TagHelper
    {
        public string BsButtonColor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("class", $"btn btn-{this.BsButtonColor}");
        }
    }
}