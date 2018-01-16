using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    [HtmlTargetElement("input", Attributes="helper-for")]
    [HtmlTargetElement("label", Attributes="helper-for")]
    public class LabelAndInputTagHelper : TagHelper
    {
        public ModelExpression HelperFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context.TagName == "label")
            {
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Attributes.SetAttribute("for", this.HelperFor.Name);
                output.Content.SetContent(this.HelperFor.Name);
            }
            else if (context.TagName == "input")
            {
                output.TagMode = TagMode.SelfClosing;
                output.Attributes.SetAttribute("name", this.HelperFor.Name);
                output.Attributes.SetAttribute("class", "form-control");
                if (this.HelperFor.Metadata.ModelType == typeof(int?))
                {
                    output.Attributes.SetAttribute("type", "number");
                }
            }
        }
    }
}