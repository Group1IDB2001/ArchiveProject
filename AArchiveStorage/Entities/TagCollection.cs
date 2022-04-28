using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class TagCollection
    {
        [Key]
        public int Id { get; set; }
        
        public int? TagId { get; set; }
        //[ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }
        
        public int? CollectionId { get; set; }
        //[ForeignKey(nameof(CollectionId))]
        public virtual Collection Collection { get; set; }

        public TagCollection(int? tagId, int? collectionId)
        {
            TagId = tagId;
            CollectionId = collectionId;
        }
    }
}
