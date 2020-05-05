using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.AddTagHelper
{
    [HtmlTargetElement("DateTime", Attributes = "asp-showicon,asp-only")]
    public class DateTimeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            output.TagName = "small";
            object showicon = context.AllAttributes["asp-showicon"].Value;
            output.Attributes.RemoveAll("asp-showicon");
            object only = context.AllAttributes["asp-only"].Value;
            output.Attributes.RemoveAll("asp-only");
            output.Content.ToString();
            output.Content.AppendHtml(DateTime.Now.ToString("yyyy年mm月dd日 hh时mm分"));

            //if (showicon == (object)true)
            //{
            //    output.Content.AppendHtml("<span class="fa fa - calendar"></span>");
            //}
            if (only.ToString() == "date")
            {
                output.Content.AppendHtml(DateTime.Now.ToString("yyyy年mm月dd日  "));
            }
            //output.GetChildContentAsync().Result.GetContent();

        }
        public override string ToString()
        {
             base.ToString();
            return DateTime.Now.ToString("yyyy年mm月dd日 hh时mm分");
        }
    }
}
