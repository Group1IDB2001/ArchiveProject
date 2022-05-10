using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.TtagCollections
{
    public interface ITtagCollectionManager
    {
        Task AddTtagToCollection(int collectionId, int ttagId);
        Task DeleteTtagFromCollection (int collectionId, int ttagId);
        Task<IList<TtagCollection>> GetByTtag(int ttagId);
        Task<IList<TtagCollection>> GetByCollection(int collectionId);
    }
}
