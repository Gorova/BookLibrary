using System.Data.Entity;
using BookLibrary.DAL.Entities;

namespace Library.DAL
{
    public class BookLibraryContext : DbContext
    {
        public BookLibraryContext()
            : base("BookLibrary")
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(o => o.Books)
                .WithMany(c => c.Categories)
                .Map(m =>
                {
                    m.ToTable("BooksCategories");
                    m.MapLeftKey("CategoryId");
                    m.MapRightKey("BookId");
                });
        }
    }
}
