using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class TtagCollection
    {
        [Key]
        public int Id { get; set; }
        
        public int? TtagId { get; set; }
        //[ForeignKey(nameof(TagId))]
        public virtual Ttag Ttag { get; set; }
        
        public int? CollectionId { get; set; }
        //[ForeignKey(nameof(CollectionId))]
        public virtual Collection Collection { get; set; }
        public TtagCollection (int? ttagId, int? collectionId)
        {
            
            TtagId = ttagId;
            CollectionId = collectionId;
        }

    }
}
