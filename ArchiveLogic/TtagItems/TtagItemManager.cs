using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.TtagItems
{
    public class TtagItemManager: ITtagItemManager
    {
        private readonly ArchiveContext _context;
        public TtagItemManager(ArchiveContext context)

        {
            _context = context;
        }

        public async Task<bool> AddTtagToItem(int? itemId, int? ttagId)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == itemId);
            if (item == null) return false;

            var tag = _context.Ttags.FirstOrDefault(i => i.Id == ttagId);
            if (tag == null) return false;

            var ttagitem_1 = _context.TtagsItems.FirstOrDefault(t => t.TtagId == ttagId &&  t.ItemId == itemId);
            if(ttagitem_1 == null)
            {
                var ttagitem = new TtagItem { ItemId = itemId, TtagId = ttagId };
                _context.TtagsItems.Add(ttagitem);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> FindTagItem(int? itemId, int? ttagId)
        {
            var ttagitem = _context.TtagsItems.FirstOrDefault(t => t.TtagId == ttagId && t.ItemId == itemId);
            if (ttagitem == null) return false;
            else return true;
        }
        public async Task<IList<TtagItem>> GetByTtag(int ttagId)
        {
            List<TtagItem> Tagitems = new List<TtagItem>();
            foreach (var tagitem in _context.TtagsItems)
            {
                if (tagitem.TtagId == ttagId) Tagitems.Add(tagitem);
            }
            if (Tagitems.Count == 0) Tagitems = null;
            return Tagitems;
        }

    }
}
