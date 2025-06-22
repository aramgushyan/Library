using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IInstanceRepository
    {
        /// <summary>
        /// Добавляет новый экземпляр книги.
        /// </summary>
        /// <param name="instance">Данные экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного экземпляра.</returns>
        public Task<int> AddInstanceAsync(Instance instance, CancellationToken token);

        /// <summary>
        /// Обновляет данные экземпляра.
        /// </summary>
        /// <param name="id">Id экземпляра.</param>
        /// <param name="instance">Новые данные.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public Task<bool> UpdateInstanceAsync(int id, Instance instance, CancellationToken token);

        /// <summary>
        /// Удаляет экземпляр по Id.
        /// </summary>
        /// <param name="id">Id экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удалён успешно.</returns>
        public Task<bool> DeleteInstanceAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список всех экземпляров.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список экземпляров.</returns>
        public Task<List<Instance>> GetAllInstancesAsync(CancellationToken token);

        /// <summary>
        /// Возвращает экземпляр по Id.
        /// </summary>
        /// <param name="id">Id экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Экземпляр или null, если не найден.</returns>
        public Task<Instance> GetInstanceByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает адрес библиотеки по её Id.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Адрес.</returns>
        public Task<string> GetLibraryByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает название книги по её Id.
        /// </summary>
        /// <param name="id">Id книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Название книги.</returns>
        public Task<string> GetBookByIdAsync(int id, CancellationToken token);

    }
}
