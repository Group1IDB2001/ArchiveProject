using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Authors
{
    public interface IAuthorManager
    {
        Task<bool> AddAuthor(string name, int born, int? death, string? about);
        Task<bool> FindAuthor(string name, int born);
        Task<bool> EditAuthor(int id,string name, int born, int? death, string? about);
        Task<Author> GetAuthorById(int id);
        Task<bool> DeleteAuthor(int id);
        Task<IList<Author>> GetAllAuthors();
        Task<IList<Author>> GetAuthorsByItemId(int itemId);


    }
}
