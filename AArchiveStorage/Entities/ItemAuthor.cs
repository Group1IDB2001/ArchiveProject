using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class ItemAuthor
    {
        [Key]
        public int Id { get; set; }
        
        public int? AuthorId { get; set; }
      //  [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; }
        
        public int? ItemId { get; set; }
      //  [ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; }
        public ItemAuthor(int? authorId, int? itemId)
        {
            AuthorId = authorId;
            ItemId = itemId;
        }


    }
}
