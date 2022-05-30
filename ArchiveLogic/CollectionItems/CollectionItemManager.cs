using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.CollectionItems
{
    public class CollectionItemManager : ICollectionItemManager
    {
        private readonly ArchiveContext _context;
        public CollectionItemManager(ArchiveContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCollectionItem(int? collectionId, int? itemId)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == itemId);
            if (item == null) return false;

            var collection = _context.Collections.FirstOrDefault(a => a.Id == collectionId);
            if (collection == null) return false;

            var collectionitem_1 = _context.CollectionItems.FirstOrDefault(x => x.CollectionId == collectionId && x.ItemId == itemId);
            if (collectionitem_1 == null)
            {
                var collectionitem = new CollectionItem { CollectionId = collectionId, ItemId = itemId };
                _context.CollectionItems.Add(collectionitem);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> FindCollectionItem(int? collectionId, int? itemId)
        {
            var collectionitem = _context.CollectionItems.FirstOrDefault(x => x.CollectionId == collectionId && x.ItemId == itemId);
            if (collectionitem == null) return false;
            else return true;
        }
        public async Task<IList<CollectionItem>> GetItemCollectionByCollection(int collectionId)
        {
            List<CollectionItem> CollectionItems = new List<CollectionItem>();
            foreach(var CollectionItem in _context.CollectionItems)
            {
                if (CollectionItem.CollectionId == collectionId) CollectionItems.Add(CollectionItem);
            }
            if (CollectionItems.Count == 0) CollectionItems = null;
            return CollectionItems;

        }
       


    }
}
