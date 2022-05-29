using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Likes
{
    public interface ILikeManager
    {
        Task<bool> AddLike(int? userid, int? itemid);
        Task<IList<Like>> GetAllLike();
        Task<IList<Like>> GetByUser(int userid);
        Task<IList<Like>> GetByItem(int itemid);
        Task DeleteLike(int userid, int itemid);
        
    }
}
