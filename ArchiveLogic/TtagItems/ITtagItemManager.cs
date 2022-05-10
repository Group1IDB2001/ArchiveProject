using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.TtagItems
{
    public interface ITtagItemManager
    {
        Task AddTtagToItem(int? itemId, int? ttagId);
        Task<IList<TtagItem>> GetAllTtagItem();
        Task<IList<TtagItem>> GetByItems(int itemId);
        Task<IList<TtagItem>> GetByTtag(int ttagId);
        Task DeleteTtagFromItem (int itemId,int ttagId);
        
    }
}
