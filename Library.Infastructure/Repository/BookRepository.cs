using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Infastructure.Helpers;
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

        public async Task<int> AddBookAsync(Book book, CancellationToken token)
        {
            await _context.Books.AddAsync(book,token);
            await _context.SaveChangesAsync(token);

            return book.IdBook;
        }

        public async Task<bool> DeleteBookAsync(int id, CancellationToken token)
        {
            var book = await _context.Books.FindAsync(id,token);
            if (book != null) 
            {
                 await _context.Books.Where(b => b.IdBook == id).ExecuteDeleteAsync(token);

                return true;
            }

            return false;
        }

        public async Task<Book> GetBookByIdAsync(int id, CancellationToken token)
        {
            return await _context.Books.FindAsync(id,token);
        }

        public async Task<List<Book>> GetAllBooksAsync(CancellationToken token)
        {
            return await _context.Books.ToListAsync(token);
        }

        public async Task<bool> UpdateBookAsync(int id, Book book, CancellationToken token)
        {
            var previousBook = await _context.Books.FindAsync(id, token);
            if (previousBook != null)
            {
                previousBook.Title= book.Title;
                await _context.SaveChangesAsync(token);
                return true;
            }

            return false;
        }

        public async Task<List<string>> GetGenriesByBookIdAsync(int id,CancellationToken token)
        {
            return await _context.BookGenres.Where(bg => bg.BookId == id)
                .Join(_context.Genres,bg => bg.GenreId,g => g.IdGenre,
                (bg,g) => g.Name).ToListAsync(token);
        }

        public async Task<List<string>> GetAuthorsByBookIdAsync(int id, CancellationToken token)
        {
            return await _context.AuthorBooks.Where(ab => ab.BookId == id)
                .Join(_context.Authors,ab => ab.AuthorId,a => a.IdAuthor,
                (ab,a)=> NameHelper.GetFullName(a.Name, a.Surname, a.Patronymic)).ToListAsync(token);
        }

        public async Task<List<string>> GetInstancesByBookIdAsync(int id, CancellationToken token)
        {
            return await _context.Instances.Where(ab => ab.BookId == id).Select(ab => ab.BookNumber).ToListAsync(token);
        }

    }
}
