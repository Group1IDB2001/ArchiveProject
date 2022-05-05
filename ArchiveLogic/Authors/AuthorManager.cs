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
            var author_1 = _context.Authors.FirstOrDefault(n => n.Name == name);
            if (author_1 == null)
            {
                var author = new Author { Name = name, Born = born, Death = death, About = about };
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
            var author = await _context.Authors.FirstOrDefaultAsync(g => g.Id == id);
            if (author == null)
            {
                throw new Exception("Error,I can't found,There is not author");
            }
            return author;
        }


        public async Task<Author> GetAuthorByName(string name)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(g => g.Name == name);


            if (author == null)
            {
                throw new Exception("Error,I can't found,There is not author with this Name");
            }
            return author;
        }

        public async Task<IList<Author>> GetAuthorsByYear(int year)
        {
            List<Author> authors = new List<Author>();

            foreach(var  author in  _context.Authors)
            {
                if(author.Death == year || author.Born==year)
                {
                    authors.Add(author);
                }
            }
            return authors;
        }


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

        //}

        public async Task EditAuthorName(int id, string name)
        {
            var author = _context.Authors.FirstOrDefault(g => g.Id == id);
            author.Name = name;
            await _context.SaveChangesAsync();
        }

        public async Task EditAuthorBorn(int id, int born)
        {
            var author = _context.Authors.FirstOrDefault(g => g.Id == id);
            author.Born=born;
            await _context.SaveChangesAsync();
        }

        public async Task EditAuthorDeath(int id, int? death)
        {
            var author = _context.Authors.FirstOrDefault(g => g.Id == id);
            author.Death = death;
            await _context.SaveChangesAsync();
        }


        public async Task EditAuthorAbout(int id, string? about)
        {
            var author = _context.Authors.FirstOrDefault(g => g.Id == id);
            author.About = about;
            await _context.SaveChangesAsync();
        }

        //public async Task ReplaceAuthor(int id , string name, int born, int? death, string? about)
        //{
        //    var author = _context.Authors.FirstOrDefault(g => g.Id == id);
        //    if(author == null)
        //    {
        //        AddAuthor(name, born, death, about);
        //    }
        //    else
        //    {
        //        author.Name= name;
        //        author.Born= born;
        //        author.Death=death;
        //        author.About= about;
        //        await _context.SaveChangesAsync();
        //    }
        //}




















        //public Task Update(Author author)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
