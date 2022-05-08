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
        Task AddItemAuthor(int? authorId, int? itemId);
    }
}
