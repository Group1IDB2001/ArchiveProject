using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class TtagItem
    {
       [Key]
        public int Id { get; set; }
        
        public int? TtagId { get; set; }
        //[ForeignKey(nameof(TagId))]
        public virtual Ttag Ttag { get; set; }
        
        public int? ItemId { get; set; }
        //[ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; }


    }
}
