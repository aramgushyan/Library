using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Models;
using Library.Application.Dto;

namespace Library.Services.Interfaces
{
    public interface IAuthorService
    {

        /// <summary>
        /// Добавляет автора.
        /// </summary>
        /// <param name="authorDto">Добавляемый автор.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного автора.</returns>
        public Task<int> AddAuthorAsync(AddAuthorDto author, CancellationToken token);

        /// <summary>
        /// Возвращает автора с книгами по id.
        /// </summary>
        /// <param name="id">Нужный id.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Автор с книгами или null, если не найден.</returns>
        public Task<ShowAuthorDto> GetAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает всех авторов без книг.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список авторов.</returns>
        public Task<List<ShowAuthorWithoutBooksDto>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Удаляет автора по id.
        /// </summary>
        /// <param name="id">Нужный id.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если получилось удалить.</returns>
        public Task<bool> DeleteAuhtorAsync(int id, CancellationToken token);

        /// <summary>
        /// Обновляет автора по id.
        /// </summary>
        /// <param name="author">Новые данные автора.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если получилось обновить.</returns>
        public Task<bool> UpdateAuthorAsync(UpdateAuthorDto author, CancellationToken token);
    }
}
