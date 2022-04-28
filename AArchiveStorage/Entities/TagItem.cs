using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class TagItem
    {
       [Key]
        public int Id { get; set; }
        
        public int? TagId { get; set; }
        //[ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }
        
        public int? ItemId { get; set; }
        //[ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; }

        public TagItem(int? tagId, int? itemId)
        {
            TagId = tagId;
            ItemId = itemId;
        }
    }
}
