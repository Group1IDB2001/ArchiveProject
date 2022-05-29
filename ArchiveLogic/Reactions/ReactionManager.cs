using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Reactions
{
    public class ReactionManager:IReactionManager
    {
        private readonly ArchiveContext _context;
        public ReactionManager(ArchiveContext context)
        {
            _context = context;
        }

        public async Task<bool> AddReaction(int? userid, int? itemid, int rating, string? text)
        {
            var user = _context.Users.FirstOrDefault(C => C.Id == userid);
            if (user == null) return false;

            var item = _context.Items.FirstOrDefault(C => C.Id == itemid);
            if (user == null) return false;

            var reaction_1 = _context.Reactions.FirstOrDefault(n => n.UserId == userid && n.ItemId == itemid);
            if (reaction_1 == null)
            {
                var reaction = new Reaction { UserId = userid, ItemId = itemid, Rating = rating, Text = text };

                _context.Reactions.Add(reaction);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IList<Reaction>> GetAllReactions()
        {
            return await _context.Reactions.ToListAsync();
        }

        public async Task<bool> FindReaction(int? userid, int? itemid)
        {
            var reaction = _context.Reactions.FirstOrDefault(n => n.UserId == userid && n.ItemId == itemid);
            if (reaction == null) return false;
            else return true;
        }





        public async Task<IList<Reaction>> GetByItem(int itemid)
        {
            List<Reaction> reactions = new List<Reaction>();

            foreach (var reaction in _context.Reactions)
            {
                if (reaction.ItemId == itemid) reactions.Add(reaction);
            }
            if (reactions.Count == 0) reactions = null;
            return reactions;
        }

        public async Task<IList<Reaction>> GetByUser(int userid)
        {
            List<Reaction> reactions = new List<Reaction>();

            foreach (var reaction in _context.Reactions)
            {
                if (reaction.UserId == userid) reactions.Add(reaction);
            }
            if (reactions.Count == 0) throw new Exception("There is not Reaction with the same User Id");

            return reactions;
        }

        public async Task DeleteReaction(int reactionid)
        {
            var reaction = _context.Reactions.FirstOrDefault(r => r.Id == reactionid);
            if (reaction == null) throw new Exception("There is not Reaction with the same Id");
            _context.Reactions.Remove(reaction);
            await _context.SaveChangesAsync();
        }

        public async Task EditReactionText(int reactionid, string? newtext)
        {
            var reaction = _context.Reactions.FirstOrDefault(r => r.Id == reactionid);
            if (reaction == null) throw new Exception("There is not Reaction with the same Id");
            reaction.Text = newtext;
            await _context.SaveChangesAsync();
        }

        public async Task EditReactionRating(int reactionid, int newrating)
        {
            var reaction = _context.Reactions.FirstOrDefault(r => r.Id == reactionid);
            if (reaction == null) throw new Exception("There is not Reaction with the same Id");
            reaction.Rating = newrating;
            await _context.SaveChangesAsync();
        }

    }
}
