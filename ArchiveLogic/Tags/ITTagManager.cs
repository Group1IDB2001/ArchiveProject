using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Tag
{
    public interface ITtagManager
    {
        Task AddTtag(string name, int userId, string? description);
        Task<IList<Ttag>> GetAllTtags();
        Task<Ttag> GetTtagById (int id);
        Task<Ttag> GetTtagByName (string name);
        Task DeleteTtag(int id);
        Task<IList<Ttag>> GetTtagsByUser(int userId);
        Task<IList<Ttag>> GetTtagsByItem (int itemId);







    }
}
