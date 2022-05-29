using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchiveStorage.Entities;

namespace ArchiveLogic
{
    public interface IItemAuthorManager
    {
        Task<IList<ItemAuthor>> GetAllItemAuthors();
        Task<bool> AddItemAuthor(int? authorId, int? itemId);
        Task EditAuthorId(int id, int? authorId);
        Task EditItemid(int id, int? itemId);
    }
}
