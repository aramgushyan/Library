using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IBookRepository
    {
        /// <summary>
        /// Добавляет новую книгу в базу данных.
        /// </summary>
        /// <param name="book">Данные книги для добавления.</param>
        /// <param name="token">Токен отмены.
        public Task<int> AddBookAsync(Book book, CancellationToken token);

        /// <summary>
        /// Обновляет информацию о книге.
        /// </summary>
        /// <param name="id">ID книги, которую нужно обновить.</param>
        /// <param name="book">Обновлённые данные книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>true — если обновление прошло успешно, иначе false.</returns>
        public Task<bool> UpdateBookAsync(int id, Book book, CancellationToken token);

        /// <summary>
        /// Удаляет книгу по её ID.
        /// </summary>
        /// <param name="id">ID книги для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>true — если удаление прошло успешно, иначе false.</returns>
        public Task<bool> DeleteBookAsync(int id, CancellationToken token);

        /// <summary>
        /// Получает книгу по её ID.
        /// </summary>
        /// <param name="id">ID книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Объект книги, если найден, иначе null.</returns>
        public Task<Book> GetBookByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Получает список жанров, выбранной книги.
        /// </summary>
        /// <param name="id">ID книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список названий жанров.</returns>
        public Task<List<string>> GetGenriesByBookIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Получает список авторов книги по её ID.
        /// </summary>
        /// <param name="id">ID книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список ФИО авторов.</returns>
        public Task<List<string>> GetAuthorsByBookIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Получает список экземпляров книги по её ID.
        /// </summary>
        /// <param name="id">ID книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список экземпляров книги.</returns>
        public Task<List<string>> GetInstancesByBookIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список всех книг.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список всех книг.</returns>
        public Task<List<Book>> GetAllBooksAsync(CancellationToken token);
    }
}
