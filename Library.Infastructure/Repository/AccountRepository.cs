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
    public class AccountRepository : IAccountRepository
    {
        private readonly LibraryDbContext _context;

        public AccountRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        public async Task<Employee> GetByLoginAsync(string login, CancellationToken token)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Login == login, token);
        }

        public async Task<Employee> GetByRefreshAsync(string refreshToken, CancellationToken token)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.RefreshToken == refreshToken, token);
        }

        public async Task<bool> UpdateAsync(Employee employee,CancellationToken token)
        {
            var previousEmployee = await _context.Employees.FindAsync(employee.IdEmployee, token);
            if (previousEmployee == null)
                return false;

            previousEmployee.RefreshToken = employee.RefreshToken;
            previousEmployee.ExpireTime = employee.ExpireTime;

            await _context.SaveChangesAsync(token);

            return true;
        }
    }
}
