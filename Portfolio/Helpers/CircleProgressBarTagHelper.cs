using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Portfolio.Helpers
{
    public class CircleProgressBarTagHelper : TagHelper
    {
        public string Percentage { get; set; }
        public string Title { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var skillDiv = new TagBuilder("div");
            skillDiv.AddCssClass("skill");

            var outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass("outer");

            var circularProgressDiv = new TagBuilder("div");
            circularProgressDiv.AddCssClass("circular-progress");
            circularProgressDiv.Attributes.Add("value-to-end", Percentage);

            var valueContainerDiv = new TagBuilder("div");
            valueContainerDiv.AddCssClass("value-container");

            var innerTitle = new TagBuilder("h3");
            innerTitle.InnerHtml.Append(Title);

            valueContainerDiv.InnerHtml.AppendHtml(innerTitle);

            circularProgressDiv.InnerHtml.AppendHtml(valueContainerDiv);
            outerDiv.InnerHtml.AppendHtml(circularProgressDiv);

            skillDiv.InnerHtml.AppendHtml(outerDiv);
            output.Content.AppendHtml(skillDiv);
        }
    }
}
