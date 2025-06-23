using Library.Domain.Models;
using Library.Domain.Interfaces;
using Library.Services.Interfaces;
using Library.Application.Dto;
using AutoMapper;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавляет автора.
        /// </summary>
        /// <param name="authorDto">Добавляемый автор.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного автора.</returns>
        public async Task<int> AddAuthorAsync(AddAuthorDto authorDto, CancellationToken token)
        {
            if (authorDto == null)
                throw new ArgumentNullException("Author не может быть null");

            return await _repository.AddAuthorAsync(_mapper.Map<Author>(authorDto), token);
        }

        /// <summary>
        /// Удаляет автора по id.
        /// </summary>
        /// <param name="id">Нужный id.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если получилось удалить.</returns>
        public async Task<bool> DeleteAuhtorAsync(int id, CancellationToken token) 
        {
            return await _repository.DeleteAuthorAsync(id,token);
        }

        /// <summary>
        /// Обновляет автора по id.
        /// </summary>
        /// <param name="author">Новые данные автора.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если получилось обновить.</returns>
        public async Task<bool> UpdateAuthorAsync(UpdateAuthorDto author, CancellationToken token)
        {
            if (author == null)
                throw new ArgumentNullException("Author не может быть null");

            return await _repository.UpdateAuthorAsync(author.IdAuthor, _mapper.Map<Author>(author), token);
        }

        /// <summary>
        /// Возвращает автора с книгами по id.
        /// </summary>
        /// <param name="id">Нужный id.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Автор с книгами или null, если не найден.</returns>
        public async Task<ShowAuthorDto> GetAsync(int id, CancellationToken token)
        {
            var author = await _repository.GetAuthorByIdAsync(id, token);
            if (author == null)
                return null;

            var books = await _repository.GetBooksByAuthorIdAsync(id, token);

            var authorWithBook = _mapper.Map<ShowAuthorDto>(author);
            authorWithBook.Books = books;

            return authorWithBook;
        }

        /// <summary>
        /// Возвращает всех авторов без книг.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список авторов.</returns>
        public async Task<List<ShowAuthorWithoutBooksDto>> GetAllAsync(CancellationToken token)
        {
            var list = await  _repository.GetAllAuthorsAsync(token);

            return _mapper.Map<List<ShowAuthorWithoutBooksDto>>(list);
        }
    }
}
