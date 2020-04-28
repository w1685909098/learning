using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.AddTagHelper
{
    [HtmlTargetElement("pager",Attributes ="pageIndex,path")]
   public class PagerTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            output.TagName = "a";
            object path = context.AllAttributes["path"].Value;
            object pageIndex = context.AllAttributes["pageIndex"].Value;
            output.Attributes.RemoveAll("path");
            output.Attributes.RemoveAll("pageIndex");
            output.Attributes.Add("href", $"{path}/Page-{pageIndex}");
        }
    }
}
