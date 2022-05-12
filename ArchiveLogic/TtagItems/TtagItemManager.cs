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

        public async Task AddTtagToItem(int? itemId, int? ttagId)
        {
            var ttagitem_1 = _context.TtagsItems.FirstOrDefault(t => t.TtagId == ttagId &&  t.ItemId == itemId);
            if(ttagitem_1 == null)
            {
                var ttagitem = new TtagItem { ItemId = itemId, TtagId = ttagId };
                _context.TtagsItems.Add(ttagitem);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("There is Ttagitem with the same Id");
            }
        }

        public async Task<IList<TtagItem>> GetAllTtagItem()
        {
            return await _context.TtagsItems.ToListAsync();
        }

        public async Task<IList<TtagItem>> GetByItems(int itemId)
        {
            List<TtagItem> Tagitems = new List<TtagItem>();
            foreach(var tagitem in _context.TtagsItems)
            {
               if (tagitem.ItemId == itemId) Tagitems.Add(tagitem);
            }
            if(Tagitems.Count == 0) throw new Exception("There is no tag associated with this item");
            return Tagitems;

        }
        
        public async Task<IList<TtagItem>> GetByTtag(int ttagId)
        {
            List<TtagItem> Tagitems = new List<TtagItem>();
            foreach (var tagitem in _context.TtagsItems)
            {
                if (tagitem.TtagId == ttagId) Tagitems.Add(tagitem);
            }
            if (Tagitems.Count == 0) throw new Exception("There is no tag associated with this item");
            return Tagitems;
        }

        public async Task DeleteTtagFromItem(int itemId, int ttagId)
        {
            var ttagitem = _context.TtagsItems.FirstOrDefault(t => t.TtagId == ttagId && t.ItemId == itemId);
            if (ttagitem == null) throw new Exception("There is not Ttagitem with the same Id");
            else
            {
                ttagitem.TtagId = null;
                await _context.SaveChangesAsync();
            }
        }



    }
}
