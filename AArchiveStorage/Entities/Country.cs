using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class Country
    {
        [Key]
        public string Name { get; set; }
        public int Id { get; set; }
        
    }
}
