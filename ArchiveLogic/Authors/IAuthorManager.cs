using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Authors
{
    public interface IAuthorManager
    {
        Task AddAuthor(string name, int born, int? death, string? about);

        Task DeleteAuthor(int id);
        
        Task<IList<Author>> GetAllAuthors();
        
        Task<Author> GetAuthorById(int id);

        Task<Author> GetAuthorByName(string name);
        
        Task<IList<Author>> GetAuthorsByYear(int year);

        Task EditAuthorName(int id, string name);

        Task EditAuthorBorn(int id, int born);

        Task EditAuthorDeath(int idd, int? death);

        Task EditAuthorAbout(int id, string? about);


        //Task<IList<Author>> GetAuthorsByItemId(int itemId);


    }
}
