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
        public async Task<bool> AddTtag(string name, int userId, string? description)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if(user == null) return false;

            var ttag_1 =  _context.Ttags.FirstOrDefault(n => n.Name == name);
            if (ttag_1 == null)
            {
                Ttag ttag = new Ttag{Name=name, UserId = userId, Description = description };
                _context.Ttags.Add(ttag);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> FindTtag(string name)
        {
            var ttag_1 = _context.Ttags.FirstOrDefault(n => n.Name == name);
            if (ttag_1 == null)return false;
            else return true;
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
                Ttags = null;
                return Ttags;
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
