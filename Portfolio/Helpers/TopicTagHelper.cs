using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Portfolio.Helpers
{
    public class TopicTagHelper : TagHelper
    {

        public string ?Image {  get; set; }
        public string ?Header { get; set; }
        public string ?Description { get; set; }
        public string ?YourStyle { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var firstRowDiv = new TagBuilder("div");
            firstRowDiv.AddCssClass("row");

            var header = new TagBuilder("h4");
            header.AddCssClass("display-4");
            header.InnerHtml.AppendHtml(Header);

            firstRowDiv.InnerHtml.AppendHtml(header);

            var secondRowDiv = new TagBuilder("div");
            secondRowDiv.AddCssClass("row");
            secondRowDiv.AddCssClass("custom-row");

            var secondRowCol = new TagBuilder("div");
            secondRowCol.AddCssClass("col");

            var image = new TagBuilder("img");
            image.Attributes.Add("src", Image);
            image.AddCssClass("topic-img");
            secondRowCol.InnerHtml.AppendHtml(image);

            var secondRowNextCol = new TagBuilder("div");
            secondRowNextCol.AddCssClass("col");

            var paragraph = new TagBuilder("p");
            paragraph.InnerHtml.Append(Description);
            secondRowNextCol.InnerHtml.AppendHtml(paragraph);
            secondRowDiv.InnerHtml.AppendHtml(secondRowCol);
            secondRowDiv.InnerHtml.AppendHtml(secondRowNextCol);


            output.Content.AppendHtml(firstRowDiv);
            output.Content.AppendHtml(secondRowDiv);
            output.Attributes.Add("style", YourStyle);
        }
    }
}
