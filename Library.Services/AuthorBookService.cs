using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class AuthorBookService : IAuthorBookService
    {
        private readonly IAuthorBookRepository _repository;
        private readonly IMapper _mapper;

        public AuthorBookService(IAuthorBookRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }


        /// <summary>
        /// Добавляет автор-книгу.
        /// </summary>
        /// <param name="authorBookDto">Данные для добавления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленной связи.</returns>
        public async Task<int> AddAsync(AddAuthorBookDto authorBookDto, CancellationToken token)
        {
            if (authorBookDto == null)
                throw new ArgumentNullException("AuthorBook не может быть null");

            return await _repository.AddAuthorBookAsync(_mapper.Map<AuthorBook>(authorBookDto), token);
        }

        /// <summary>
        /// Удаляет автор-книгу по id.
        /// </summary>
        /// <param name="id">Нужный id.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если получилось удалить.</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteAuthorBookAsync(id, token);
        }

        /// <summary>
        /// Возвращает все автор-книги.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список автор-книг.</returns>
        public async Task<List<ShowAuthorBookDto>> GetAllAsync(CancellationToken token)
        {
            return _mapper.Map<List<ShowAuthorBookDto>>(await _repository.GetAllAuthorBookAsync(token));
        }

        /// <summary>
        /// Возвращает автор-книгу по id.
        /// </summary>
        /// <param name="id">Нужный id.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Найденная автор-книга.</returns>
        public async Task<ShowAuthorBookDto> GetByIdAsync(int id, CancellationToken token)
        {
            return _mapper.Map<ShowAuthorBookDto>(await _repository.GetAuthorBookByIdAsync(id, token));
        }

        /// <summary>
        /// Обновляет автор-книгу по id.
        /// </summary>
        /// <param name="authorBookDto">Новая автор-книга.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если получилось обновить.</returns>
        public async Task<bool> UpdateAsync(UpdateAuthorBookDto authorBookDto, CancellationToken token)
        {
            if (authorBookDto == null)
                throw new ArgumentNullException("AuthorBook не может быть null");

            return await _repository.UpdateAuthorBookAsync(authorBookDto.Id,_mapper.Map<AuthorBook>(authorBookDto), token);
        }
    }
}
