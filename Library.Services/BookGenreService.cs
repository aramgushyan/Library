using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class BookGenreService : IBookGenreService
    {
        private readonly IBookGenreRepository _repository;
        private readonly IMapper _mapper;

        public BookGenreService(IBookGenreRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавляет книгу-жанр.
        /// </summary>
        /// <param name="bookGenre">Добавляемая книга-жанр.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленной книги-жанра.</returns>
        public async Task<int> AddAsync(AddBookGenreDto bookGenre, CancellationToken token)
        {
            if (bookGenre == null)
                throw new ArgumentNullException("BookGenre не может быть null");

            return await _repository.AddBookGenreAsync(_mapper.Map<BookGenre>(bookGenre), token);
        }

        /// <summary>
        /// Удаляет книгу-жанр по id.
        /// </summary>
        /// <param name="id">Нужный id.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если получилось удалить.</returns>   
        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteBookGenreAsync(id, token);
        }

        /// <summary>
        /// Возвращает список всех книга-жанров.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список книга-жанров.</returns>
        public async Task<List<ShowBookGenreDto>> GetAllAsync(CancellationToken token)
        {
            return _mapper.Map<List<ShowBookGenreDto>>(await _repository.GetAllBookGenresAsync(token));
        }

        /// <summary>
        /// Возвращает книгу-жанр по id.
        /// </summary>
        /// <param name="id">Нужный id.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Книга-жанр.</returns>
        public async Task<ShowBookGenreDto> GetAsync(int id, CancellationToken token)
        {
            return _mapper.Map<ShowBookGenreDto>(await _repository.GetBookGenreByIdAsync(id,token));
        }

        /// <summary>
        /// Обновляет книгу-жанр по id.
        /// </summary>
        /// <param name="bookGenre">Новые данные книга-жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если получилось обновить.</returns>
        public async Task<bool> UpdateAsync(UpdateBookGenreDto bookGenre, CancellationToken token)
        {
            if (bookGenre == null)
                throw new ArgumentNullException("BookGenre не может быть null");

            return await _repository.UpdateBookGenreAsync(bookGenre.Id,_mapper.Map<BookGenre>(bookGenre), token);
        }
    }
}
