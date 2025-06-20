using Library.Domain.Interfaces;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly LibraryDbContext _context;

        public EmployeeRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        public async Task<int> AddEmployeeAsync(Employee employee, CancellationToken token)
        {
            await _context.Employees.AddAsync(employee, token);
            await _context.SaveChangesAsync(token);

            return employee.IdEmployee;
        }

        public async Task<bool> DeleteEmployeeByIdAsync(int id, CancellationToken token)
        {
            return await _context.Employees.Where(e => e.IdEmployee == id).ExecuteDeleteAsync(token) > 0;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync(CancellationToken token)
        {
            return await _context.Employees.ToListAsync(token);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken token)
        {
            return await _context.Employees.FindAsync(id, token);
        }

        public async Task<string> GetLibraryByIdAsync(int id, CancellationToken token)
        {
            return await _context.Employees
            .Where(e => e.IdEmployee == id)
            .Select(e => string.Join(" ", e.Library.Street, e.Library.House))
            .FirstOrDefaultAsync(token);
        }
        

        public async Task<bool> UpdateEmployeeByIdAsync(int id ,Employee employee, CancellationToken token)
        {
            var previousEmployee = await _context.Employees.FindAsync(id);

            if (previousEmployee == null)
                return false;

            previousEmployee.Name = employee.Name;
            previousEmployee.Surname = employee.Surname;
            previousEmployee.Email = employee.Email;
            previousEmployee.Patronymic = employee.Patronymic;
            previousEmployee.DateBirth = employee.DateBirth;
            previousEmployee.LibraryId = employee.LibraryId;
            previousEmployee.Role = employee.Role;
            previousEmployee.PhoneNumber = employee.PhoneNumber;

            await _context.SaveChangesAsync(token);

            return true;
        }
    }
}
