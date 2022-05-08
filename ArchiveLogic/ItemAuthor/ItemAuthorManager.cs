namespace ArchiveLogic.ItemsAuthors
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
        public async Task AddItemAuthor(int? authorId, int? itemId)
        {
            var itemAuthor_1 = _context.ItemAuthors.FirstOrDefault(x => x.Id == authorId && x.ItemId == itemId);
            if(itemAuthor_1 == null)
            {
                var itemAuthor = new ItemAuthor { AuthorId = authorId, ItemId = itemId };
                _context.ItemAuthors.Add(itemAuthor);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("There is ItemAuthor with the same Id");
            }
        }

        
    }
}
