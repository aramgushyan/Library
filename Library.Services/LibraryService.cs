using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _repository;
        private readonly IMapper _mapper;

        public LibraryService(ILibraryRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавляет новую библиотеку.
        /// </summary>
        /// <param name="libraryDto">Данные библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленной библиотеки.</returns>
        public async Task<int> AddAsync(AddLibraryDto libraryDto, CancellationToken token)
        {
            if (libraryDto == null)

                throw new ArgumentNullException("Библиотека не может быть null");

            return await _repository.AddLibraryAsync(_mapper.Map<LibraryModel>(libraryDto), token);
        }

        /// <summary>
        /// Удаляет библиотеку по id.
        /// </summary>
        /// <param name="id">id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await  _repository.DeleteLibraryAsync(id, token);
        }

        /// <summary>
        /// Получает список всех библиотек.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список библиотек.</returns>
        public async Task<List<ShowLibraryWithoutDetailsDto>> GetAllAsync(CancellationToken token)
        {
            return  _mapper.Map<List<ShowLibraryWithoutDetailsDto>>(await _repository.GetAllLibrariesAsync(token));
        }

        /// <summary>
        /// Получает библиотеку по id.
        /// </summary>
        /// <param name="id">id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        public async Task<ShowLibraryDto> GetAsync(int id, CancellationToken token)
        {
            var library = await _repository.GetLibraryByIdAsync(id, token);
            if (library == null)
                return null;

            var employes = await _repository.GetEmployeesByLibraryIdAsync(id, token);

            var instances = await _repository.GetInstancesByLibraryIdAsync(id, token);
            var instancesAndBooks = GetBookAndInstances(instances);

            var libraryWithDetails = _mapper.Map<ShowLibraryDto>(library);
            libraryWithDetails.Employees = employes;
            libraryWithDetails.BooksAndInstances = instancesAndBooks;

            return libraryWithDetails ;
            
        }

        /// <summary>
        /// Обновляет данные библиотеки по id.
        /// </summary>
        /// <param name="libraryDto">Новые данные библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public async Task<bool> UpdateAsync(UpdateLibraryDto libraryDto, CancellationToken token)
        {
            if (libraryDto == null)
                throw new ArgumentNullException("Библиотека не может быть null");

            return await _repository.UpdateLibraryAsync(libraryDto.Id, _mapper.Map<LibraryModel>(libraryDto), token);
        }

        /// <summary>
        /// Группирует книги и их номера экземпляров.
        /// </summary>
        /// <param name="instances">Список экземпляров.</param>
        /// <returns>Список с названиями книг и номерами экземпляров.</returns>
        private List<BookAndInstancesDto> GetBookAndInstances(List<Instance> instances) 
        {
            if (instances == null)
                return null;

            return instances.GroupBy(i => i.Book.Title).Select(g => new BookAndInstancesDto
            {
                BookTitle = g.Key,
                BookNumbers = g.Select(i => i.BookNumber).ToList()
            }).ToList();
            
        }
    }
}
