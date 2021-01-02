using System;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Paging.Models;

namespace Paging.Helpers
{
    public static class PagingHelpers
    {
        public static HtmlString PageLinks(this IHtmlHelper html,
            Pages pages, Func<int, string> pageUrl)
        {
            using var resultWriter = new StringWriter();
            var tag1 = new TagBuilder("a");
            tag1.MergeAttribute("href", pageUrl(1));
            tag1.InnerHtml.Append("<<");
            tag1.AddCssClass("btn btn-default");
            tag1.WriteTo(resultWriter, HtmlEncoder.Default);

            if (pages.CurrentPage > 1)
            {
                tag1 = new TagBuilder("a");
                tag1.MergeAttribute("href", pageUrl(pages.CurrentPage - 1));
                tag1.InnerHtml.Append("<");
                tag1.AddCssClass("btn btn-default");
                tag1.WriteTo(resultWriter, HtmlEncoder.Default);
            }

            for (int i = 1; i <= pages.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                if((i + 1) == pages.CurrentPage || (i + 2) == pages.CurrentPage ||
                    (i - 1) == pages.CurrentPage || (i - 2) == pages.CurrentPage ||
                    (i) == pages.CurrentPage || (i) == pages.TotalPages || (i) == pages.TotalPages - 1 ||
                     (i) == 1 || (i) == 2)
                {
                    tag.InnerHtml.Append(i.ToString());
                    tag.MergeAttribute("href", pageUrl(i));
                }
                else
                {
                    tag1 = new TagBuilder("nav");
                    tag.InnerHtml.Append("...");
                }

                // Если это текущая страница, то выделяем ее
                if (i == pages.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");

                tag.WriteTo(resultWriter, HtmlEncoder.Default);
            }

            if (pages.CurrentPage < pages.TotalPages)
            {
                tag1 = new TagBuilder("a");
                tag1.MergeAttribute("href", pageUrl(pages.CurrentPage + 1));
                tag1.InnerHtml.Append(">");
                tag1.AddCssClass("btn btn-default");
                tag1.WriteTo(resultWriter, HtmlEncoder.Default);
            }

            tag1 = new TagBuilder("a");
            tag1.MergeAttribute("href", pageUrl(pages.TotalPages));
            tag1.InnerHtml.Append(">>");
            tag1.AddCssClass("btn btn-default");
            tag1.WriteTo(resultWriter, HtmlEncoder.Default);

            return new HtmlString(resultWriter.ToString());
        }
    }
}