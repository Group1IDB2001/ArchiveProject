using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Collections
{
    public interface ICollectionManager
    {
        Task<bool> AddCollection(string name , string description , int userid);
        Task<IList<Collection>> GetAllCollection();
        Task<bool>FindCollection(string name, int userid);
        Task<IList<Collection>> GetCollectionsByUsreId(int usreid);
        Task<Collection> GetCollectionsById(int id);

    }
}
