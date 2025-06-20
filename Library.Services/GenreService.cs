using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Application.Dto;
using Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

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

        public async Task<int> AddAsync(AddGenreDto genreDto, CancellationToken token)
        {
            if (genreDto == null)
                throw new ArgumentNullException("Жанр не может быть null");

            return await _repository.AddGenreAsync(_mapper.Map<Genre>(genreDto), token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteGenreAsync(id, token);
        }

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

        public async Task<List<ShowGenreWithoutBooksDto>> GetAllAsync(CancellationToken token)
        {
            var genres = await _repository.GetAllGenresAsync(token);

            return _mapper.Map<List<ShowGenreWithoutBooksDto>>(genres);
        }

        public async Task<bool> UpdateAsync(UpdateGenreDto genreDto, CancellationToken token)
        {
            if (genreDto == null)
                throw new ArgumentNullException("Жанр не может быть null");

            return await _repository.UpdateGenreAsync(genreDto.IdGenre, _mapper.Map<Genre>(genreDto), token);
        }
    }
}
