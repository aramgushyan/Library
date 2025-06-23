using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Models;
using Library.Infastructure.Repository;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class BookLendingService : IBookLendingService
    {
        private readonly IBookLendingRepository _repository;
        private readonly IMapper _mapper;

        public BookLendingService(IBookLendingRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавляет выдачу книги.
        /// </summary>
        /// <param name="bookLending">Данные выдачи.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>id добавленной выдачи.</returns>
        public async Task<int> AddAsync(AddBookLendingDto bookLending, CancellationToken token)
        {
            if (bookLending == null)
                throw new ArgumentNullException("BookLending не может быть null");

           return await _repository.AddBookLendingAsync(_mapper.Map<BookLending>(bookLending), token);
        }

        /// <summary>
        /// Удаляет выдачу книги по id.
        /// </summary>
        /// <param name="id">id выдачи.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление успешно.</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteBookLendingAsync(id, token);
        }

        /// <summary>
        /// Возвращает список всех выдач без деталей.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список выдач.</returns>
        public async Task<List<ShowBookLendingWithoutDetailsDto>> GetAllAsync(CancellationToken token)
        {
            return _mapper.Map<List<ShowBookLendingWithoutDetailsDto>>(await _repository.GetAllBookLendingAsync(token));
        }

        /// <summary>
        /// Возвращает выдачу книги по id с данными читателя и экземпляра.
        /// </summary>
        /// <param name="id">id выдачи.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные выдачи или null, если не найдена.</returns>
        public async Task<ShowBookLendingDto> GetAsync(int id, CancellationToken token)
        {
            var bookLending = await _repository.GetBookLendingByIdAsync(id, token);

            if (bookLending == null)
                return null;

            var reader = await _repository.GetReaderByIdAsync(bookLending.ReaderId, token);
            var instance = await _repository.GetInstanceIdAsync(bookLending.InstanceId, token);

            var bookLendingDto = _mapper.Map<ShowBookLendingDto>(bookLending);
            bookLendingDto.Reader = reader;
            bookLendingDto.Instance = instance;

            return bookLendingDto;
        }

        /// <summary>
        /// Обновляет данные выдачи книги по id.
        /// </summary>
        /// <param name="bookLending">Новые данные выдачи.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление успешно.</returns>
        public async Task<bool> UpdateAsync(UpdateBookLendingDto bookLending, CancellationToken token)
        {
            if (bookLending == null)
                throw new ArgumentNullException("BookLending не может быть null");

            return await _repository.UpdateBookLendingAsync(bookLending.Id, _mapper.Map<BookLending>(bookLending), token);
        }
    }
}
