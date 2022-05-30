using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Tag
{
    public interface ITtagManager
    {
        Task<bool> AddTtag(string name, int userId, string? description);
        Task<bool> FindTtag(string name);
        Task<IList<Ttag>> GetAllTtags();
        Task<IList<Ttag>> GetTtagsByItem(int itemId);
    }
}
