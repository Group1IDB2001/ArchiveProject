using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class TTagItem
    {
       [Key]
        public int Id { get; set; }
        
        public int? TTagId { get; set; }
        //[ForeignKey(nameof(TagId))]
        public virtual TTag TTag { get; set; }
        
        public int? ItemId { get; set; }
        //[ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; }

        public TTagItem(int? ttagId, int? itemId)
        {
            TTagId = ttagId;
            ItemId = itemId;
        }
    }
}
