using Library.Domain.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<Employee> _hasher = new();

        public string HashPassword(Employee user, string password)
        {
            return _hasher.HashPassword(user, password);
        }

        public bool VerifyPassword(Employee user, string hashedPassword, string providedPassword)
        {
            var result = _hasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
