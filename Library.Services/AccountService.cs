using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;

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

        /// <summary>
        /// Получает данные сотрудника по переданному токену.
        /// </summary>
        /// <param name="refreshToken">Строка токена.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные сотрудника.</returns
        public async Task<ShowEmployeeForTokensDto> GetAsync(string refreshToken, CancellationToken token)
        {
            return _mapper.Map<ShowEmployeeForTokensDto>(await _repository.GetByRefreshAsync(refreshToken, token));
        }

        /// <summary>
        /// Обновляет токен сотрудника.
        /// </summary>
        /// <param name="oldEmployee">Старые данные сотрудника.</param>
        /// <param name="refreshToken">Новый токен.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public async Task<bool> UpdateAsync(ShowEmployeeForTokensDto oldEmployee, string refreshToken, CancellationToken token)
        {
            oldEmployee.ExpireTime = DateTime.UtcNow.AddDays(7);
            var employee = _mapper.Map<Employee>(oldEmployee);
            employee.RefreshToken = refreshToken;

            return await _repository.UpdateAsync(employee, token);
        }

        /// <summary>
        /// Проверяет логин и пароль.
        /// </summary>
        /// <param name="accountDto">Введённые данные сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <param name="refreshToken">Новый токен обновления.</param>
        /// <returns>Данные сотрудника при успешной проверке, иначе null.</returns>
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
