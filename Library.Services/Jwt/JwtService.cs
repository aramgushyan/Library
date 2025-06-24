using Library.Application;
using Library.Application.Dto;
using Library.Domain.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Jwt
{
    public class JwtService: IJwtService
    {
        private readonly JwtOptions _options;

        public JwtService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string CreateJwtToken(ShowEmployeeForTokensDto employee) 
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,employee.Login),
                new Claim(ClaimTypes.Role, employee.Role.ToString())
            };

            var token = new JwtSecurityToken(
                claims:claims,
                issuer: _options.Issuer,
                audience: _options.Audience,
                expires: DateTime.UtcNow.AddMinutes(_options.ExpirationMinutes),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                    (_options.SecretKey)), SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefreshToken()
        {
            var randomNumbers = new byte[64];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumbers);

            return Convert.ToBase64String(randomNumbers);
        }

        public void AppendJwtCookie(string token, string refreshToken, HttpResponse response)
        {
            var cookie = new CookieOptions();
            cookie.Expires = DateTime.UtcNow.AddMinutes(_options.ExpirationMinutes);
            response.Cookies.Append("jwt", token, cookie);

            var refreshCookie = new CookieOptions();
            refreshCookie.Expires = DateTime.UtcNow.AddDays(_options.ExpirationDaysForRefresh);
            response.Cookies.Append("refresh", refreshToken, refreshCookie);
        }
    }
}
