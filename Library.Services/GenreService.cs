using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository repository,IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавляет новый жанр.
        /// </summary>
        /// <param name="genreDto">Данные жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного жанра.</returns>
        public async Task<int> AddAsync(AddGenreDto genreDto, CancellationToken token)
        {
            if (genreDto == null)
                throw new ArgumentNullException("Жанр не может быть null");

            return await _repository.AddGenreAsync(_mapper.Map<Genre>(genreDto), token);
        }

        /// <summary>
        /// Удаляет жанр по id.
        /// </summary>
        /// <param name="id">id жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteGenreAsync(id, token);
        }

        /// <summary>
        /// Получает жанр по id.
        /// </summary>
        /// <param name="id">id жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные жанра.</returns>
        public async Task<ShowGenreDto> GetAsync(int id, CancellationToken token)
        {
            var genre = await _repository.GetGenreByIdAsync(id, token);

            if (genre == null)
                return null;

            var books = await _repository.GetBooksByGenreIdAsync(id, token);

            var genreDto = _mapper.Map<ShowGenreDto>(genre);
            genreDto.Books = books;
            return genreDto;
        }

        /// <summary>
        /// Получает список всех жанров.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список жанров.</returns>
        public async Task<List<ShowGenreWithoutBooksDto>> GetAllAsync(CancellationToken token)
        {
            var genres = await _repository.GetAllGenresAsync(token);

            return _mapper.Map<List<ShowGenreWithoutBooksDto>>(genres);
        }

        /// <summary>
        /// Обновляет данные жанра по id.
        /// </summary>
        /// <param name="genreDto">Новые данные жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public async Task<bool> UpdateAsync(UpdateGenreDto genreDto, CancellationToken token)
        {
            if (genreDto == null)
                throw new ArgumentNullException("Жанр не может быть null");

            return await _repository.UpdateGenreAsync(genreDto.Id, _mapper.Map<Genre>(genreDto), token);
        }
    }
}
