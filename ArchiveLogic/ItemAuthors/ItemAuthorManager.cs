﻿namespace ArchiveLogic.ItemsAuthors
{
    public class ItemAuthorManager:IItemAuthorManager
    {
        private readonly ArchiveContext _context;
        public ItemAuthorManager(ArchiveContext context)
        {
            _context = context;
        }
        public async Task<IList<ItemAuthor>> GetAllItemAuthors()
        {
            return await _context.ItemAuthors.ToListAsync();
        }
        
        public async Task<bool> AddItemAuthor(int? authorId, int? itemId)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == itemId);
            if (item == null) return false;

            var author = _context.Items.FirstOrDefault(a => a.Id == authorId);
            if (author == null) return false;

            var itemAuthor_1 = _context.ItemAuthors.FirstOrDefault(x => x.AuthorId == authorId && x.ItemId == itemId);
            if(itemAuthor_1 == null)
            {
                var itemAuthor = new ItemAuthor { AuthorId = authorId, ItemId = itemId };
                _context.ItemAuthors.Add(itemAuthor);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task EditItemid(int id, int? itemid)
        {
            var itemauthor = _context.ItemAuthors.FirstOrDefault(x => x.Id == id);
            if(itemauthor == null)
            {
                throw new Exception("Error,I can't Found,There is not Item_Author");
            }
            itemauthor.ItemId = itemid;
            await _context.SaveChangesAsync();
        }

        public async Task EditAuthorId(int id, int? authorid)
        {
            var itemauthor = _context.ItemAuthors.FirstOrDefault(x => x.Id == id);
            if (itemauthor == null)
            {
                throw new Exception("Error,I can't Found,There is not Item_Author");
            }
            itemauthor.AuthorId= authorid;
            await _context.SaveChangesAsync();
        }

        
    }
}
