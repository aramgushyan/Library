using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Library.Infastructure
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookLending> BookLendings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Instance> Instances { get; set; }
        public DbSet<LibraryModel> Libraries { get; set; }
        public DbSet<Reader> Readers { get; set; }

        public LibraryDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>().HasOne(ab => ab.Author).WithMany().HasForeignKey(ab => ab.AuthorId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AuthorBook>().HasOne(ab => ab.Book).WithMany().HasForeignKey(ab => ab.BookId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookGenre>().HasOne(bg => bg.Genre).WithMany().HasForeignKey(bg => bg.GenreId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BookGenre>().HasOne(bg => bg.Book).WithMany().HasForeignKey(bg => bg.BookId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookLending>().HasOne(bl => bl.Reader).WithMany().HasForeignKey(bl => bl.ReaderId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<BookLending>().HasOne(bl => bl.Instance).WithMany().HasForeignKey(bl => bl.InstanceId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>().HasOne(e => e.Library).WithMany().HasForeignKey(e => e.LibraryId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Instance>().HasOne(i => i.Library).WithMany().HasForeignKey(i => i.LibraryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Instance>().HasOne(i => i.Book).WithMany().HasForeignKey(i => i.BookId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
