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
        Task AddSaved(int? userid, int? collectionid);
        Task<IList<Saved>> GetAllSaves();
        Task<IList<Saved>> GetSavedByUser(int userid);
        Task<IList<Saved>> GetSavedByCollection(int collectionid);
        Task DeleteSaved (int userId, int collectionId);
        
    }
}
