using Library.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IGenreService
    {
        public Task AddAsync(AddGenreDto genreDto);
        public Task<ShowGenreDto> GetAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id, UpdateGenreDto genreDto);
    }
}
