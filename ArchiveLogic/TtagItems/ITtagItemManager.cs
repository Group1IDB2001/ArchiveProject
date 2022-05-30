using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.TtagItems
{
    public interface ITtagItemManager
    {
        Task<bool> AddTtagToItem(int? itemId, int? ttagId);
        Task<bool> FindTagItem(int? itemId, int? ttagId);
        Task<IList<TtagItem>> GetByTtag(int ttagId);
    }
}
