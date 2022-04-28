using ArchiveStorage;
using Microsoft.EntityFrameworkCore;

namespace ArchiveLogic.Authors
{
    public class AuthorManager:IAuthorManager
    {
        private readonly ArchiveContext _context;
        public AuthorManager(ArchiveContext archiveContext)
        {
            _context=archiveContext;
        }

        public async Task AddAuthor(string name, int born, int? death, string? about)
        {
            DbSet<Author> table = null;
            Author author = new Author(name, born, death, about);
            table.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthor(int id)
        {

            var author = _context.Authors.FirstOrDefault(g => g.Id == id);
            if (author == null)
            {
                throw new Exception("Error,I cant delete,There is no");
            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Author>> GetAllAuthors()
        {
            return await _context.Authors.ToListAsync();
        }










        public Task EditAuthorAbout(int id, string about)
        {
            throw new NotImplementedException();
        }

        public Task EditAuthorBorn(int id, int born)
        {
            throw new NotImplementedException();
        }

        public Task EditAuthorDeath(int idd, int? death)
        {
            throw new NotImplementedException();
        }

        public Task EditAuthorName(int id, string name)
        {
            throw new NotImplementedException();
        }

       

        public Task<Author> GetAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthorByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Author>> GetAuthorsByItemId(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Author>> GetAuthorsByYear(int year)
        {
            throw new NotImplementedException();
        }

        public Task Update(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
