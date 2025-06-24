using Library.Application.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{

    [ApiController]
    [Route("api/auth/")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly IJwtService _jwtBuilder;

        public AccountController(IAccountService service, IJwtService builder) 
        {
            _service = service;
            _jwtBuilder = builder;
        }


        /// <summary>
        /// Верифицирует данные и выдаёт JWT и refresh токен.
        /// </summary>
        /// <param name="accountDto">Данные для входа</param>
        /// <param name="tokenCan">Токен отмены.</param>
        /// <returns>Информация о пользователе</returns>
        [HttpPost("login")]
        public async Task<ActionResult<ShowEmployeeForTokensDto>> Login(AccountDto accountDto, CancellationToken tokenCan )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            string refreshToken = _jwtBuilder.GenerateRefreshToken();

            var employee = await _service.VerifyHashedPasswordAsync(accountDto, tokenCan,refreshToken);
            if ( employee == null)
                return BadRequest();

            var token = _jwtBuilder.CreateJwtToken(employee);

            _jwtBuilder.AppendJwtCookie(token, refreshToken, Response);

            return Ok(employee);
        }

        /// <summary>
        /// Выходит из системы, удаляя JWT и refresh токен из куки.
        /// </summary>
        /// <returns>Результат выхода из системы.</returns>
        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("refresh");
            Response.Cookies.Delete("jwt");
            
            return NoContent();
        }

        /// <summary>
        /// Обновляет JWT и refresh токен по действующему refresh токену из куки.
        /// </summary>
        /// <param name="tokenCanc">Токен отмены.</param>
        /// <returns>Результат обновления токена.</returns>
        [HttpPut("RefreshToken")]
        public async Task<IActionResult> UpdateToken(CancellationToken tokenCanc)
        {
            var refteshToken = Request.Cookies["refresh"];

            if (refteshToken == null)
                return Unauthorized();

            var employee= await _service.GetAsync(refteshToken, tokenCanc);

            if (employee == null || employee.ExpireTime< DateTime.UtcNow)
                return Unauthorized();


            var token = _jwtBuilder.GenerateRefreshToken();

            await _service.UpdateAsync(employee, token, tokenCanc);

            var jwtToken = _jwtBuilder.CreateJwtToken(employee);

            _jwtBuilder.AppendJwtCookie(jwtToken,token, Response);

            return NoContent();
        }
    }
}
