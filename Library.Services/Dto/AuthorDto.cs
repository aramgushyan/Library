using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Dto
{
    public class AuthorDto
    {
        [Required]

        public string Name { get; set; }
        [Required]

        public string Surname { get; set; }
        public string? Patronymic { get; set; }
    }
}
