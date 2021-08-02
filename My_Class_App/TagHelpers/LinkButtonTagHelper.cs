using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace My_Classes_App.TagHelpers
{
    public class LinkButtonTagHelper : TagHelper
    {
        private LinkGenerator linkBuilder;
        public LinkButtonTagHelper(LinkGenerator lg) => linkBuilder = lg;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewCtx { get; set; }

        public string Action { get; set; }
        public string Controller { get; set; }
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string action = Action ?? ViewCtx.RouteData.Values["action"].ToString();
            string controller = Controller ?? ViewCtx.RouteData.Values["controller"].ToString();
            var segment = (string.IsNullOrEmpty(Id)) ? null : new { Id };
            string url = linkBuilder.GetPathByAction(action, controller, segment);
            string css = (IsActive) ? "btn btn-outline-dark" : "btn btn-dark";
            output.BuildLink(url, css);
        }
    }
}