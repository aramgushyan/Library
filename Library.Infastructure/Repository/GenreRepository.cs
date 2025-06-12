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

        public async Task AddGenreAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre != null) 
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<bool> UpdateGenreAsync(int id, Genre genre)
        {
            var previousGenre = await _context.Genres.FindAsync(id);
            if (previousGenre == null) 
                return false;

            previousGenre.Name = genre.Name;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
