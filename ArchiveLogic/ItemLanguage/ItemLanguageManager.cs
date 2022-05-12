using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.IItemLanguage
{
    public class ItemLanguageManager: IItemLanguageManager
    {
        private readonly ArchiveContext _context;
        public ItemLanguageManager(ArchiveContext context)
        {
            _context = context;
        }
        
        public async Task<IList<ItemLanguage>> GetAllItemLanguages()
        {
            return await _context.ItemLanguages.ToListAsync();
        }

        public async Task AddItemLanguage(int? languageid, int? itemid)
        {
            var itemlanguage_1 = _context.ItemLanguages.FirstOrDefault(x => x.LanguageId == languageid && x.ItemId == itemid);
            if (itemlanguage_1 == null)
            {
                var itemlanguage = new ItemLanguage { LanguageId = languageid, ItemId = itemid };
                _context.ItemLanguages.Add(itemlanguage);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("There is Item_Language with the same Id");
            }
        }
        
        public async Task EditItemId(int id, int? itemid)
        {
            var itemlanguage = _context.ItemLanguages.FirstOrDefault(x => x.Id == id);
            if (itemlanguage == null)
            {
                throw new Exception("Error,I can't Found,There is not Item_Language");
            }
            itemlanguage.ItemId = itemid;
            await _context.SaveChangesAsync();
        }

        public async Task EditLanguageId(int id, int? languageid)
        {
            var itemlanguage = _context.ItemLanguages.FirstOrDefault(x => x.Id == id);
            if (itemlanguage == null)
            {
                throw new Exception("Error,I can't Found,There is not Item_Language");
            }
            itemlanguage.LanguageId = languageid;
            await _context.SaveChangesAsync();
        }

    }
}
