using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IReaderRepository _repository;
        private readonly IMapper _mapper;

        public ReaderService(IReaderRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AddReaderDto reader, CancellationToken token)
        {
            if (reader == null)
                throw new ArgumentNullException("Reader не может быть null");

            return await _repository.AddReaderAsync(_mapper.Map<Reader>(reader), token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteReaderAsync(id, token);
        }

        public async Task<List<ShowReaderWithoutDetailsDto>> GetAllAsync(CancellationToken token)
        {
            return _mapper.Map<List<ShowReaderWithoutDetailsDto>>(await _repository.GetAllReadersAsync(token));
        }

        public async Task<ShowReaderDto> GetAsync(int id, CancellationToken token)
        {
            var reader = await _repository.GetReaderByIdAsync(id, token);

            if (reader == null)
                return null;

            var readerDto = _mapper.Map<ShowReaderDto>(reader);

            readerDto.BookLendings = await _repository.GetActiveBookLendingsByReaderIdAsync(id, token);

            return readerDto;
        }

        public async Task<bool> UpdateAsync(UpdateReaderDto reader, CancellationToken token)
        {
            if (reader == null)
                throw new ArgumentNullException("Reader не может быть null");

            return await _repository.UpdateReaderAsync(reader.Id, _mapper.Map<Reader>(reader), token);
        }
    }
}
