using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ArchiveStorage.Entities
{
    public enum Genres
    {
        нет_информации = 0,
        Драма = 1,
        Фэнтези = 2,
        Проза = 3,
        Роман = 4,
        Поэзия = 5,
        Фольклор = 6,
        Историческая_проза = 7,
        Ужасы = 8,
        Триллер = 9,
        Реализм = 10,
        Научная_фантастика = 11,
        Юмор = 12,
        Биография = 13,
        Эссе = 14,
        Предметная_литература = 15
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
