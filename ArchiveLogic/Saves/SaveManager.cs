using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Saves
{
    public class SaveManager:ISaveManager
    {
        private readonly MyArchiveContext _context;
        public SaveManager(MyArchiveContext context)
        {
            _context = context;
        }
        public async Task AddSaved(int? userid, int? collectionid)
        {
            var user = _context.Users.FirstOrDefault(C => C.Id == userid);
            if (user == null) throw new Exception("There is not User with the same Id");

            var collection = await _context.Collections.FirstOrDefaultAsync(g => g.Id == collectionid);
            if (collection == null) throw new Exception("There is not collection with the same Id");

            if(collection.UserId == userid) throw new Exception("You already have this collection");

            var save_1 = _context.Saves.FirstOrDefault(n => n.UserId == userid && n.CollectionId == collectionid);
            if (save_1 == null)
            {
                var save = new Saved { UserId = userid, CollectionId = collectionid };
                _context.Saves.Add(save);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("There is Collection with the same information");
            }
        }

        public async Task<IList<Saved>> GetAllSaves()
        {
            return await _context.Saves.ToListAsync();
        }

        public async Task<IList<Saved>> GetSavedByUser(int userid)
        {
            List<Saved> Saves = new List<Saved>();

            foreach (var Save in _context.Saves)
            {
                if (Save.UserId == userid) Saves.Add(Save);
            }
            if (Saves.Count == 0) throw new Exception("There is not Collection with the same User Id");

            return Saves;
        }

        public async Task<IList<Saved>> GetSavedByCollection(int collectionid)
        {
            List<Saved> Saves = new List<Saved>();

            foreach (var Save in _context.Saves)
            {
                if (Save.CollectionId == collectionid) Saves.Add(Save);
            }
            if (Saves.Count == 0) throw new Exception("There is not Collection with the same User Id");

            return Saves;
        }

        public async Task DeleteSaved(int userId, int collectionId)
        {
            var Save = _context.Saves.FirstOrDefault(x => x.UserId == userId && x.CollectionId == collectionId);
            if(Save == null) throw new Exception("There is not Collection with the same User Id");
            _context.Saves.Remove(Save);
            await _context.SaveChangesAsync();
        }
    }
}
