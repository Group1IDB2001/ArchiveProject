using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class Author
    {
        [Key]
        public int  Id { get; set; }
        public string Name { get; set; }
        public int Born { get; set; }
        public int? Death { get; set; }
        public string? About { get; set; }


    }
}
