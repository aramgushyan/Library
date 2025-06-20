using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllEmployeesAsync(CancellationToken token);
        public Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken token);

        public Task<string> GetLibraryByIdAsync(int id, CancellationToken token);
        public Task<bool> DeleteEmployeeByIdAsync(int id, CancellationToken token);
        public Task<int> AddEmployeeAsync(Employee employee, CancellationToken token);
        public Task<bool> UpdateEmployeeByIdAsync(int id ,Employee employee, CancellationToken token);
    }
}
