using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class AccountService : IAccountService
    {
        private readonly IPasswordService _passwordService;
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public AccountService(IPasswordService passwordService, IAccountRepository repository, IMapper mapper) 
        {
            _passwordService = passwordService;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ShowEmployeeForTokensDto> GetAsync(string refreshToken, CancellationToken token)
        {
            return _mapper.Map<ShowEmployeeForTokensDto>(await _repository.GetByRefreshAsync(refreshToken, token));
        }

        public async Task<bool> UpdateAsync(ShowEmployeeForTokensDto oldEmployee, string refreshToken, CancellationToken token)
        {
            oldEmployee.ExpireTime = DateTime.UtcNow.AddDays(7);
            var employee = _mapper.Map<Employee>(oldEmployee);
            employee.RefreshToken = refreshToken;

            return await _repository.UpdateAsync(employee, token);
        }

        public async Task<ShowEmployeeForTokensDto> VerifyHashedPasswordAsync(AccountDto accountDto,CancellationToken token, string refreshToken)
        {
            var employee = await _repository.GetByLoginAsync(accountDto.Login, token);

            if (employee == null)
                throw new KeyNotFoundException();

            if (!_passwordService.VerifyPassword(employee, employee.PasswordHash, accountDto.PasswordHash))
                return null;
            
            employee.RefreshToken = refreshToken;
            employee.ExpireTime = DateTime.UtcNow.AddDays(7);

            await _repository.UpdateAsync(employee, token);


            return _mapper.Map<ShowEmployeeForTokensDto>(employee);
        }
    }
}
