using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        
        public int? UserId { get; set; }
       // [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        
        public int? ItemId { get; set; }
      //  [ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; }

    }
}
