using AutoMapper;
using Library.Application;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Library.Services
{
    public class AccountService : IAccountService
    {
        private readonly IPasswordService _passwordService;
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;
        private readonly JwtOptions _jwtOptions;

        public AccountService(IPasswordService passwordService, IAccountRepository repository, IMapper mapper, IOptions<JwtOptions> options)
        {
            _passwordService = passwordService;
            _repository = repository;
            _mapper = mapper;
            _jwtOptions = options.Value;
        }

        /// <summary>
        /// Получает данные сотрудника по переданному токену.
        /// </summary>
        /// <param name="refreshToken">Строка токена.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные сотрудника.</returns>
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
            if (oldEmployee == null)
                throw new ArgumentNullException("Employee не может быть null");

            oldEmployee.ExpireTime = DateTime.UtcNow.AddDays(_jwtOptions.ExpirationDaysForRefresh);
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
            if(accountDto == null)
                throw new ArgumentNullException("Введите логин и пароль");

            var employee = await _repository.GetByLoginAsync(accountDto.Login, token);

            if (employee == null)
                throw new KeyNotFoundException("Пользователь не найден");

            if (!_passwordService.VerifyPassword(employee, employee.PasswordHash, accountDto.PasswordHash))
                return null;
            
            employee.RefreshToken = refreshToken;
            employee.ExpireTime = DateTime.UtcNow.AddDays(_jwtOptions.ExpirationDaysForRefresh);

            await _repository.UpdateAsync(employee, token);


            return _mapper.Map<ShowEmployeeForTokensDto>(employee);
        }
    }
}
