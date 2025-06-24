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
    public class AuthorBookRepository : IAuthorBookRepository
    {
        private readonly LibraryDbContext _context;

        public AuthorBookRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Добавляет Автор-Книгу.
        /// </summary>
        /// <param name="authorbook">Объект AuthorBook для добавления.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Id созданной записи.</returns>
        public async Task<int> AddAuthorBookAsync(AuthorBook authorbook, CancellationToken token)
        {
            if (authorbook == null)
                throw new ArgumentNullException("AuthorBook не может быть null");

            await _context.AuthorBooks.AddAsync(authorbook, token);
            await _context.SaveChangesAsync(token);

            return authorbook.Id;
        }

        /// <summary>
        /// Удаляет Автор-Книгу по Id.
        /// </summary>
        /// <param name="id">Id записи для удаления.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>True, если удаление прошло успешно, иначе false.</returns>
        public async Task<bool> DeleteAuthorBookAsync(int id, CancellationToken token)
        {
            int rows = await _context.AuthorBooks
                .Where(ab => ab.Id == id)
                .ExecuteDeleteAsync(token);

            return rows > 0;
        }

        /// <summary>
        /// Возвращает список всех Автор-Книг.
        /// </summary>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Список всех записей.</returns>
        public async Task<List<AuthorBook>> GetAllAuthorBookAsync(CancellationToken token)
        {
            return await _context.AuthorBooks.ToListAsync(token);
        }

        /// <summary>
        /// Возвращает запись Автор-Книг по Id.
        /// </summary>
        /// <param name="id">Id записи.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Объект AuthorBook или null, если не найден.</returns>
        public async Task<AuthorBook> GetAuthorBookByIdAsync(int id, CancellationToken token)
        {
            return  await _context.AuthorBooks.FindAsync(id, token);
        }

        /// <summary>
        /// Обновляет Автор-Книгу по Id.
        /// </summary>
        /// <param name="id">Id записи для обновления.</param>
        /// <param name="authorbook">Обновлённые данные.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>True, если обновление прошло успешно, иначе false.</returns>
        public async Task<bool> UpdateAuthorBookAsync(int id, AuthorBook authorbook, CancellationToken token)
        {
            if(authorbook == null)
                throw new ArgumentNullException("AuthorBook не может быть null");

            var previousAuthorBook = await _context.AuthorBooks.FindAsync(id, token);
            if (previousAuthorBook == null)
                return false;

            previousAuthorBook.AuthorId = authorbook.AuthorId;
            previousAuthorBook.BookId = authorbook.BookId;
            previousAuthorBook.Comment = authorbook.Comment;

            _context.AuthorBooks.Update(previousAuthorBook);

            await _context.SaveChangesAsync(token);
            return true;
        }
    }
}
