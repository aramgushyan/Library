using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<int> AddAsync(AddEmployeeDto employee, CancellationToken token)
        {
            if (employee == null)
                throw new ArgumentNullException("Employee не может быть null");

            var employeeDto = _mapper.Map<Employee>(employee);

            employeeDto.PasswordHash = _hasher.HashPassword(employeeDto, employee.PasswordHash );

            return await _repository.AddEmployeeAsync(employeeDto, token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteEmployeeByIdAsync(id, token);
        }

        public async Task<List<ShowEmployeeWithoutDetailsDto>> GetAllAsync(CancellationToken token)
        {
            return _mapper.Map<List<ShowEmployeeWithoutDetailsDto>>(await _repository.GetAllEmployeesAsync(token));
        }

        public async Task<ShowEmployeeDto> GetAsync(int id, CancellationToken token)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id, token);

            if (employee == null)
                return null;

            var employeeDto = _mapper.Map<ShowEmployeeDto>(employee);

            employeeDto.Library = await _repository.GetLibraryByIdAsync(id, token);

            return employeeDto;
        }

        public async Task<bool> UpdateAsync(UpdateEmployeeDto employee, CancellationToken token)
        {
            if(employee == null)
                throw new ArgumentNullException("Employee не может быть null");

            return await _repository.UpdateEmployeeByIdAsync(employee.IdEmployee, _mapper.Map<Employee>(employee), token);
        }
    }
}
