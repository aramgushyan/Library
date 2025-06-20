using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(Employee user, string password);
        bool VerifyPassword(Employee user, string hashedPassword, string providedPassword);
    }
}
