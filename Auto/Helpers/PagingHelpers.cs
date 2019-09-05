using Auto.ModelsApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Auto.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            int end= pageInfo.TotalPages,current= pageInfo.PageNumber;
            int count = 0;
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                if (i == 1 || i == end || i==current || i==current+1 || i==current-1)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.InnerHtml = i.ToString();
                    // если текущая страница, то выделяем ее,
                    // например, добавляя класс
                    if (i == pageInfo.PageNumber)
                    {
                        tag.AddCssClass("selected");
                        tag.AddCssClass("btn-primary");
                    }
                    tag.AddCssClass("btn btn-default");
                    result.Append(tag.ToString());
                   
                }                
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}