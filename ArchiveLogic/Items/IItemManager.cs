using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Authors
{
    public interface IItemManager
    {
        Task<IList<Item>> GetAllItems();
        Task<Item> GetItemById (int id);
        Task<Item> GetItemByName (string name);
        Task<IList<Item>> GetItemsByAuthor (int authorId);
        Task<IList<Item>> GetItemsByAuthor (string authorName);
        Task<IList<Item>> GetItemsByYear (int year);
        Task<IList<Item>> GetItemsByGenre (int genre);
        Task<IList<Item>> GetItemsByGenre(string genre);
        Task<IList<Item>> GetItemsByField (string field);
        Task<IList<Item>> GetItemsByLanguage (int languageId);

        Task EditItemName (int id,string name);
        Task EditItemYear (int id,int year);
        Task EditItemDescription (int id,string description);

        Task AddAuthorToItem (int id,int authorId);
        Task DeleteAuthorFromItem (int id, int authorId);
        Task ReplaceAllAuthorsInItem(int id, int newauthorId);

        Task AddLanguageToItem(int id, int languageId);
        Task DeleteLanguageFromItem(int id, int languageId);
        Task ReplaceAllLanguagesInItem(int id, int newlanguageId); 

        Task EditItemField (int id,string field);
        Task EditItemGenre (int id,int genre);
        Task EditItemGenre(int id, string genre);

        Task AddTTagToItem (int id,int ttagId);
        Task DeleteTTagFromItem (int id,int ttagId); 
        Task ReplaceAllTTagsInItem (int id,int newttagId);


        Task DeleteItem(int id);
        Task AddItem(string name, string? description, int year, string? field, int genre, int countryId);






    }
}