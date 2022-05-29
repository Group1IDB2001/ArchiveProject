using System.ComponentModel.DataAnnotations;

namespace Archive.Models
{
    public class CreateReactionRequest
    {
        public int Id { get; set; }
        public string? Text { get; set; }


        [Display(Name = "Rating")]
        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }
        public int? ItemId { get; set; }
        public int? UserId { get; set; }
    }
}
