using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalSite.Helpers
{
    public static class ImageLinkHelper
    {
        public static string ActionLinkWithImage(this HtmlHelper html, string imgSrc, string actionName, string controllerNaam)
        {
            UrlHelper urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            string imgUrl = urlHelper.Content(imgSrc);
            TagBuilder imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", imgUrl);
            string img = imgTagBuilder.ToString(TagRenderMode.Normal);
                                                    //controller toegevoegd
            string url = urlHelper.Action(actionName,controllerNaam,null,null);
            
            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = img
            };

            tagBuilder.MergeAttribute("href", url);
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

    }
}