using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Tag
{
    public class TtagManager : ITtagManager
    {
        private readonly ArchiveContext _context;
        public TtagManager(ArchiveContext context)

        {
            _context = context;
        }
        public async Task<IList<Ttag>> GetAllTtags()
        {
            return await _context.Ttags.ToListAsync();
        }

        public async Task AddTtag(string name, int userId, string? description)
        {
            var t1 =  _context.Ttags.FirstOrDefault(n => n.Name == name);
            if (t1 == null)
            {
                Ttag ttag = new Ttag{Name=name, UserId = userId, Description = description };

               // Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Ttag> entityEntry = _context.Ttags.Add(ttag);
                _context.Ttags.Add(ttag);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("There is Item with the same name");
            }
        }

        public async Task<Ttag> GetTtagById(int id)
        {
            var tag = await _context.Ttags.FirstOrDefaultAsync(g => g.Id == id);
            if (tag == null)
            {
                throw new Exception("Error,I can't Found,There is not item");
            }
            return tag;
        }

        public async Task DeleteTtag(int id)
        {
            var tag = await _context.Ttags.FirstOrDefaultAsync(g => g.Id == id);
            if (tag == null)
            {
                throw new Exception("Error,I can't Found,There is not item");
            }
            _context.Ttags.Remove(tag);
            _context.SaveChanges();
        }

        public async Task<Ttag> GetTtagByName(string name)
        {
            var tag = await _context.Ttags.FirstOrDefaultAsync(g => g.Name == name);
            if (tag == null)
            {
                throw new Exception("Error,I can't Found,There is not Tag");
            }
            return tag;
        }

        public async Task<IList<Ttag>> GetTtagsByUser(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) throw new Exception("Error,I can't Found,There is not Tag with this User Id");
            List<Ttag> ttags = new List<Ttag>();
            foreach (var ttag in _context.Ttags)
            {
                if (user.Id == ttag.UserId) ttags.Add(ttag);
            }
            return ttags;
        }

        public async Task<IList<Ttag>> GetTtagsByItem(int itemId)
        {
            List<Ttag> Ttags = new List<Ttag>();
            List<TtagItem> TtagItems = new List<TtagItem>();
            foreach (var TtagItem in _context.TtagsItems)
            {
                if (TtagItem.ItemId == itemId) TtagItems.Add(TtagItem);
            }
            if (TtagItems.Count == 0)
            {
                throw new Exception("Error,I can't found,No tags belongs to this item");
            }
            else
            {
                foreach (var Ttag in _context.Ttags)
                {
                    for (int i = 0; i < TtagItems.Count; i++)
                    {
                        if (TtagItems[i].TtagId == Ttag.Id) Ttags.Add(Ttag);
                    }
                }
            }
            return Ttags;
        }
    }
}
