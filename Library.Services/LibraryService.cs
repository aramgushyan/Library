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
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _repository;
        private readonly IMapper _mapper;

        public LibraryService(ILibraryRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AddLibraryDto libraryDto, CancellationToken token)
        {
            if (libraryDto == null)
                throw new ArgumentNullException("Библиотека не может быть null");

            return await _repository.AddLibraryAsync(_mapper.Map<LibraryModel>(libraryDto), token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await  _repository.DeleteLibraryAsync(id, token);
        }

        public async Task<List<ShowLibraryWithoutDetailsDto>> GetAllAsync(CancellationToken token)
        {
            return  _mapper.Map<List<ShowLibraryWithoutDetailsDto>>(await _repository.GetAllLibrariesAsync(token));
        }

        public  async Task<ShowLibraryDto> GetAsync(int id, CancellationToken token)
        {
            var library = await _repository.GetLibraryByIdAsync(id, token);
            if (library == null)
                return null;

            var employes = await _repository.GetEmployeesByLibraryIdAsync(id, token);

            var instances = await _repository.GetInstancesByLibraryIdAsync(id, token);
            var instancesAndBooks = GetBookAndInstances(instances);

            var libraryWithDetails = _mapper.Map<ShowLibraryDto>(library);
            libraryWithDetails.Employees = employes;
            libraryWithDetails.BooksAndInstances = instancesAndBooks;

            return libraryWithDetails ;
            
        }

        public async Task<bool> UpdateAsync(UpdateLibraryDto libraryDto, CancellationToken token)
        {
            if (libraryDto == null)
                throw new ArgumentNullException("Библиотека не может быть null");

            return await _repository.UpdateLibraryAsync(libraryDto.Id, _mapper.Map<LibraryModel>(libraryDto), token);
        }

        private List<BookAndInstancesDto> GetBookAndInstances(List<Instance> instances) 
        {
            if (instances == null)
                return null;

            return instances.GroupBy(i => i.Book.Title).Select(g => new BookAndInstancesDto
            {
                BookTitle = g.Key,
                BookNumbers = g.Select(i => i.BookNumber).ToList()
            }).ToList();
            
        }
    }
}
