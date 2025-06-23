using Library.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IGenreService
    {

        /// <summary>
        /// Добавляет новый жанр.
        /// </summary>
        /// <param name="genreDto">Данные жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного жанра.</returns>
        public Task<int> AddAsync(AddGenreDto genreDto, CancellationToken token);

        /// <summary>
        /// Получает жанр по id.
        /// </summary>
        /// <param name="id">id жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные жанра.</returns>
        public Task<ShowGenreDto> GetAsync(int id, CancellationToken token);

        /// <summary>
        /// Получает список всех жанров.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список жанров.</returns>
        public Task<List<ShowGenreWithoutBooksDto>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Удаляет жанр по id.
        /// </summary>
        /// <param name="id">id жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public Task<bool> DeleteAsync(int id, CancellationToken token);

        /// <summary>
        /// Обновляет данные жанра по id.
        /// </summary>
        /// <param name="genreDto">Новые данные жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public Task<bool> UpdateAsync(UpdateGenreDto genreDto, CancellationToken token);
    }
}
