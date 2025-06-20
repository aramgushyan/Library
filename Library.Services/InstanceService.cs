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
    public class InstanceService : IInstanceService
    {
        private readonly IInstanceRepository _repository;
        private readonly IMapper _mapper;

        public InstanceService(IInstanceRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AddInstanceDto instance, CancellationToken token)
        {
            if (instance == null)
                throw new ArgumentNullException("Instance не может быть null");

            return await _repository.AddInstanceAsync(_mapper.Map<Instance>(instance), token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteInstanceAsync(id, token);
        }

        public async Task<List<ShowInstanceWithoutDetailsDto>> GetAllAsync(CancellationToken token)
        {
            return _mapper.Map<List<ShowInstanceWithoutDetailsDto>>(await _repository.GetAllInstancesAsync(token));
        }

        public async Task<ShowInstanceDto> GetAsync(int id, CancellationToken token)
        {
            var instance = await _repository.GetInstanceByIdAsync(id, token);

            if (instance == null)
                return null;

            var library = await _repository.GetLibraryByIdAsync(instance.LibraryId, token);
            var book = await _repository.GetBookByIdAsync(instance.BookId, token);

            var instanceDto = _mapper.Map<ShowInstanceDto>(instance);
            instanceDto.Book = book;
            instanceDto.Library = library;

            return instanceDto;

        }

        public async Task<bool> UpdateAsync(UpdateInstanceDto instance, CancellationToken token)
        {
            if (instance == null)
                return false;

            return await _repository.UpdateInstanceAsync(instance.IdInstance, _mapper.Map<Instance>(instance), token);
        }
    }
}
