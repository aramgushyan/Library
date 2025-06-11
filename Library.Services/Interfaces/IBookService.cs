using Library.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        public Task AddAsync(AddBookDto bookDto);
        public Task<ShowBookDto> GetAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id, UpdateBookDto bookDto);
    }
}
