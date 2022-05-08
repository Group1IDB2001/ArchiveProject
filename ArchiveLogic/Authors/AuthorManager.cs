using ArchiveStorage;
using Microsoft.EntityFrameworkCore;


namespace ArchiveLogic.Authors
{
    public class AuthorManager:IAuthorManager
    {
        private readonly ArchiveContext _context;
        public AuthorManager(ArchiveContext context)
        {
            _context=context;
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

        public async Task<IList<Author>> GetAllAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task DeleteAuthor(int id)
        {

            var author = _context.Authors.FirstOrDefault(g => g.Id == id);
            if (author == null)
            {
                throw new Exception("Error,I can't delete,There is not author with this id");
            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
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

        public async Task<IList<Author>> GetAuthorsByItemId(int itemId)
        {
            List<Author> authors = new List<Author>();
            List<ItemAuthor> itemauthors= new List<ItemAuthor>();
            foreach(var itemauthor in _context.ItemAuthors)
            {
                if (itemauthor.ItemId == itemId) itemauthors.Add(itemauthor);
            }
            if (itemauthors.Count == 0)
            {
                throw new Exception("Error,I can't found,No authors belongs to this item");
            }
            else
            {
                foreach (var author in _context.Authors)
                {
                    for (int i = 0; i < itemauthors.Count; i++)
                    {
                        if (itemauthors[i].AuthorId == author.Id) authors.Add(author);
                    }
                }
            }
            return authors;
        }

        public async Task EditAuthorName(int id, string name)
        {
            var author = _context.Authors.FirstOrDefault(g => g.Id == id);
            if (author == null)
            {
                throw new Exception("Error,I can't found,There is not author");
            }
            author.Name = name;
            await _context.SaveChangesAsync();
        }

        public async Task EditAuthorBorn(int id, int born)
        {
            var author = _context.Authors.FirstOrDefault(g => g.Id == id);
            if (author == null)
            {
                throw new Exception("Error,I can't found,There is not author");
            }
            author.Born=born;
            await _context.SaveChangesAsync();
        }

        public async Task EditAuthorDeath(int id, int? death)
        {
            var author = _context.Authors.FirstOrDefault(g => g.Id == id);
            if (author == null)
            {
                throw new Exception("Error,I can't found,There is not author");
            }
            author.Death = death;
            await _context.SaveChangesAsync();
        }


        public async Task EditAuthorAbout(int id, string? about)
        {
            var author = _context.Authors.FirstOrDefault(g => g.Id == id);
            if (author == null)
            {
                throw new Exception("Error,I can't found,There is not author");
            }
            author.About = about;
            await _context.SaveChangesAsync();
        }

    }
}
