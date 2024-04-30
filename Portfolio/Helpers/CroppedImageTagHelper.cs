using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Portfolio.Helpers
{
    public class CroppedImageTagHelper : TagHelper
    {
        public string ?Width { get; set; }
        public string ?Height { get; set; }
        public string ?ImageSource { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass("crop");

            var innerDiv = new TagBuilder("img");
            innerDiv.Attributes.Add("alt", "Screenshot");
            innerDiv.Attributes.Add("src", ImageSource);
            innerDiv.Attributes.Add("style", $"width: {int.Parse(Width)}px; max-height: {int.Parse(Height)}px; margin: 0px 0 0 0px");
            outerDiv.InnerHtml.AppendHtml(innerDiv);

            output.Content.AppendHtml(outerDiv);
                
        }
    }
}
