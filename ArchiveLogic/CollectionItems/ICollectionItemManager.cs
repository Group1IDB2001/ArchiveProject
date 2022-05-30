
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.CollectionItems
{
    public interface ICollectionItemManager
    {
        Task<bool> AddCollectionItem(int? collectionId, int? itemId);
        Task<bool> FindCollectionItem(int? collectionId, int? itemId);
        Task<IList<CollectionItem>> GetItemCollectionByCollection(int collectionId);



    }
}
