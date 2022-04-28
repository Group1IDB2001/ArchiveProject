using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class Saved
    {
        [Key]
        public int Id { get; set; }
        
        public int? UserId { get; set; }
       // [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        
        public int? CollectionId { get; set; }
       // [ForeignKey(nameof(CollectionId))]
        public virtual Collection Collection { get; set; }

        public Saved(int? userId, int? collectionId)
        {
            UserId = userId;
            CollectionId = collectionId;
        }

    }
}
