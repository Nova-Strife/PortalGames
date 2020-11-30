using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PortalGames.ViewModels;
using System.Text;
using System.Text.Encodings.Web;

namespace PortalGames.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageViewModel PageModel { get; set; }
        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";
            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");

            var currentItem = CreateTag(PageModel.PageNumber, urlHelper);

            if (PageModel.HasPreviousPage)
            {
                var prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                ul.InnerHtml.AppendHtml(prevItem);
            }

            ul.InnerHtml.AppendHtml(currentItem);

            if (PageModel.HasNextPage)
            {
                var nextItem = CreateTag(PageModel.PageNumber + 1, urlHelper);
                ul.InnerHtml.AppendHtml(nextItem);
            }
            output.Content.AppendHtml(ul);
        }
        private TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            var li = new TagBuilder("li");
            var a = new TagBuilder("a");
            if (pageNumber == PageModel.PageNumber)
                li.AddCssClass("active");
            else
                a.Attributes["href"] = urlHelper.Action(PageAction, new { page = pageNumber });
            li.AddCssClass("page-item");
            a.AddCssClass("page-link");
            a.InnerHtml.Append(pageNumber.ToString());
            li.InnerHtml.AppendHtml(a);
            return li;
        }
    }
}