using Book;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Book
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Publishers> Publishers { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Books_Author)
                .HasForeignKey(bi => bi.BookId);
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Author)
                .HasForeignKey(bi =>bi.AuthorId);
            // Define relationship between books and authors

        }
    }
}