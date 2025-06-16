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
    public class GenreRepository : IGenreRepository
    {
        private  readonly LibraryDbContext _context;

        public GenreRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        public async Task<int> AddGenreAsync(Genre genre, CancellationToken token)
        {
            await _context.Genres.AddAsync(genre, token);
            await _context.SaveChangesAsync(token);

            return genre.IdGenre;
        }

        public async Task<bool> DeleteGenreAsync(int id, CancellationToken token)
        {
            var genre = await _context.Genres.FindAsync(id, token);
            if (genre != null) 
            {
                await _context.Genres.Where(g => g.IdGenre == id).ExecuteDeleteAsync(token);
                await _context.SaveChangesAsync(token);

                return true;
            }
            return false;
        }

        public async Task<Genre> GetGenreByIdAsync(int id, CancellationToken token)
        {
            return await _context.Genres.FindAsync(id, token);
        }

        public async Task<List<Genre>> GetAllGenresAsync(CancellationToken token)
        {
            return await _context.Genres.ToListAsync(token);
        }

        public async Task<bool> UpdateGenreAsync(int id, Genre genre, CancellationToken token)
        {
            var previousGenre = await _context.Genres.FindAsync(id, token);
            if (previousGenre == null) 
                return false;

            previousGenre.Name = genre.Name;
            await _context.SaveChangesAsync(token);

            return true;
        }

        public async Task<List<string>> GetBooksByGenreIdAsync(int id, CancellationToken token)
        {
            return await _context.BookGenres.Where(bg => bg.IdBookGenre == id)
                .Join(_context.Books, bg => bg.BookId, b => b.IdBook, (bg, b) => b.Title).ToListAsync(token);
        }
    }
}
