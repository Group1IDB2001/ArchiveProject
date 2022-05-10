using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.LLanguage
{
    public class LanguageManager: ILanguageManager
    {
        private readonly ArchiveContext _context;
        public LanguageManager(ArchiveContext context)
        {
            _context = context;
        }

        public async Task<IList<Language>> GetAllLanguage()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task AddLanguage(string name)
        {
            var language_1 = _context.Languages.FirstOrDefault(l =>l.Name == name);
            if (language_1 == null)
            {
                var language = new Language { Name = name };
                _context.Languages.Add(language);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("There is such a Language");
            }
        }

        public async Task<Language> GetLanguageById(int id)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(l => l.Id == id);
            if (language == null)
            {
                throw new Exception("Error,I can't found ,There is not language");
            }
            return language;
        }

        public async Task<Language> GetLanguageByName(string name)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(l => l.Name == name);
            if (language == null)
            {
                throw new Exception("Error,I can't found ,There is not language");
            }
            return language;

        }
        public async Task DeleteLanguage(string name)
        {
            var language = _context.Languages.FirstOrDefault(l => l.Name == name);
            if (language == null)
            {
                throw new Exception("Error,I can't found ,There is not language");
            }
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
        }

    }
}
