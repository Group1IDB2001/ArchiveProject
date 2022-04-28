using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchiveStorage.Entities;

namespace ArchiveLogic.Authors
{
    internal interface IAuthorManager
    {
        Task<IList<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
        Task<IList<Author>> GetAuthorsByItemId(int itemid);
        Task<Author> GetAuthorByName (string name);
        Task<IList<Author>> GetAuthorsByYear(int year);

        Task DeleteAuthor (int id);
        Task AddAuthor(string name, int born, int? death, string? about); 


    }
}
