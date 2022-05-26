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

        public async Task AddCollectionItem(int? collectionId, int? itemId)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == itemId);
            if (item == null) throw new Exception("There is not Item with the same Id");

            var collection = _context.Collections.FirstOrDefault(a => a.Id == collectionId);
            if (collection == null) throw new Exception("There is not Collection with the same Id");

            var collectionitem_1 = _context.CollectionItems.FirstOrDefault(x => x.CollectionId == collectionId && x.ItemId == itemId);
            if (collectionitem_1 == null)
            {
                var collectionitem = new CollectionItem { CollectionId = collectionId, ItemId = itemId };
                _context.CollectionItems.Add(collectionitem);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("There is Item_Language with the same Id");
            }
        }

        public async Task<IList<CollectionItem>> GetAllCollectionItem()
        {
            return await _context.CollectionItems.ToListAsync();
        }
        
        public async Task DeleteCollectionItem(int collectionId, int itemId)
        {
            var collection =  _context.CollectionItems.FirstOrDefault(g => g.CollectionId == collectionId && g.ItemId == itemId);
            if (collection == null)
            {
                throw new Exception("Error,I can't Found,There is not Collection_Item");
            }
            _context.CollectionItems.Remove(collection);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<CollectionItem>> GetItemCollectionByCollection(int collectionId)
        {
            List<CollectionItem> CollectionItems = new List<CollectionItem>();
            foreach(var CollectionItem in _context.CollectionItems)
            {
                if (CollectionItem.CollectionId == collectionId) CollectionItems.Add(CollectionItem);
            }
            if(CollectionItems.Count == 0) throw new Exception("Error,I can't Found,No Items belongs to this Collection");
            return CollectionItems;

        }
       
        public async Task<IList<CollectionItem>> GetItemCollectionByItem(int itemId)
        {
            List<CollectionItem> CollectionItems = new List<CollectionItem>();
            foreach (var CollectionItem in _context.CollectionItems)
            {
                if (CollectionItem.ItemId == itemId) CollectionItems.Add(CollectionItem);
            }
            if (CollectionItems.Count == 0) throw new Exception("Error,I can't Found,No Items belongs to this Collection");
            return CollectionItems;
        }

    }
}
