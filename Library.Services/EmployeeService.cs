using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        private readonly IPasswordService _hasher;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper, IPasswordService hasher) 
        {
            _repository = repository;
            _mapper = mapper;
            _hasher = hasher;
        }

        /// <summary>
        /// Добавляет нового сотрудника.
        /// </summary>
        /// <param name="employee">Данные сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного сотрудника.</returns>
        public async Task<int> AddAsync(AddEmployeeDto employee, CancellationToken token)
        {
            if (employee == null)

                throw new ArgumentNullException("Employee не может быть null");

            var employeeDto = _mapper.Map<Employee>(employee);

            employeeDto.PasswordHash = _hasher.HashPassword(employeeDto, employee.PasswordHash );

            return await _repository.AddEmployeeAsync(employeeDto, token);
        }

        /// <summary>
        /// Удаляет сотрудника по id.
        /// </summary>
        /// <param name="id">id сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteEmployeeByIdAsync(id, token);
        }

        /// <summary>
        /// Получает список всех сотрудников.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список сотрудников.</returns>
        public async Task<List<ShowEmployeeWithoutDetailsDto>> GetAllAsync(CancellationToken token)
        {
            return _mapper.Map<List<ShowEmployeeWithoutDetailsDto>>(await _repository.GetAllEmployeesAsync(token));
        }

        /// <summary>
        /// Получает данные сотрудника по id.
        /// </summary>
        /// <param name="id">id сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные сотрудника или null, если не найден.</returns>
        public async Task<ShowEmployeeDto> GetAsync(int id, CancellationToken token)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id, token);

            if (employee == null)
                return null;

            var employeeDto = _mapper.Map<ShowEmployeeDto>(employee);

            employeeDto.Library = await _repository.GetLibraryByIdAsync(id, token);

            return employeeDto;
        }

        /// <summary>
        /// Обновляет данные сотрудника по id.
        /// </summary>
        /// <param name="employee">Новые данные сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public async Task<bool> UpdateAsync(UpdateEmployeeDto employee, CancellationToken token)
        {
            if(employee == null)
                throw new ArgumentNullException("Employee не может быть null");

            return await _repository.UpdateEmployeeByIdAsync(employee.Id, _mapper.Map<Employee>(employee), token);
        }
    }
}
