using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class TTagCollection
    {
        [Key]
        public int Id { get; set; }
        
        public int? TTagId { get; set; }
        //[ForeignKey(nameof(TagId))]
        //public virtual TTag TTag { get; set; }
        
        public int? CollectionId { get; set; }
        //[ForeignKey(nameof(CollectionId))]
        //public virtual Collection Collection { get; set; }
        //public TTagCollection(int tTag, int collection)
        //{
            //TTag = tTag;
            //Collection = collection;
            //TTagId = tTag;
            //CollectionId = collection;
        //}

    }
}
