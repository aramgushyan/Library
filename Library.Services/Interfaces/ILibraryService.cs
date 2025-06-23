using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface ILibraryService
    {

        /// <summary>
        /// Добавляет новую библиотеку.
        /// </summary>
        /// <param name="libraryDto">Данные библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленной библиотеки.</returns>
        public Task<int> AddAsync(AddLibraryDto libraryDto, CancellationToken token);

        /// <summary>
        /// Получает библиотеку по id.
        /// </summary>
        /// <param name="id">id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        public Task<ShowLibraryDto> GetAsync(int id, CancellationToken token);

        /// <summary>
        /// Удаляет библиотеку по id.
        /// </summary>
        /// <param name="id">id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public Task<bool> DeleteAsync(int id, CancellationToken token);

        /// <summary>
        /// Обновляет данные библиотеки по id.
        /// </summary>
        /// <param name="libraryDto">Новые данные библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public Task<bool> UpdateAsync(UpdateLibraryDto libraryDto, CancellationToken token);

        /// <summary>
        /// Получает список всех библиотек.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список библиотек.</returns>
        public Task<List<ShowLibraryWithoutDetailsDto>> GetAllAsync(CancellationToken token);
    }
}
