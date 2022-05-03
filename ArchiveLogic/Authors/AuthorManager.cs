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
            var author_1 = _context.Authors.First(n => n.Name == name);
            if (author_1 == null)
            {
                var author = new Author { Name = name, Born = born, Death = death.Value, About = about };
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("There is author with the same name");
            }

        }

        public async Task DeleteAuthor(int id)
        {

            var author = _context.Authors.FirstOrDefault(g => g.Id == id);
            if (author == null)
            {
                throw new Exception("Error,I can't delete,There is not author");
            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Author>> GetAllAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            var author = _context.Authors.FirstOrDefault(g => g.Id == id);
            if (author == null)
            {
                throw new Exception("Error,I can't found,There is not author");
            }
            return author;
        }

<<<<<<< Updated upstream
=======
        //public Task<IList<Author>> GetAuthorsByItemId(int itemId)
        //{
        //    //var itemauthor = _context.ItemAuthors.Find(item => item.ItemId == itemId);
        //    var itemAuthor = _context.ItemAuthors.Find(Item => Item.ItemId.Contains(itemId));
>>>>>>> Stashed changes

        //public async Task<Author> GetAuthorByName(string name)
        //{
        //    var author = _context.Authors.First(n => n.Name == name);
        //    var author = _context.Authors.Find(n => n.Name == name);

<<<<<<< Updated upstream
        //    if (author == null)
        //    {
        //        throw new Exception("Error,I can't found,There is not author");
        //    }
        //    return author;
        //}

        //public async Task<IList<Author>> GetAuthorsByItemId(int itemId)
        //{
        //    var itemauthor = _context.ItemAuthors.Find(item => item.ItemId == itemId);
        //    List<ItemAuthor> itemAuthor = _context.ItemAuthors.Select(i => i.ItemId == itemId);
        //    if (itemAuthor != null)
        //    {
        //        var counter = itemAuthor.Count();

        //        List<Author> authorList = new List<Author>();
        //        for (j = 0; ; j < counter; j++)
        //            {
        //            authorList.Add(_context.Authors.First(a => a.Id == itemlist.AuthorId);
        //        }
        //    }
        //    return authorList;

=======
>>>>>>> Stashed changes
        //}






        //public Task EditAuthorAbout(int id, string about)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task EditAuthorBorn(int id, int born)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task EditAuthorDeath(int idd, int? death)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task EditAuthorName(int id, string name)
        //{
        //    throw new NotImplementedException();
        //}

<<<<<<< Updated upstream
        public Task<IList<Author>> GetAuthorsByYear(int year)
        {
            throw new NotImplementedException();
        }
=======
       

        



        

        //public Task<IList<Author>> GetAuthorsByYear(int year)
        //{
        //    throw new NotImplementedException();
        //}
>>>>>>> Stashed changes

        //public Task Update(Author author)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
