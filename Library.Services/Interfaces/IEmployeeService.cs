using Library.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<ShowEmployeeWithoutDetailsDto>> GetAllAsync(CancellationToken token);
        public Task<ShowEmployeeDto> GetAsync(int id, CancellationToken token);
        public Task<bool> DeleteAsync(int id, CancellationToken token);
        public Task<bool> UpdateAsync(UpdateEmployeeDto employee, CancellationToken token);
        public Task<int> AddAsync(AddEmployeeDto employee, CancellationToken token);
    }
}
