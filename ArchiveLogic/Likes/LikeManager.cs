using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Likes
{
    public class LikeManager: ILikeManager
    {
        private readonly MyArchiveContext _context;
        public LikeManager(MyArchiveContext context)
        {
            _context = context;
        }

        public async Task AddLike(int? userid, int? itemid)
        {
            var item = _context.Items.FirstOrDefault(C => C.Id == itemid);
            if (item == null) throw new Exception("There is not Item with the same Id");

            var user = _context.Users.FirstOrDefault(u => u.Id == userid);
            if(user == null) throw new Exception("There is not User with the same Id");

            var like_1 =  _context.Likes.FirstOrDefault(n => n.UserId == userid && n.ItemId == itemid);
            if (like_1 == null)
            {
                var like = new Like { UserId = userid , ItemId = itemid };

                _context.Likes.Add(like);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("There is Like with the same Id");
            }
        }

        public async Task<IList<Like>> GetAllLike()
        {
            return await _context.Likes.ToListAsync();
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

        public async Task<IList<Like>> GetByItem(int itemid)
        {
            List<Like> likes = new List<Like>();
            foreach (var like in _context.Likes)
            {
                if (like.ItemId == itemid) likes.Add(like);
            }
            if (likes.Count == 0) throw new Exception("There is not Likes with the same Item Id");
            return likes;

        }

        public async Task DeleteLike(int userid, int itemid)
        {
            var like = _context.Likes.FirstOrDefault(L => L.UserId == userid && L.ItemId == itemid);
            if(like == null) throw new Exception("There is not Like with the same Item Id and User Id");
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }
        

    }
}
