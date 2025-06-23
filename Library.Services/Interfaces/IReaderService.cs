using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IReaderService
    {

        /// <summary>
        /// Добавляет нового читателя.
        /// </summary>
        /// <param name="reader">Данные читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id нового читателя.</returns>
        public Task<int> AddAsync(AddReaderDto reader, CancellationToken token);
        public Task<bool> UpdateAsync(UpdateReaderDto reader, CancellationToken token);

        /// <summary>
        /// Удаляет читателя по номеру.
        /// </summary>
        /// <param name="id">Номер читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление успешно.</returns>
        public Task<bool> DeleteAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список всех читателей.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список читателей.</returns>
        public Task<List<ShowReaderWithoutDetailsDto>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Возвращает информацию о конкретном читателе.
        /// </summary>
        /// <param name="id">Номер читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные читателя с активными выдачами.</returns>
        public Task<ShowReaderDto> GetAsync(int id, CancellationToken token);
    }
}
