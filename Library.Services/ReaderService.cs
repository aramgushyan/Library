using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;

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

        /// <summary>
        /// Добавляет нового читателя.
        /// </summary>
        /// <param name="reader">Данные читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id нового читателя.</returns>
        public async Task<int> AddAsync(AddReaderDto reader, CancellationToken token)
        {
            if (reader == null)
                throw new ArgumentNullException("Reader не может быть null");

            return await _repository.AddReaderAsync(_mapper.Map<Reader>(reader), token);
        }

        /// <summary>
        /// Удаляет читателя по номеру.
        /// </summary>
        /// <param name="id">Номер читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление успешно.</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteReaderAsync(id, token);
        }

        /// <summary>
        /// Возвращает список всех читателей.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список читателей.</returns>
        public async Task<List<ShowReaderWithoutDetailsDto>> GetAllAsync(CancellationToken token)
        {
            return _mapper.Map<List<ShowReaderWithoutDetailsDto>>(await _repository.GetAllReadersAsync(token));
        }

        /// <summary>
        /// Возвращает информацию о конкретном читателе.
        /// </summary>
        /// <param name="id">Номер читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные читателя с активными выдачами.</returns>
        public async Task<ShowReaderDto> GetAsync(int id, CancellationToken token)
        {
            var reader = await _repository.GetReaderByIdAsync(id, token);

            if (reader == null)
                return null;

            var readerDto = _mapper.Map<ShowReaderDto>(reader);

            readerDto.BookLendings = await _repository.GetActiveBookLendingsByReaderIdAsync(id, token);

            return readerDto;
        }

        /// <summary>
        /// Обновляет данные читателя.
        /// </summary>
        /// <param name="reader">Новые данные читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление успешно.</returns>
        public async Task<bool> UpdateAsync(UpdateReaderDto reader, CancellationToken token)
        {
            if (reader == null)
                throw new ArgumentNullException("Reader не может быть null");

            return await _repository.UpdateReaderAsync(reader.Id, _mapper.Map<Reader>(reader), token);
        }
    }
}
