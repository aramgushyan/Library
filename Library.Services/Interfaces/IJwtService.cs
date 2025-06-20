using Library.Application.Dto;
using Library.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IJwtService
    {
        public string CreateJwtToken(ShowEmployeeForTokensDto employee);
        public  string GenerateRefreshToken();
        public void AppendJwtCookie(string token, string refreshToken, HttpResponse response);

    }
}
