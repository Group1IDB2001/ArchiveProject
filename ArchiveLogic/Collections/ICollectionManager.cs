using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Collections
{
    public interface ICollectionManager
    {
        Task AddCollection(string name , string description , int userid);
        Task<IList<Collection>> GetAllCollection();
        Task<Collection> GetCollectionById(int id);
        Task<Collection> GetCollectionByName(string name);
        Task<IList<Collection>> GetCollectionsByUsreId(int usreid);



        Task EditCollectionName(int id, string name);
        Task EditCollectionDescription(int id, string description);
        Task EditCollectionUserId(int id, int userid);


        Task DeleteCollection(int id);
    }
}
