using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface ILibraryRepository
    {
        /// <summary>
        /// Добавляет новую библиотеку.
        /// </summary>
        /// <param name="library">Данные библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленной библиотеки.</returns>
        public Task<int> AddLibraryAsync(LibraryModel author, CancellationToken token);

        /// <summary>
        /// Обновляет информацию о библиотеке.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="newLibrary">Новые данные.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление выполнено.</returns>
        public Task<bool> UpdateLibraryAsync(int id, LibraryModel author, CancellationToken token);

        /// <summary>
        /// Удаляет библиотеку по Id.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление выполнено.</returns>
        public Task<bool> DeleteLibraryAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает библиотеку по Id.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Библиотека или null, если не найдена.</returns>
        public Task<LibraryModel> GetLibraryByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список сотрудников, прикреплённых к указанной библиотеке.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список сотрудников.</returns>
        public Task<List<string>> GetEmployeesByLibraryIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список экземпляров книг, находящихся в указанной библиотеке.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список экземпляров.</returns>
        public Task<List<Instance>> GetInstancesByLibraryIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список всех библиотек.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список библиотек.</returns>
        public Task<List<LibraryModel>> GetAllLibrariesAsync(CancellationToken token);
    }
}
