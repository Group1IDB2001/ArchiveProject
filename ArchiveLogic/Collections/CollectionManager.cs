using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Collections
{
    public class CollectionManager:ICollectionManager
    {
        private readonly ArchiveContext _context;
        public CollectionManager(ArchiveContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCollection(string name, string description, int userid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userid);
            if (user == null) return false;

            var collection_1 =  _context.Collections.FirstOrDefault(n => n.Name == name && n.UserId == userid);
            if (collection_1 == null) 
            {
                var collection = new Collection { Name = name, Description = description, UserId = userid };
                _context.Collections.Add(collection);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> FindCollection(string name, int userid)
        {
            var collection = _context.Collections.FirstOrDefault(n => n.Name == name && n.UserId == userid);
            if (collection == null) return false;
            else return true;
        }
        public async Task<IList<Collection>> GetCollectionsByUsreId(int usreid)
        {
            List<Collection> collections = new List<Collection>();
            foreach (var collection in _context.Collections)
            {
                if (collection.UserId == usreid) collections.Add(collection);
            }
            if (collections.Count == 0) throw new Exception("Error,I can't Found,There is not collection");
            return collections;
        }
        public async Task<IList<Collection>> GetAllCollection()
        {
            return await _context.Collections.ToListAsync();
        }

    }
}
