using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    /// <summary>
    /// DTO для аутентификации пользователя.
    /// </summary>
    public class AccountDto
    {
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        [Required]
        [StringLength(10)]

        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        [Required]
        [StringLength(128)]
        public string PasswordHash { get; set; }
    }
}
