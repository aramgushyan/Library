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
            };
        }

        public Task<bool> UpdateAsync(int id, UpdateGenreDto genreDto)
        {
            return _repository.UpdateGenreAsync(id,new Genre() {Name = genreDto.Name});
        }
    }
}
