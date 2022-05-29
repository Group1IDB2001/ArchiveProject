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

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Text is required")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Text must be between 3 and 250 chars")]
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

    }
}
