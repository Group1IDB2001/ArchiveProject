using ArchiveStorage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Saves
{
    public interface ISaveManager
    {
        Task AddSaved(int userId, int collectionId);
        Task DeleteSaved (int userId, int collectionId);
        Task<IList<Saved>> GetSavedByUser(int userId);
        Task<IList<Saved>> GetSavedByCollection(int collectionId);
    }
}
