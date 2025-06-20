using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{

    public class AccountDto
    {
        [Required]
        [StringLength(10)]

        public string Login { get; set; }
        [Required]
        [StringLength(128)]
        public string PasswordHash { get; set; }
    }
}
