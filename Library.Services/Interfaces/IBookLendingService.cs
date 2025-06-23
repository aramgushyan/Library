using Library.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IBookLendingService
    {

        /// <summary>
        /// Добавляет выдачу книги.
        /// </summary>
        /// <param name="bookLending">Данные выдачи.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>id добавленной выдачи.</returns>
        public Task<int> AddAsync(AddBookLendingDto bookLending, CancellationToken token);

        /// <summary>
        /// Обновляет данные выдачи книги по id.
        /// </summary>
        /// <param name="bookLending">Новые данные выдачи.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление успешно.</returns>
        public Task<bool> UpdateAsync(UpdateBookLendingDto bookLending, CancellationToken token);

        /// <summary>
        /// Удаляет выдачу книги по id.
        /// </summary>
        /// <param name="id">id выдачи.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление успешно.</returns>
        public Task<bool> DeleteAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список всех выдач без деталей.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список выдач.</returns>
        public Task<List<ShowBookLendingWithoutDetailsDto>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Возвращает выдачу книги по id с данными читателя и экземпляра.
        /// </summary>
        /// <param name="id">id выдачи.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные выдачи или null, если не найдена.</returns>
        public Task<ShowBookLendingDto> GetAsync(int id, CancellationToken token);
    }
}
