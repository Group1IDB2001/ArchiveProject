using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Likes
{
    public interface ILikeManager
    {
        Task AddLike(int userId, int itemId);
        Task DeleteLike(int userId, int itemId);
        Task<IList<Like>> GetByUser(int userId);
    }
}
