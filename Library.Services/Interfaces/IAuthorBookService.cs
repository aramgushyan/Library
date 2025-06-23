using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IAuthorBookService
    {
        /// <summary>
        /// Добавляет автор-книгу.
        /// </summary>
        /// <param name="authorBookDto">Данные для добавления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленной связи.</returns>
        public Task<int> AddAsync(AddAuthorBookDto authorBookDto, CancellationToken token);

        /// <summary>
        /// Обновляет автор-книгу по id.
        /// </summary>
        /// <param name="authorBookDto">Новая автор-книга.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если получилось обновить.</returns>
        public Task<bool> UpdateAsync(UpdateAuthorBookDto authorBookDto, CancellationToken token);

        /// <summary>
        /// Удаляет автор-книгу по id.
        /// </summary>
        /// <param name="id">Нужный id.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если получилось удалить.</returns>
        public Task<bool> DeleteAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает все автор-книги.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список автор-книг.</returns>
        public Task<List<ShowAuthorBookDto>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Возвращает автор-книгу по id.
        /// </summary>
        /// <param name="id">Нужный id.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Найденная автор-книга.</returns>
        public Task<ShowAuthorBookDto> GetByIdAsync(int id, CancellationToken token);
    }
}
