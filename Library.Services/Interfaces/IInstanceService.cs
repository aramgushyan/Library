using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IInstanceService
    {

        /// <summary>
        /// Добавляет новый экземпляр.
        /// </summary>
        /// <param name="instance">Данные экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного экземпляра.</returns>
        public Task<int> AddAsync(AddInstanceDto instance, CancellationToken token);

        /// <summary>
        /// Обновляет данные экземпляра по id.
        /// </summary>
        /// <param name="instance">Новые данные экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public Task<bool> UpdateAsync(UpdateInstanceDto instance, CancellationToken token);

        /// <summary>
        /// Удаляет экземпляр по id.
        /// </summary>
        /// <param name="id">id экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public Task<bool> DeleteAsync(int id, CancellationToken token);

        /// <summary>
        /// Получает список всех экземпляров.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список экземпляров.</returns>
        public Task<List<ShowInstanceWithoutDetailsDto>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Получает экземпляр по id.
        /// </summary>
        /// <param name="id">id экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        public Task<ShowInstanceDto> GetAsync(int id, CancellationToken token);
    }
}
