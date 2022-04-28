using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class Response
    {
        [Key]
        public int Id { get; set; }
        public string Text  { get; set; }
       
        public int? QestionId { get; set; }
        //[ForeignKey(nameof(QestionId))]
        public virtual Qestion Qestion { get; set; } 
         
        public int? UserId { get; set; }
        //[ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    
        public int? ItemId { get; set; }
        //[ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; }

        public int? CollectionId { get; set; }
        //[ForeignKey(nameof(CollectionId))]
        public virtual Collection Collection { get; set; }

        public Response(string text, int? qestionId, int? userId, int? itemId, int? collectionId)
        {
            Text = text;
            QestionId = qestionId;
            UserId = userId;
            ItemId = itemId;
            CollectionId = collectionId;
        }
    }
}
