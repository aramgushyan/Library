using Library.Domain.Models;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Dto;

namespace Library.Infastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _library;

        public AuthorRepository(LibraryDbContext library) 
        {
            _library = library;
        }

        /// <summary>
        /// Добавляет нового автора.
        /// </summary>
        /// <param name="author">Данные нового автора.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID созданного автора.</returns>
        public async Task<int> AddAuthorAsync(Author author, CancellationToken token)
        {
            await _library.Authors.AddAsync(author, token);

            await _library.SaveChangesAsync(token);

            return author.Id;
        }

        /// <summary>
        /// Удаляет автора по его ID.
        /// </summary>
        /// <param name="id">ID автора для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат удаления.</returns>
        public async Task<bool> DeleteAuthorAsync(int id, CancellationToken token)
        {
            return await _library.Authors.Where(a => a.Id == id).ExecuteDeleteAsync(token) > 0;
        }

        /// <summary>
        /// Возвращает список всех авторов.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список авторов.</returns>
        public async Task<List<Author>> GetAllAuthorsAsync(CancellationToken token)
        {
            return await _library.Authors.ToListAsync(token);
        }

        /// <summary>
        /// Возвращает автора по его ID.
        /// </summary>
        /// <param name="id">ID автора.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные автора.</returns>
        public async Task<Author> GetAuthorByIdAsync(int id, CancellationToken token)
        {
            return await _library.Authors.FindAsync(id, token);
        }

        /// <summary>
        /// Возвращает список названий книг, написанных автором.
        /// </summary>
        /// <param name="authorId">ID автора.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список названий книг.</returns>
        public async  Task<List<string>> GetBooksByAuthorIdAsync(int authorId, CancellationToken token)
        {
            return await _library.AuthorBooks.Where(ab => ab.AuthorId == authorId)
                .Join(_library.Books,ab => ab.BookId,b=>b.Id,(ab,b) => b.Title).ToListAsync(token);
        }

        /// <summary>
        /// Обновляет данные автора.
        /// </summary>
        /// <param name="id">ID автора.</param>
        /// <param name="author">Новые данные автора.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат обновления.</returns>
        public async Task<bool> UpdateAuthorAsync(int id, Author author, CancellationToken token)
        {
            var pastAuthor = await _library.Authors.FindAsync(id, token);

            if (pastAuthor != null)
            {
                pastAuthor.Surname = author.Surname;
                pastAuthor.Patronymic = author.Patronymic;
                pastAuthor.Name = author.Name;

                _library.Authors.Update(pastAuthor);

                await _library.SaveChangesAsync(token);

                return true;
            }
            else
                return false;
        }
    }
}
