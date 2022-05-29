using System.ComponentModel.DataAnnotations;

namespace Archive.Models
{
    public class CreateResponseRequest
    {
        public int Id { get; set; }

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Text is required")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Text must be between 3 and 250 chars")]
        public string Text { get; set; }
        public int? QestionId { get; set; }
        public int? UserId { get; set; }
        public int? ItemId { get; set; }
        public int? CollectionId { get; set; }

    }
}
