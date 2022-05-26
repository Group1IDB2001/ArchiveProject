using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArchiveLogic.Authors
{
    public interface IItemManager
    {
        Task<bool> AddItem(string name, string? description, int year, string? field, Genres genre, int country_Id);

        Task<bool> FindItemByName(string name);

        Task<bool> EditItem(int id, string name, string? description, int year, string? field, Genres genre, int country_Id);

        Task<Item> GetItemById(int id);

        Task<bool> DeleteItem(int id);





        Task<IList<Item>> GetAllItems();

        
        Task<Item> GetItemByName(string name);

        Task<IList<Item>> GetItemsByYear(int year);

        Task<IList<Item>> GetItemsByGenre(Genres genre);

        Task<IList<Item>> GetItemsByField(string field);




        Task<IList<Item>> GetItemsByAuthorId (int authorId);
        Task<IList<Item>> GetItemsByAuthorName (string authorname);
        Task<IList<Item>> GetItemsByLanguage (int languageId);




        Task AddAuthorToItem (int itemid, int authorid);
        Task DeleteAuthorFromItem(int itemid, int authorid);
        Task ReplaceAllAuthorsInItem(int itemid, int newauthorid);
        Task AddLanguageToItem(int itemid, int languageId);
        Task DeleteLanguageFromItem(int itemid, int languageId);
        Task ReplaceAllLanguagesInItem(int itemid, int newlanguageId); 



        Task AddTTagToItem (int itemid, int ttagId);
        Task DeleteTTagFromItem (int itemid,int ttagId); 
        Task ReplaceAllTTagsInItem (int itemid,int newttagId);


    }
}