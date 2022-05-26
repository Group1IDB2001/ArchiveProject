using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ArchiveStorage.Entities
{
    public enum Genres
    {
        no_info = 0,
        drama = 1,
        fantasy = 2,
        literary_fiction = 3,
        novel = 4,
        poetry = 5,
        folklore = 6,
        historical = 7,
        horror = 8,
        thriller = 9,
        realism = 10,
        science_fiction = 11,
        humor = 12,
        biography = 13,
        essay = 14,
        documentary_literature = 15
    }

    public class Item
    {
        [Key]
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
        public Genres Genre { get; set; } //= { (int)Genre.no_info };

        [Display(Name = "CountryId")]
        [Required]
        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }
        

    }
}
