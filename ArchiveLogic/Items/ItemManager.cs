namespace ArchiveLogic.Items
{
    public class ItemManager : IItemManager
    {
        
        private readonly ArchiveContext _context;
        public ItemManager(ArchiveContext context)
        {
            _context = context;
        }

        enum Genres
        {
            no_info = 0,
            literary_fiction = 1,
            mystery = 2,
            thriller = 3,
            horror = 4,
            historical = 5,
            romance = 6,
            western = 7,
            bildungsroman = 8,
            speculative_fiction = 9,
            science_fiction = 10,
            fantasy = 11,
            dystopyan = 12,
            magical_realism = 13,
            realist_literature = 14,
            subject_literature = 15
        }
        
        public async Task AddItem(string name, string? description, int year, string? field, int genre, int countryId)
        {
            var item_1 = await _context.Items.FirstOrDefaultAsync(n => n.Name == name);
            if (item_1 == null)
            {
                var item = new Item { Name = name, Description = description, Year=year, Field = field, Genre = (int)(Genres)genre, CountryId = countryId };
                
                _context.Items.Add(item);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("There is Item with the same name");
            }
        }

        public async Task<IList<Item>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemById(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(g => g.Id == id);
            if (item == null)
            {
                throw new Exception("Error,I can't Found,There is not item");
            }
            return item;
        }
        public async Task<Item> GetItemByName(string name)
        {
            var item = await _context.Items.FirstOrDefaultAsync(g => g.Name == name);
            if (item == null)
            {
                throw new Exception("Error,I can't Found,There is not item");
            }
            return item;

        }
        public async Task<IList<Item>> GetItemsByYear(int year)
        {
            List<Item> items = new List<Item>();

            foreach (var item in _context.Items)
            {
                if (item.Year == year)
                {
                    items.Add(item);
                }
            }
            return items;
        }

        public async Task<IList<Item>> GetItemsByGenre(int genre)
        {
            List<Item> items = new List<Item>();

            foreach (var item in _context.Items)
            {
                if (item.Genre == genre)
                {
                    items.Add(item);
                }
            }
            return items;
        }

        public async Task<IList<Item>> GetItemsByField(string field)
        {
            List<Item> items = new List<Item>();

            foreach (var item in _context.Items)
            {
                if (item.Field == field)
                {
                    items.Add(item);
                }
            }
            return items;
        }

        public async Task DeleteItem(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(g => g.Id == id);
            if (item == null)
            {
                throw new Exception("Error,I can't Found,There is not item");
            }
            _context.Items.Remove(item);
            _context.SaveChanges();
        }











        public async Task EditItemName(int id, string name)
        {
            var item = _context.Items.FirstOrDefault(g => g.Id == id);
            if (item == null)
            {
                throw new Exception("Error,I can't Found,There is not item");
            }
            item.Name = name;
            await _context.SaveChangesAsync();
        }

        public async Task EditItemYear(int id, int year)
        {
            var item = _context.Items.FirstOrDefault(g => g.Id == id);
            if (item == null)
            {
                throw new Exception("Error,I can't Found,There is not item");
            }
            item.Year=year;
            await _context.SaveChangesAsync();

        }

        public async Task EditItemGenre(int id, int genre)
        {
            var item = _context.Items.FirstOrDefault(g => g.Id == id);
            if (item == null)
            {
                throw new Exception("Error,I can't Found,There is not item");
            }
            item.Genre = genre;
            await _context.SaveChangesAsync();
        }

        public async Task EditItemField(int id, string field)
        {
            var item = _context.Items.FirstOrDefault(g => g.Id == id);
            if (item == null)
            {
                throw new Exception("Error,I can't Found,There is not item");
            }
            item.Field = field;
            await _context.SaveChangesAsync();
        }

        public async Task EditItemDescription(int id, string description)
        {
            var item = _context.Items.FirstOrDefault(g => g.Id == id);
            if (item == null)
            {
                throw new Exception("Error,I can't Found,There is not item");
            }
            item.Description= description;
            await _context.SaveChangesAsync();

        }
    }
}
