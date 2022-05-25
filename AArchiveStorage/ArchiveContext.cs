using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage
{
    public class MyArchiveContext : DbContext
    {
        public MyArchiveContext (DbContextOptions<MyArchiveContext> options) : base(options)
        {
            
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionItem> CollectionItems { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemAuthor> ItemAuthors { get; set; }
        public DbSet<ItemLanguage> ItemLanguages { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Qestion> Qestiones { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Ttag> Ttags { get; set; }
        public DbSet<TtagCollection> TtagCollections { get; set; }
        public DbSet<TtagItem> TtagsItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Saved> Saves { get; set; }

    }
}
