using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;

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

        /// <summary>
        /// Добавляет новый экземпляр.
        /// </summary>
        /// <param name="instance">Данные экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного экземпляра.</returns>
        public async Task<int> AddAsync(AddInstanceDto instance, CancellationToken token)
        {
            if (instance == null)
                throw new ArgumentNullException("Instance не может быть null");

            return await _repository.AddInstanceAsync(_mapper.Map<Instance>(instance), token);
        }

        /// <summary>
        /// Удаляет экземпляр по id.
        /// </summary>
        /// <param name="id">id экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteInstanceAsync(id, token);
        }

        /// <summary>
        /// Получает список всех экземпляров.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список экземпляров.</returns>
        public async Task<List<ShowInstanceWithoutDetailsDto>> GetAllAsync(CancellationToken token)
        {
            return _mapper.Map<List<ShowInstanceWithoutDetailsDto>>(await _repository.GetAllInstancesAsync(token));
        }

        /// <summary>
        /// Получает экземпляр по id.
        /// </summary>
        /// <param name="id">id экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
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

        /// <summary>
        /// Обновляет данные экземпляра по id.
        /// </summary>
        /// <param name="instance">Новые данные экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public async Task<bool> UpdateAsync(UpdateInstanceDto instance, CancellationToken token)
        {
            if (instance == null)
                return false;

            return await _repository.UpdateInstanceAsync(instance.Id, _mapper.Map<Instance>(instance), token);
        }
    }
}
