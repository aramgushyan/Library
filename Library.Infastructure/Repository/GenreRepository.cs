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

        /// <summary>
        /// Добавляет новый жанр.
        /// </summary>
        /// <param name="genre">Данные жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного жанра.</returns>
        public async Task<int> AddGenreAsync(Genre genre, CancellationToken token)
        {
            await _context.Genres.AddAsync(genre, token);
            await _context.SaveChangesAsync(token);

            return genre.Id;
        }

        public async Task<bool> DeleteGenreAsync(int id, CancellationToken token)
        {
            var genre = await _context.Genres.FindAsync(id, token);
            if (genre != null) 
            {
                await _context.Genres.Where(g => g.Id == id).ExecuteDeleteAsync(token);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Получает жанр по Id.
        /// </summary>
        /// <param name="id">Id жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Жанр или null, если не найден.</returns>
        public async Task<Genre> GetGenreByIdAsync(int id, CancellationToken token)
        {
            return await _context.Genres.FindAsync(id, token);
        }

        /// <summary>
        /// Возвращает список всех жанров.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список жанров.</returns>
        public async Task<List<Genre>> GetAllGenresAsync(CancellationToken token)
        {
            return await _context.Genres.ToListAsync(token);
        }

        /// <summary>
        /// Обновляет данные жанра.
        /// </summary>
        /// <param name="id">Id жанра.</param>
        /// <param name="genre">Новые данные жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если жанр найден и обновлён.</returns>
        public async Task<bool> UpdateGenreAsync(int id, Genre genre, CancellationToken token)
        {
            var previousGenre = await _context.Genres.FindAsync(id, token);
            if (previousGenre == null) 
                return false;

            previousGenre.Name = genre.Name;

            _context.Genres.Update(previousGenre);

            await _context.SaveChangesAsync(token);

            return true;
        }

        /// <summary>
        /// Возвращает список названий книг, связанных с жанром.
        /// </summary>
        /// <param name="id">Id жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список названий книг.</returns>
        public async Task<List<string>> GetBooksByGenreIdAsync(int id, CancellationToken token)
        {
            return await _context.BookGenres.Where(bg => bg.Id == id)
                .Join(_context.Books, bg => bg.BookId, b => b.Id, (bg, b) => b.Title).ToListAsync(token);
        }
    }
}
