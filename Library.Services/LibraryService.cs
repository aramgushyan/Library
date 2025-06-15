using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Application.Dto;
using Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Services.Helpers;

namespace Library.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _repository;

        public LibraryService(ILibraryRepository repository) 
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(AddLibraryDto libraryDto)
        {
            return await _repository.AddLibraryAsync(new LibraryModel()
            {
                Street = libraryDto.Street,
                House = libraryDto.House,
                PhoneNumber = libraryDto.PhoneNumber
            });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await  _repository.DeleteLibraryAsync(id);
        }

        public  async Task<ShowLibraryDto> GetAsync(int id)
        {
            var library = await _repository.GetLibraryByIdAsync(id);
            if (library == null)
                return null;

            return new ShowLibraryDto()
            {
                Street = library.Street,
                House = library.House,
                PhoneNumber = library.PhoneNumber,
                IdLibrary = library.IdLibrary,
                Employees = library.Employees.Select(e => NameHelper.GetFullName(e.Name,e.Surname,e.Patronymic)).ToList(),
                BooksAndInstances = library.Instances.GroupBy(i => i.Book.Title)
                .Select(g => new BookAndInstancesDto
                {
                    BookTitle = g.Key,
                    BookNumbers = g.Select(i => i.BookNumber).ToList()
                }).ToList()
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateLibraryDto libraryDto)
        {
            return await _repository.UpdateLibraryAsync(id, new LibraryModel()
            {
                Street = libraryDto.Street,
                House = libraryDto.House,
                PhoneNumber = libraryDto.PhoneNumber
            });
        }
    }
}
