using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IBookGenreService
    {
        public Task<int> AddAsync(AddBookGenreDto bookGenre, CancellationToken token);
        public Task<bool> UpdateAsync(UpdateBookGenreDto bookGenre, CancellationToken token);
        public Task<bool> DeleteAsync(int id, CancellationToken token);
        public Task<List<ShowBookGenreDto>> GetAllAsync(CancellationToken token);
        public Task<ShowBookGenreDto> GetAsync(int id, CancellationToken token);
    }
}
