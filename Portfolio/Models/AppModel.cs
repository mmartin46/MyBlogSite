using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class AppModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Required")]
        public string ?Name { get; set; }
        public string ?Language { get; set; }
        public string ?Description { get; set; }
        public string ?Authors { get; set; }
        public string ?Link { get; set; } = "#";
        public string ?Picture { get; set; } = "#";
    }
}
