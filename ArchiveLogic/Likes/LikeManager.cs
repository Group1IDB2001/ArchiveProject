using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Likes
{
    public class LikeManager: ILikeManager
    {
        private readonly ArchiveContext _context;
        public LikeManager(ArchiveContext context)
        {
            _context = context;
        }

        public async Task<bool> AddLike(int? userid, int? itemid)
        {
            var item = _context.Items.FirstOrDefault(C => C.Id == itemid);
            if (item == null) return false;

            var user = _context.Users.FirstOrDefault(u => u.Id == userid);
            if(user == null) return false;

            var like_1 =  _context.Likes.FirstOrDefault(n => n.UserId == userid && n.ItemId == itemid);
            if (like_1 == null)
            {
                var like = new Like { UserId = userid , ItemId = itemid };

                _context.Likes.Add(like);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<IList<Like>> GetByUser(int userid)
        {
            List<Like> likes = new List<Like>();
            foreach( var like in _context.Likes)
            {
                if (like.UserId == userid) likes.Add(like);
            }
            if(likes.Count == 0) throw new Exception("There is not Likes with the same User Id");
            return likes;
        }
    }
}
