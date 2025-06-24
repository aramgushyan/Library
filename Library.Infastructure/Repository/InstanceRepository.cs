using Library.Domain.Interfaces;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infastructure.Repository
{
    public class InstanceRepository : IInstanceRepository
    {
        private readonly LibraryDbContext _context;

        public InstanceRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Добавляет новый экземпляр книги.
        /// </summary>
        /// <param name="instance">Данные экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного экземпляра.</returns>
        public async Task<int> AddInstanceAsync(Instance instance, CancellationToken token)
        {
            if (instance == null)
                throw new ArgumentNullException("Instance не может быть null");

            await _context.Instances.AddAsync(instance, token);
            await _context.SaveChangesAsync(token);

            return instance.Id;
        }

        /// <summary>
        /// Удаляет экземпляр по Id.
        /// </summary>
        /// <param name="id">Id экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удалён успешно.</returns>
        public async Task<bool> DeleteInstanceAsync(int id, CancellationToken token)
        {
            return await _context.Instances.Where(i => i.Id == id).ExecuteDeleteAsync(token) > 0;
        }

        /// <summary>
        /// Возвращает список всех экземпляров.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список экземпляров.</returns>
        public async Task<List<Instance>> GetAllInstancesAsync(CancellationToken token)
        {
            return await _context.Instances.ToListAsync(token);
        }

        /// <summary>
        /// Возвращает экземпляр по Id.
        /// </summary>
        /// <param name="id">Id экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Экземпляр или null, если не найден.</returns>
        public async Task<Instance> GetInstanceByIdAsync(int id, CancellationToken token)
        {
            return await _context.Instances.FindAsync(id,token);
        }

        /// <summary>
        /// Возвращает адрес библиотеки по её Id.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Адрес.</returns>
        public async Task<string> GetLibraryByIdAsync(int id, CancellationToken token) 
        {
            return await _context.Libraries.Where(l => l.Id == id)
                .Select(l => string.Join(" ", l.Street, l.House)).FirstOrDefaultAsync(token);
        }

        /// <summary>
        /// Возвращает название книги по её Id.
        /// </summary>
        /// <param name="id">Id книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Название книги.</returns>
        public async Task<string> GetBookByIdAsync(int id, CancellationToken token) 
        {
            return await _context.Books.Where(b => b.Id == id).Select(b => b.Title).FirstOrDefaultAsync(token);
        }

        /// <summary>
        /// Обновляет данные экземпляра.
        /// </summary>
        /// <param name="id">Id экземпляра.</param>
        /// <param name="instance">Новые данные.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public async Task<bool> UpdateInstanceAsync(int id, Instance instance, CancellationToken token)
        {
            if (instance == null)
                throw new ArgumentNullException("Instance не может быть null");

            var previousInstance = await _context.Instances.FindAsync(id,token);

            if (previousInstance == null)
                return false;

            previousInstance.LibraryId = instance.LibraryId;
            previousInstance.BookId = instance.BookId;
            previousInstance.BookNumber = instance.BookNumber;

            _context.Instances.Update(previousInstance);

            await _context.SaveChangesAsync(token);

            return true;
        }
    }
}
