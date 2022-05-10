using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.IItemLanguage
{
    public interface IItemLanguageManager
    {
        Task<IList<ItemLanguage>> GetAllItemLanguages();
        Task AddItemLanguage(int? languageid , int? itemid);
        Task EditLanguageId(int id, int? languageId);
        Task EditItemId(int id, int? itemId);
    }
}
