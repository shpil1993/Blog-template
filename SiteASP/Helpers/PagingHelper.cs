﻿using SiteASP.Models.Paginator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SiteASP.Helpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLink(this HtmlHelper html, PageInfo pageInfo, Func<int,string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("hyperlink_selected");
                }
                else
                {
                    tag.AddCssClass("hyperlink");
                }
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}