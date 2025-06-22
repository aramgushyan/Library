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

        /// <summary>
        /// Добавляет новую книгу в базу данных.
        /// </summary>
        /// <param name="book">Данные книги для добавления.</param>
        /// <param name="token">Токен отмены.
        public async Task<int> AddBookAsync(Book book, CancellationToken token)
        {
            await _context.Books.AddAsync(book,token);
            await _context.SaveChangesAsync(token);

            return book.Id;
        }

        /// <summary>
        /// Удаляет книгу по её ID.
        /// </summary>
        /// <param name="id">ID книги для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>true — если удаление прошло успешно, иначе false.</returns>
        public async Task<bool> DeleteBookAsync(int id, CancellationToken token)
        {
            var book = await _context.Books.FindAsync(id,token);
            if (book != null) 
            {
                 await _context.Books.Where(b => b.Id == id).ExecuteDeleteAsync(token);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Получает книгу по её ID.
        /// </summary>
        /// <param name="id">ID книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Объект книги, если найден, иначе null.</returns>
        public async Task<Book> GetBookByIdAsync(int id, CancellationToken token)
        {
            return await _context.Books.FindAsync(id,token);
        }

        /// <summary>
        /// Возвращает список всех книг.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список всех книг в базе данных.</returns>
        public async Task<List<Book>> GetAllBooksAsync(CancellationToken token)
        {
            return await _context.Books.ToListAsync(token);
        }

        /// <summary>
        /// Обновляет информацию о книге.
        /// </summary>
        /// <param name="id">ID книги, которую нужно обновить.</param>
        /// <param name="book">Обновлённые данные книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>true — если обновление прошло успешно, иначе false.</returns>
        public async Task<bool> UpdateBookAsync(int id, Book book, CancellationToken token)
        {
            var previousBook = await _context.Books.FindAsync(id, token);
            if (previousBook != null)
            {
                previousBook.Title= book.Title;

                _context.Books.Remove(previousBook);

                await _context.SaveChangesAsync(token);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Получает список жанров, выбранной книгой.
        /// </summary>
        /// <param name="id">ID книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список названий жанров.</returns>
        public async Task<List<string>> GetGenriesByBookIdAsync(int id,CancellationToken token)
        {
            return await _context.BookGenres.Where(bg => bg.BookId == id)
                .Join(_context.Genres,bg => bg.GenreId,g => g.Id,
                (bg,g) => g.Name).ToListAsync(token);
        }

        /// <summary>
        /// Получает список авторов книги по её ID.
        /// </summary>
        /// <param name="id">ID книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список ФИО авторов.</returns>
        public async Task<List<string>> GetAuthorsByBookIdAsync(int id, CancellationToken token)
        {
            return await _context.AuthorBooks.Where(ab => ab.BookId == id)
                .Join(_context.Authors,ab => ab.AuthorId,a => a.Id,
                (ab,a)=> NameHelper.GetFullName(a.Name, a.Surname, a.Patronymic)).ToListAsync(token);
        }

        /// <summary>
        /// Получает список экземпляров книги по её ID.
        /// </summary>
        /// <param name="id">ID книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список экземпляров книги.</returns>
        public async Task<List<string>> GetInstancesByBookIdAsync(int id, CancellationToken token)
        {
            return await _context.Instances.Where(ab => ab.BookId == id).Select(ab => ab.BookNumber).ToListAsync(token);
        }

    }
}
