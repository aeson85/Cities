using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    public class FormTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;

        public FormTagHelper(IUrlHelperFactory urlHelperFactory) => _urlHelperFactory = urlHelperFactory;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContextData { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(this.ViewContextData);
            output.Attributes.SetAttribute("action", urlHelper.Action(new UrlActionContext {
                Action = string.IsNullOrWhiteSpace(this.Action) ? this.ViewContextData.RouteData.Values["action"].ToString() : this.Action,
                Controller = string.IsNullOrWhiteSpace(this.Controller) ? this.ViewContextData.RouteData.Values["controller"].ToString() : this.Controller
            }));
        }
    }
}