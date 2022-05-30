using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Reactions
{
    public interface IReactionManager
    {
        Task<bool> AddReaction(int? userid, int? itemid,int rating,string? text);
        Task<bool> FindReaction(int? userid, int? itemid);
        Task<IList<Reaction>> GetByItem(int itemid);

    }
}
