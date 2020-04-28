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
            //if (showicon == (object)true)
            //{
                 
            //}
            //if (only == (object)"date")
            //{
            //}
            //output.GetChildContentAsync().Result.GetContent();
            //output.PreContent.SetHtmlContent("");


        }
        public override string ToString()
        {
             base.ToString();
            return DateTime.Now.ToString("yyyy年mm月dd日 hh时mm分");
        }
    }
}
