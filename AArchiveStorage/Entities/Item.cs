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
        literary_fiction = 1,
        mystery = 2,
        thriller = 3,
        horror = 4,
        historical = 5,
        romance = 6,
        western = 7,
        bildungsroman = 8,
        speculative_fiction = 9,
        science_fiction = 10,
        fantasy = 11,
        dystopyan = 12,
        magical_realism = 13,
        realist_literature = 14,
        subject_literature = 15
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
