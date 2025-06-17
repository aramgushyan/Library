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
    public class BookGenreRepository : IBookGenreRepository
    {
        private readonly LibraryDbContext _context;

        public BookGenreRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        public async Task<int> AddBookGenreAsync(BookGenre bookGenre, CancellationToken token)
        {
            await _context.BookGenres.AddAsync(bookGenre, token);
            await _context.SaveChangesAsync(token);

            return bookGenre.IdBookGenre;
        }

        public async Task<bool> DeleteBookGenreAsync(int id, CancellationToken token)
        {
            return await _context.BookGenres.Where(bg => bg.IdBookGenre == id).ExecuteDeleteAsync(token) > 0;   
        }

        public async Task<List<BookGenre>> GetAllBookGenresAsync(CancellationToken token)
        {
            return await _context.BookGenres.ToListAsync(token);
        }

        public async Task<BookGenre> GetBookGenreByIdAsync(int id, CancellationToken token)
        {
            return await _context.BookGenres.FindAsync(id, token);
        }

        public async Task<bool> UpdateBookGenreAsync(int id, BookGenre bookGenre, CancellationToken token)
        {
            var previousBookGenre = await _context.BookGenres.FindAsync(id, token);

            if (previousBookGenre == null)
                return false;

            previousBookGenre.SequenceNumber = bookGenre.SequenceNumber;
            previousBookGenre.GenreId = bookGenre.GenreId;
            previousBookGenre.BookId = bookGenre.BookId;

            return true;
        }
    }
}
