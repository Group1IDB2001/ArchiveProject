using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class ItemLanguage
    {
        [Key]
        public int Id { get; set; }
        
        public int? ItemId { get; set; }
       // [ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; }
        
        public int? LanguageId { get; set; }
      //  [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; }

        public ItemLanguage(int? itemId, int? languageId)
        {
            ItemId = itemId;
            LanguageId = languageId;
        }
    }
}
