using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ArchiveStorage.Entities
{
    enum Genres
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
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public string? Field { get; set; }
        public int Genre { get; set; } 

        [Required]
        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }

        public Item(string name, string? description, int year, string? field, int genre, int countryId)
        {
            Name = name;
            Description = description;
            Year = year;
            Field = field;
            Genre = (int)Genres.dystopyan;
            CountryId = countryId;
        }
    }
}
