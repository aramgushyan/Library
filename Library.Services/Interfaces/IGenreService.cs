using Library.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IGenreService
    {
        public Task<int> AddAsync(AddGenreDto genreDto, CancellationToken token);
        public Task<ShowGenreDto> GetAsync(int id, CancellationToken token);
        public Task<List<ShowGenreWithoutBooksDto>> GetAllAsync(CancellationToken token);
        public Task<bool> DeleteAsync(int id, CancellationToken token);
        public Task<bool> UpdateAsync(UpdateGenreDto genreDto, CancellationToken token);
    }
}
