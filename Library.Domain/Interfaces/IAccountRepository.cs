using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IAccountRepository
    {
        public Task<Employee> GetByLoginAsync(string login, CancellationToken token);
        public Task<bool> UpdateAsync(Employee employee, CancellationToken token);
        public Task<Employee> GetByRefreshAsync(string refreshToken, CancellationToken token);
    }
}
