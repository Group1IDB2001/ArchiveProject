using System.ComponentModel.DataAnnotations;

namespace Archive.Models
{
    public class CreateItemRequest
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars")]
        public string Name { get; set; }


        [Display(Name = "Description")]
        public string? Description { get; set; }


        [Display(Name = "Year")]
        [Required(ErrorMessage = "Year is required.")]
        public int Year { get; set; }

        [Display(Name = "Field")]
        public string? Field { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is required.")]
        public Genres Genre { get; set; }

        [Display(Name = "CountryId")]
        [Required(ErrorMessage = "CountryId is required.")]
        public int CountryId { get; set; }
    }
}
