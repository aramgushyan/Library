using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IBookGenreService
    {
        /// <summary>
        /// Добавляет книгу-жанр.
        /// </summary>
        /// <param name="bookGenre">Добавляемая книга-жанр.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленной книги-жанра.</returns>
        public Task<int> AddAsync(AddBookGenreDto bookGenre, CancellationToken token);

        /// <summary>
        /// Обновляет книгу-жанр по id.
        /// </summary>
        /// <param name="bookGenre">Новые данные книга-жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если получилось обновить.</returns>
        public Task<bool> UpdateAsync(UpdateBookGenreDto bookGenre, CancellationToken token);

        /// <summary>
        /// Удаляет книгу-жанр по id.
        /// </summary>
        /// <param name="id">Нужный id.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если получилось удалить.</returns>
        public Task<bool> DeleteAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список всех книга-жанров.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список книга-жанров.</returns>
        public Task<List<ShowBookGenreDto>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Возвращает книгу-жанр по id.
        /// </summary>
        /// <param name="id">Нужный id.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Книга-жанр.</returns>
        public Task<ShowBookGenreDto> GetAsync(int id, CancellationToken token);
    }
}
