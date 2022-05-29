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
        Task<IList<Reaction>> GetAllReactions();
        Task<bool> FindReaction(int? userid, int? itemid);







        Task<IList<Reaction>> GetByItem(int itemid);
        Task<IList<Reaction>> GetByUser(int userid);
        Task DeleteReaction(int reactionid);
        Task EditReactionText (int reactionid,string? newtext);
        Task EditReactionRating (int reactionid, int newrating);


    }
}
