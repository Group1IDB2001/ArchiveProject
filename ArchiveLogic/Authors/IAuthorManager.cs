using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Authors
{
    public interface IAuthorManager
    {
        void AddAuthor(Author author);

        Task<bool> AddAuthor(string name, int born, int? death, string? about);

        Task<bool> FindAuthor(string name, int born);
        Task<bool> EditAuthor(int id,string name, int born, int? death, string? about);

        Task<Author> GetAuthorById(int id);

        Task<bool> DeleteAuthor(int id);










        Task<IList<Author>> GetAllAuthors();
        
        

        Task<Author> GetAuthorByName(string name);
        
        Task<IList<Author>> GetAuthorsByYear(int year);

        Task EditAuthorName(int id, string name);

        Task EditAuthorBorn(int id, int born);

        Task EditAuthorDeath(int idd, int? death);

        Task EditAuthorAbout(int id, string? about);
        Task<IList<Author>> GetAuthorsByItemId(int itemId);


    }
}
