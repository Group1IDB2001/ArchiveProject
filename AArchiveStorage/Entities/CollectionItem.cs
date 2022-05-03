using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class CollectionItem
    {
        [Key]
        public int Id { get; set; }
        
        public int? CollectionId { get; set; }
       // [ForeignKey(nameof(CollectionId))]
        public virtual Collection Collection { get; set; }
        
        public int? ItemId { get; set; }
       // [ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; }
        public CollectionItem(int? collectionId, int? itemId)
        {
            CollectionId = collectionId;
            ItemId = itemId;
        }
    }
}
