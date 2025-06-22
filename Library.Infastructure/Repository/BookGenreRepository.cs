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

        /// <summary>
        /// Добавляет новую запись жанр-книги.
        /// </summary>
        /// <param name="bookGenre">Данные жанра книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID добавленной записи.</returns>
        public async Task<int> AddBookGenreAsync(BookGenre bookGenre, CancellationToken token)
        {
            await _context.BookGenres.AddAsync(bookGenre, token);
            await _context.SaveChangesAsync(token);

            return bookGenre.Id;
        }

        /// <summary>
        /// Удаляет запись жанра-книги по Id.
        /// </summary>
        /// <param name="id">ID удаляемой записи.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно, иначе false.</returns>
        public async Task<bool> DeleteBookGenreAsync(int id, CancellationToken token)
        {
            return await _context.BookGenres.Where(bg => bg.Id == id).ExecuteDeleteAsync(token) > 0;   
        }

        /// <summary>
        /// Возвращает список книг-жанров.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список записей BookGenre.</returns>
        public async Task<List<BookGenre>> GetAllBookGenresAsync(CancellationToken token)
        {
            return await _context.BookGenres.ToListAsync(token);
        }

        /// <summary>
        /// Возвращает запись жанра-книги по Id.
        /// </summary>
        /// <param name="id">ID записи.</param>
        /// <param name="token">Токен отмены .</param>
        /// <returns>Объект BookGenre или null, если не найден.</returns>
        public async Task<BookGenre> GetBookGenreByIdAsync(int id, CancellationToken token)
        {
            return await _context.BookGenres.FindAsync(id, token);
        }

        /// <summary>
        /// Обновляет данные жанра-книги.
        /// </summary>
        /// <param name="id">ID обновляемой записи.</param>
        /// <param name="bookGenre">Новые данные для обновления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно, иначе false.</returns>
        public async Task<bool> UpdateBookGenreAsync(int id, BookGenre bookGenre, CancellationToken token)
        {
            var previousBookGenre = await _context.BookGenres.FindAsync(id, token);

            if (previousBookGenre == null)
                return false;

            previousBookGenre.SequenceNumber = bookGenre.SequenceNumber;
            previousBookGenre.GenreId = bookGenre.GenreId;
            previousBookGenre.BookId = bookGenre.BookId;

            _context.BookGenres.Update(previousBookGenre);

            await _context.SaveChangesAsync(token);

            return true;
        }
    }
}
