using Library.Domain.Interfaces;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        public async Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null) 
            {
                 _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.BookGenres).ThenInclude(bg => bg.Genre)
                .Include(b => b.AuthorBooks).ThenInclude(ab => ab.Author).Include(b => b.Instances)
                .FirstOrDefaultAsync(b => b.IdBook == id);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.BookGenres).ThenInclude(bg => bg.Genre)
                .Include(b => b.AuthorBooks).ThenInclude(ab => ab.Author).Include(b => b.Instances).ToListAsync();
        }

        public async Task<bool> UpdateBookAsync(int id, Book book)
        {
            var previousBook = await _context.Books.FindAsync(id);
            if (previousBook != null)
            {
                previousBook.Title= book.Title;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
