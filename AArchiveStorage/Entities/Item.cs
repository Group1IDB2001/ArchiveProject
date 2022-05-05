using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ArchiveStorage.Entities
{
    
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public string? Field { get; set; }
        public int Genre { get; set; } //= { (int)Genre.no_info };

        [Required]
        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }
        

    }
}
