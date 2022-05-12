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

        public async Task AddCollection(string name, string description, int userid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userid);
            if (user == null) throw new Exception("There is not User with the same Id");

            var collection_1 =  _context.Collections.FirstOrDefault(n => n.Name == name && n.UserId == userid);
            if (collection_1 == null) 
            {
                var collection = new Collection { Name = name, Description = description, UserId = userid };
                _context.Collections.Add(collection);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("There is Collection with the same name");
            }
        }

        public async Task<IList<Collection>> GetAllCollection()
        {
            return await _context.Collections.ToListAsync();
        }

        public async Task<Collection> GetCollectionById(int id)
        {
            var collection = await _context.Collections.FirstOrDefaultAsync(g => g.Id == id);
            if (collection == null)
            {
                throw new Exception("Error,I can't Found,There is not collection");
            }
            return collection;
        }

        public async Task<Collection> GetCollectionByName(string name)
        {
            var collection = await _context.Collections.FirstOrDefaultAsync(g => g.Name == name);
            if (collection == null)
            {
                throw new Exception("Error,I can't Found,There is not collection");
            }
            return collection;
        }

        public async Task<IList<Collection>> GetCollectionsByUsreId(int usreid)
        {
            List<Collection> collections = new List<Collection>();
            foreach (var collection in _context.Collections)
            {
                if (collection.UserId == usreid) collections.Add(collection);
            }
            if(collections.Count == 0) throw new Exception("Error,I can't Found,There is not collection");
            return collections;
        }

        
        
        
        
        
        public async Task EditCollectionName(int id, string name)
        {
            var collection = await _context.Collections.FirstOrDefaultAsync(g => g.Id == id);
            if (collection == null)
            {
                throw new Exception("Error,I can't Found,There is not collection");
            }
            collection.Name = name;
            await _context.SaveChangesAsync();
        }

        public async Task EditCollectionDescription(int id, string description)
        {
            var collection = await _context.Collections.FirstOrDefaultAsync(g => g.Id == id);
            if (collection == null)
            {
                throw new Exception("Error,I can't Found,There is not collection");
            }
            collection.Description = description;
            await _context.SaveChangesAsync();
        }

        public async Task EditCollectionUserId(int id, int userid)
        {
            var collection = await _context.Collections.FirstOrDefaultAsync(g => g.Id == id);
            if (collection == null)
            {
                throw new Exception("Error,I can't Found,There is not collection");
            }
            collection.UserId = userid;
            await _context.SaveChangesAsync();
        }



        public async Task DeleteCollection(int id)
        {
            var collection = _context.Collections.FirstOrDefault(g => g.Id == id);
            if (collection == null)
            {
                throw new Exception("Error,I can't Found,There is not collection");
            }
            _context.Collections.Remove(collection);
            await _context.SaveChangesAsync();
        }
    }
}
