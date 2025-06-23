using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository,IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавляет новую книгу.
        /// </summary>
        /// <param name="bookDto">Данные книги.</param>
        /// <param name="token">Токен отмены.</param>
        public async Task<int> AddAsync(AddBookDto bookDto, CancellationToken token)
        {
            if (bookDto == null)
                throw new ArgumentNullException("BookDto не может быть null");

            return await _repository.AddBookAsync(_mapper.Map<Book>(bookDto), token);
        }

        /// <summary>
        /// Удаляет книгу по id.
        /// </summary>
        /// <param name="id">id книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteBookAsync(id, token);

        }

        /// <summary>
        /// Возвращает список всех книг без деталей.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список книг.</returns>
        public async Task<List<ShowBookWithoutDetailsDto>> GetAllAsync(CancellationToken token)
        {
            var list = await _repository.GetAllBooksAsync(token);
            return _mapper.Map<List<ShowBookWithoutDetailsDto>>(list);
        }

        /// <summary>
        /// Возвращает книгу по id с жанрами, авторами и экземплярами.
        /// </summary>
        /// <param name="id">id книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные книги или null, если не найдена.</returns>
        public async Task<ShowBookDto> GetAsync(int id, CancellationToken token)
        {
            var book = await _repository.GetBookByIdAsync(id, token);
            if ( book == null)
                return null;

            var genries = await _repository.GetGenriesByBookIdAsync(id, token);
            var author = await _repository.GetAuthorsByBookIdAsync(id, token);
            var instances = await _repository.GetInstancesByBookIdAsync(id, token);

            var bookwithDetails = _mapper.Map<ShowBookDto>(book);

            bookwithDetails.Genres = genries;
            bookwithDetails.Authors = author;
            bookwithDetails.Instances = instances;

            return bookwithDetails;
        }

        /// <summary>
        /// Обновляет данные книги по id.
        /// </summary>
        /// <param name="bookDto">Новые данные книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public async Task<bool> UpdateAsync(UpdateBookDto bookDto, CancellationToken token)
        {
            if (bookDto == null)
                throw new ArgumentNullException("BookDto не может быть null");

            return await _repository.UpdateBookAsync(bookDto.Id, _mapper.Map<Book>(bookDto), token);
        }
    }
}
