using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Dto;
using Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository repository) 
        {
            _repository = repository;
        }

        public async Task AddAsync(AddGenreDto genreDto)
        {
            await _repository.AddGenreAsync(new Genre() {Name = genreDto.Name });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteGenreAsync(id);
        }

        public async Task<ShowGenreDto> GetAsync(int id)
        {
            var genre = await _repository.GetGenreByIdAsync(id);

            if (genre == null)
                return null;

            return new ShowGenreDto()
            {
                IdGenre = genre.IdGenre,
                Name = genre.Name,
                Books = genre.BookGenres.Select(bg => bg.Book.Title).ToList()
            };
        }

        public async Task<List<ShowGenreDto>> GetAllGenresAsync()
        {
            var genres = await _repository.GetAllGenresAsync();

            return genres.Select(g => new ShowGenreDto
            {
                IdGenre = g.IdGenre,
                Name = g.Name,
                Books = g.BookGenres.Select(bg => bg.Book.Title).ToList()
            }).ToList();
        }

        public async Task<bool> UpdateAsync(int id, UpdateGenreDto genreDto)
        {
            return await _repository.UpdateGenreAsync(id,new Genre() {Name = genreDto.Name});
        }
    }
}
