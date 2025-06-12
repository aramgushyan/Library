using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<AuthorBook>().HasOne(ab => ab.Author).WithMany(a => a.AuthorBooks).HasForeignKey(ab => ab.IdAuthor).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AuthorBook>().HasOne(ab => ab.Book).WithMany(b => b.AuthorBooks).HasForeignKey(ab => ab.IdBook).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookGenre>().HasOne(bg => bg.Genre).WithMany(g => g.BookGenres).HasForeignKey(bg => bg.IdGenre).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BookGenre>().HasOne(bg => bg.Book).WithMany(b => b.BookGenres).HasForeignKey(bg => bg.IdBook).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookLending>().HasOne(bl => bl.Reader).WithMany(r => r.BookLendings).HasForeignKey(bl => bl.IdReader).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<BookLending>().HasOne(bl => bl.Instance).WithMany(i => i.BookLendings).HasForeignKey(bl => bl.IdInstance).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>().HasOne(e => e.Library).WithMany(l => l.Employees).HasForeignKey(e => e.IdLibrary).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Instance>().HasOne(i => i.Library).WithMany(l => l.Instances).HasForeignKey(i => i.IdLibrary).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Instance>().HasOne(i => i.Book).WithMany(b => b.Instances).HasForeignKey(i => i.IdBook).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
