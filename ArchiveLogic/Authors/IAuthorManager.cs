using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Authors
{
    public interface IAuthorManager
    {
        Task<IList<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
       // Task<IList<Author>> GetAuthorsByItemId(int itemId);
<<<<<<< Updated upstream
        //Task<Author> GetAuthorByName(string name);
        //Task<IList<Author>> GetAuthorsByYear(int year);
=======
        Task<Author> GetAuthorByName(string name);
       // Task<IList<Author>> GetAuthorsByYear(int year);
>>>>>>> Stashed changes
       // Task Update(Author author);


        //Task EditAuthorAbout(int id, string about);
        //Task EditAuthorBorn(int id, int born);
        //Task EditAuthorDeath(int idd, int? death);
        //Task EditAuthorName(int id, string name);


        Task DeleteAuthor (int id);
        Task AddAuthor(string name, int born, int? death, string? about);

    }
}
