using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Models;
using Library.Infastructure.Repository;
using Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookLendingService : IBookLendingService
    {
        private readonly IBookLendingRepository _repository;
        private readonly IMapper _mapper;

        public BookLendingService(IBookLendingRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AddBookLendingDto bookLending, CancellationToken token)
        {
            if (bookLending == null)
                throw new ArgumentNullException("BookLending не может быть null");

           return await _repository.AddBookLendingAsync(_mapper.Map<BookLending>(bookLending), token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteBookLendingAsync(id, token);
        }

        public async Task<List<ShowBookLendingWithoutDetailsDto>> GetAllAsync(CancellationToken token)
        {
            return _mapper.Map<List<ShowBookLendingWithoutDetailsDto>>(await _repository.GetAllBookLendingAsync(token));
        }

        public async Task<ShowBookLendingDto> GetAsync(int id, CancellationToken token)
        {
            var bookLending = await _repository.GetBookLendingByIdAsync(id, token);

            if (bookLending == null)
                return null;

            var reader = await _repository.GetReaderByIdAsync(bookLending.ReaderId, token);
            var instance = await _repository.GetInstanceIdAsync(bookLending.InstanceId, token);

            var bookLendingDto = _mapper.Map<ShowBookLendingDto>(bookLending);
            bookLendingDto.Reader = reader;
            bookLendingDto.Instance = instance;

            return bookLendingDto;
        }

        public async Task<bool> UpdateAsync(UpdateBookLendingDto bookLending, CancellationToken token)
        {
            if (bookLending == null)
                throw new ArgumentNullException("BookLending не может быть null");

            return await _repository.UpdateBookLendingAsync(bookLending.Id, _mapper.Map<BookLending>(bookLending), token);
        }
    }
}
