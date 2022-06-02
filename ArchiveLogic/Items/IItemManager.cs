using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArchiveLogic.Authors
{
    public interface IItemManager
    {
        Task<bool> AddItem(string name, string? description, int year, string? field, Genres genre, int countryId);
        Task<bool> FindItemByName(string name);
        Task<bool> EditItem(int id, string name, string? description, int year, string? field, Genres genre, int countryId);
        Task<bool> DeleteItem(int id);





        Task<IList<Item>> GetAllItems();
        Task<Item> GetItemById(int id);
        Task<IList<Item>> GetItemByName(string name);
        Task<IList<Item>> GetItemsByGenre(Genres genre);
        Task<IList<Item>> GetItemsByAuthorId(int authorId);
        Task<IList<Item>> GetItemsByAuthorName(string authorname);

    }
}