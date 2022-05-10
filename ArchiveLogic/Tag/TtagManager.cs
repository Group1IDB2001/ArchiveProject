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

        public async Task AddTtag(string name, int userId, string description)
        {
            var t1 = await _context.Ttags.FirstOrDefaultAsync(n => n.Name == name);
            if (t1 == null)
            {
                Ttag ttag = new Ttag { Name = name, UserId = userId, Description = description };

                Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Ttag> entityEntry = _context.Ttags.Add(ttag);


                _context.SaveChanges();
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
                throw new Exception("Error,I can't Found,There is not item");
            }
            return tag;
        }

        
    }
    
}
