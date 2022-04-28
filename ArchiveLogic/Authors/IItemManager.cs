using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Authors
{
    internal interface IItemManager
    {
        Task<IList<Item>> GetAllItems();
        Task<Item> GetItemById (int id);
        Task<Item> GetItemByName (string name);
        Task<IList<Item>> GetItemsByAuthor (int authorId);
        Task<IList<Item>> GetItemsByAuthorName (string authorName);
        Task<IList<Item>> GetItemsByYear (int year);
        Task<IList<Item>> GetItemsByGenre (int genre);
        Task<IList<Item>> GetItemsByField (string field);
        Taa


    }
}