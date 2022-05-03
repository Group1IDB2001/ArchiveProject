using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Tag
{
    public interface ITTagManager
    {
        Task<IList<Ttag>> GetAllTTags();
        Task<Ttag> GetTTagById (int id);
        Task<Ttag> GetTTagByName (string name);
        Task<IList<Ttag>> GetTTagsByUser(int userId);
        Task<IList<Ttag>> GetTTagsByItem (int itemId);

        Task EditTTagName (int id,string name);
        Task DeleteTTag (int id);
        Task AddTTag(string name, int userId, string? description);


    }
}
