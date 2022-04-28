using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Tag
{
    public interface ITTagManager
    {
        Task<IList<TTag>> GetAllTTags();
        Task<TTag> GetTTagById (int id);
        Task<TTag> GetTTagByName (string name);
        Task<IList<TTag>> GetTTagsByUser(int userId);
        Task<IList<TTag>> GetTTagsByItem (int itemId);

        Task EditTTagName (int id,string name);
        Task DeleteTTag (int id);
        Task AddTTag(string name, int userId, string? description);


    }
}
