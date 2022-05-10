using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Reactions
{
    public interface IReactionManager
    {
        Task AddReaction(int userId, int itemId,int rating,string? text);
        Task DeleteReaction(int reactionId);
        Task<IList<Reaction>> GetByItem(int itemId);
        Task<IList<Reaction>> GetByUser(int userId);
        Task EditReaction (int reactionId,int newtext);


    }
}
