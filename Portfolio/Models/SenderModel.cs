using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class SenderModel
    {
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 300, MinimumLength = 3, ErrorMessage = "Message Too Short.")]
        public string Message { get; set; }
    }
}
