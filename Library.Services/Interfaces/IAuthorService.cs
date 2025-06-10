using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Models;
using Library.Services.Dto;

namespace Library.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task AddAsync(AuthorDto author);
        public Task<AuthorDto> GetAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(AuthorDto author);
    }
}
