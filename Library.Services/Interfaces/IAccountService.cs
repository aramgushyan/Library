using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<ShowEmployeeForTokensDto> VerifyHashedPasswordAsync(AccountDto account, CancellationToken token, string refreshToken);
        public Task<ShowEmployeeForTokensDto> GetAsync(string refreshToken, CancellationToken token);
        public Task<bool> UpdateAsync(ShowEmployeeForTokensDto oldEmployee, string refreshToken, CancellationToken token);

    }
}
