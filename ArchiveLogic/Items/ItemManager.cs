using ArchiveLogic.ItemsAuthors;

namespace ArchiveLogic.Items
{
    public class ItemManager : IItemManager
    {

        private readonly ArchiveContext _context;
        public ItemManager(ArchiveContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItem(string name, string? description, int year, string? field, Genres genre, int countryId)
        {
            var country = _context.Countries.FirstOrDefault(C => C.Id == countryId);
            if (country == null) return false;

            var item_1 = _context.Items.FirstOrDefault(n => n.Name == name);
            if (item_1 == null)
            {
                var item = new Item { Name = name, Description = description, Year = year, Field = field, Genre = (Genres)genre, CountryId = countryId };

                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
        public async Task<bool> FindItemByName(string name)
        {
            var item = await _context.Items.FirstOrDefaultAsync(g => g.Name == name);
            if (item != null) return true;
            else return false;
        }
        public async Task<bool> EditItem(int id, string name, string? description, int year, string? field, Genres genre, int countryId)
        {
            var item = _context.Items.FirstOrDefault(g => g.Id == id);
            if (item == null) return false;
            item.Name = name;
            item.Description = description;
            item.Year = year;
            item.Field = field;
            item.Genre = genre;
            item.CountryId = countryId;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteItem(int id)
        {
            var item = _context.Items.FirstOrDefault(g => g.Id == id);
            if (item == null) return false;
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;

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
                item = null;
            }
            return item;
        }
        public async Task<IList<Item>> GetItemByName(string name)
        {
            var items = await _context.Items.Where(g => g.Name.StartsWith(name) || name == null).ToListAsync();
            return items;
        }
        public async Task<IList<Item>> GetItemsByGenre(Genres genre)
        {
            List<Item> items = new List<Item>();

            foreach (var item in _context.Items)
            {
                if (item.Genre == (Genres)genre)
                {
                    items.Add(item);
                }
            }
            if (items.Count == 0) items = null;
            return items;
        }
        public async Task<IList<Item>> GetItemsByAuthorId(int authorId)
        {
            List<Item> items = new List<Item>();
            List<ItemAuthor> itemauthors = new List<ItemAuthor>();
            foreach (var itemauthor in _context.ItemAuthors)
            {
                if (itemauthor.AuthorId == authorId) itemauthors.Add(itemauthor);
            }
            if (itemauthors.Count == 0)
            {
                throw new Exception("Error,I can't found,No authors belongs to this item");
            }
            else
            {
                foreach (var item in _context.Items)
                {
                    for (int i = 0; i < itemauthors.Count; i++)
                    {
                        if (itemauthors[i].ItemId == item.Id) items.Add(item);
                    }
                }
            }
            return items;
        }
        public async Task<IList<Item>> GetItemsByAuthorName(string authorname)
        {
            List<Item> items = new List<Item>();
            var authors = await _context.Authors.Where(g => g.Name.StartsWith(authorname) || authorname == null).ToListAsync();
            if (authors.Count() == 0)
            {
                items = null;
                return items;
            }
            List<ItemAuthor> itemauthors = new List<ItemAuthor>();
            foreach (var itemauthor in _context.ItemAuthors)
            {
                foreach (var author in authors)
                {
                    if (itemauthor.AuthorId == author.Id)
                    {
                        itemauthors.Add(itemauthor);
                        goto tx;
                    }

                }

            }
        tx:
            if (itemauthors.Count == 0)
            {
                items = null;
                return items;
            }

            foreach (var item in _context.Items)
            {
                for (int i = 0; i < itemauthors.Count; i++)
                {
                    if (itemauthors[i].ItemId == item.Id) items.Add(item);
                }
            }
            return items;

        }


        

    }
}
