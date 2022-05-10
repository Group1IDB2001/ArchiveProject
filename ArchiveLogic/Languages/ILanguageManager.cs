using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.LLanguage
{
    public interface ILanguageManager
    {
        Task<IList<Language>> GetAllLanguage();
        Task AddLanguage(string name);
        Task<Language> GetLanguageById(int id);
        Task<Language> GetLanguageByName(string name);
        Task DeleteLanguage(string name);


    }
}
