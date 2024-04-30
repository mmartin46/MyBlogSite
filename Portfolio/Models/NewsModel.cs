using Newtonsoft.Json;

namespace Portfolio.Models
{
    public class NewsModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string[] Creator { get; set; }

        [JsonProperty("image_url")]
        public string ImageURL { get; set; }
        public string Description { get; set; }
    }
}
