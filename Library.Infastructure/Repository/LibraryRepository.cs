using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Infastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Library.Infastructure.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryDbContext _context;

        public LibraryRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Добавляет новую библиотеку.
        /// </summary>
        /// <param name="library">Данные библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленной библиотеки.</returns>
        public async Task<int> AddLibraryAsync(LibraryModel library, CancellationToken token)
        {
            if(library == null)
                throw new ArgumentNullException("LibraryModel не может быть null");

            await _context.Libraries.AddAsync(library, token);
            await _context.SaveChangesAsync(token);

            return library.Id;
        }

        /// <summary>
        /// Удаляет библиотеку по Id.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление выполнено.</returns>
        public async Task<bool> DeleteLibraryAsync(int id, CancellationToken token)
        {
            if (await _context.Libraries.FindAsync(id, token) == null)
                return false;

            await _context.Libraries.Where(l => l.Id == id).ExecuteDeleteAsync(token);

            return true;
        }

        /// <summary>
        /// Возвращает список всех библиотек.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список библиотек.</returns>
        public async Task<List<LibraryModel>> GetAllLibrariesAsync(CancellationToken token)
        {
            return await _context.Libraries.ToListAsync(token);
        }

        /// <summary>
        /// Возвращает список сотрудников, прикреплённых к указанной библиотеке.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список сотрудников.</returns>
        public async Task<List<string>> GetEmployeesByLibraryIdAsync(int id, CancellationToken token)
        {
            return await _context.Employees.Where(e => e.LibraryId == id)
                .Select(l => NameHelper.GetFullName(l.Name,l.Surname,l.Patronymic)).ToListAsync(token);
        }

        /// <summary>
        /// Возвращает список экземпляров книг, находящихся в указанной библиотеке.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список экземпляров.</returns>
        public async Task<List<Instance>> GetInstancesByLibraryIdAsync(int id, CancellationToken token)
        {
            return await _context.Instances.Where(e => e.LibraryId == id).Include(l=> l.Book).ToListAsync(token);
        }

        /// <summary>
        /// Возвращает библиотеку по Id.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Библиотека или null, если не найдена.</returns>
        public async Task<LibraryModel> GetLibraryByIdAsync(int id, CancellationToken token)
        {
            return await _context.Libraries.FindAsync(id, token);
        }

        /// <summary>
        /// Обновляет информацию о библиотеке.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="newLibrary">Новые данные.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление выполнено.</returns>
        public async Task<bool> UpdateLibraryAsync(int id, LibraryModel newLibrary, CancellationToken token)
        {
            if (newLibrary == null)
                throw new ArgumentNullException("LibraryModel не может быть null");

            var library = await _context.Libraries.FindAsync(id, token);
            if (library == null)
                return false;

            library.Street = newLibrary.Street;
            library.PhoneNumber = newLibrary.PhoneNumber;
            library.House = newLibrary.House;

            _context.Libraries.Update(library);

            await _context.SaveChangesAsync(token);
            return true;
        }
    }
}
