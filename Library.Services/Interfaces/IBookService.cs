using Library.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {

        /// <summary>
        /// Добавляет новую книгу.
        /// </summary>
        /// <param name="bookDto">Данные книги.</param>
        /// <param name="token">Токен отмены.</param>
        public Task<int> AddAsync(AddBookDto bookDto, CancellationToken token);

        /// <summary>
        /// Возвращает книгу по id с жанрами, авторами и экземплярами.
        /// </summary>
        /// <param name="id">id книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные книги или null, если не найдена.</returns>
        public Task<ShowBookDto> GetAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список всех книг без деталей.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список книг.</returns>
        public Task<List<ShowBookWithoutDetailsDto>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Удаляет книгу по id.
        /// </summary>
        /// <param name="id">id книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public Task<bool> DeleteAsync(int id, CancellationToken token);

        /// <summary>
        /// Обновляет данные книги по id.
        /// </summary>
        /// <param name="bookDto">Новые данные книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public Task<bool> UpdateAsync(UpdateBookDto bookDto, CancellationToken token);
    }
}
