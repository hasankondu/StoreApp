using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.TagHelpers
{
    [HtmlTargetElement("div",Attributes="page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        public PageInfo PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul class='pagination paging'>");
            if (PageModel.CurrentPage==1)
            {

            }
            //prev

            stringBuilder.Append("<li class='page-item'>");
            if (string.IsNullOrEmpty(PageModel.CurrentCategorySub))
            {
                if (string.IsNullOrEmpty(PageModel.SearchText))
                {
                    stringBuilder.AppendFormat("<a class='page-link' style='{1}' href='/products?page={0}'>&laquo;</a>", ((1 != PageModel.CurrentPage) ? (PageModel.CurrentPage - 1) : (PageModel.CurrentPage)), ((1 != PageModel.CurrentPage) ? "" : "pointer-events: none"));
                }
                else
                {
                    stringBuilder.AppendFormat("<a class='page-link' style='{1}' href='/products?page={0}&searchString={2}'>&laquo;</a>", ((1 != PageModel.CurrentPage) ? (PageModel.CurrentPage - 1) : (PageModel.CurrentPage)), ((1 != PageModel.CurrentPage) ? "" : "pointer-events: none"),PageModel.SearchText);
                }
                
            }
            else
            {
                if (string.IsNullOrEmpty(PageModel.SearchText))
                {
                    stringBuilder.AppendFormat("<a class='page-link' style='{2}' href='/products/{1}?page={0}'>&laquo;</a>", ((1 != PageModel.CurrentPage) ? (PageModel.CurrentPage - 1) : (PageModel.CurrentPage)), PageModel.CurrentCategorySub, ((1 != PageModel.CurrentPage) ? "" : "pointer-events: none"));
                }
                else
                {
                    stringBuilder.AppendFormat("<a class='page-link' style='{2}' href='/products/{1}?page={0}&searchString={3}'>&laquo;</a>", ((1 != PageModel.CurrentPage) ? (PageModel.CurrentPage - 1) : (PageModel.CurrentPage)), PageModel.CurrentCategorySub, ((1 != PageModel.CurrentPage) ? "" : "pointer-events: none"),PageModel.SearchText);
                }
                
            }

            //pagination sayılar
            
            stringBuilder.Append("</ li >");
            for (int i = 1; i <= PageModel.TotalPages(); i++)
            {
                stringBuilder.AppendFormat("<li class='page-item {0}'>", i == PageModel.CurrentPage ? "active" : "");
                if (string.IsNullOrEmpty(PageModel.CurrentCategorySub))
                {
                    if (string.IsNullOrEmpty(PageModel.SearchText))
                    {
                        stringBuilder.AppendFormat("<a class='page-link' href='/products?page={0}'>{0}</a>", i);
                    }
                    else
                    {
                        stringBuilder.AppendFormat("<a class='page-link' href='/products?page={0}&searchString={1}'>{0}</a>", i,PageModel.SearchText);
                    }   
                    
                    
                }
                else
                {
                    if (string.IsNullOrEmpty(PageModel.SearchText))
                    {
                        stringBuilder.AppendFormat("<a class='page-link' href='/products/{1}?page={0}'>{0}</a>", i, PageModel.CurrentCategorySub);
                    }
                    else
                    {
                        stringBuilder.AppendFormat("<a class='page-link' href='/products/{1}?page={0}&searchString={2}'>{0}</a>", i, PageModel.CurrentCategorySub,PageModel.SearchText);
                    }
                    
                }
                stringBuilder.Append("</li>");
            }
            
            //next
            stringBuilder.Append("<li class='page-item'>");
            if (string.IsNullOrEmpty(PageModel.CurrentCategorySub))
            {
                if (string.IsNullOrEmpty(PageModel.SearchText))
                {
                    stringBuilder.AppendFormat("<a class='page-link' style='{1}' href='/products?page={0}'>&raquo;</a>", (((int)Math.Ceiling((decimal)PageModel.TotalItems / PageModel.ItemsPerPage) != PageModel.CurrentPage) ? (PageModel.CurrentPage + 1) : (PageModel.CurrentPage)), (((int)Math.Ceiling((decimal)PageModel.TotalItems / PageModel.ItemsPerPage) != PageModel.CurrentPage) ? "" : "pointer-events: none"));
                }
                else
                {
                    stringBuilder.AppendFormat("<a class='page-link' style='{1}' href='/products?page={0}&searchString={2}'>&raquo;</a>", (((int)Math.Ceiling((decimal)PageModel.TotalItems / PageModel.ItemsPerPage) != PageModel.CurrentPage) ? (PageModel.CurrentPage + 1) : (PageModel.CurrentPage)), (((int)Math.Ceiling((decimal)PageModel.TotalItems / PageModel.ItemsPerPage) != PageModel.CurrentPage) ? "" : "pointer-events: none"),PageModel.SearchText);
                }
                
            }
            else
            {
                if (string.IsNullOrEmpty(PageModel.SearchText))
                {
                    stringBuilder.AppendFormat("<a class='page-link' style='{2}' href='/products/{1}?page={0}'>&raquo;</a>", (((int)Math.Ceiling((decimal)PageModel.TotalItems / PageModel.ItemsPerPage) != PageModel.CurrentPage) ? (PageModel.CurrentPage + 1) : (PageModel.CurrentPage)), PageModel.CurrentCategorySub, (((int)Math.Ceiling((decimal)PageModel.TotalItems / PageModel.ItemsPerPage) != PageModel.CurrentPage) ? "" : "pointer-events: none"));
                }
                else
                {
                    stringBuilder.AppendFormat("<a class='page-link' style='{2}' href='/products/{1}?page={0}&searchString={3}'>&raquo;</a>", (((int)Math.Ceiling((decimal)PageModel.TotalItems / PageModel.ItemsPerPage) != PageModel.CurrentPage) ? (PageModel.CurrentPage + 1) : (PageModel.CurrentPage)), PageModel.CurrentCategorySub, (((int)Math.Ceiling((decimal)PageModel.TotalItems / PageModel.ItemsPerPage) != PageModel.CurrentPage) ? "" : "pointer-events: none"),PageModel.SearchText);
                }
                
            }
            stringBuilder.Append("</ li >");
            stringBuilder.Append("</ ul >");


            output.Content.SetHtmlContent(stringBuilder.ToString());

            base.Process(context, output);
        }
    }
}
