using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class ShowAuthorDto
    {
        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }

        public List<string> Books { get; set; }
    }

    public class ShowAuthorWithoutBooksDto
    {
        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }

    }

    public class AddAuthorDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }


        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string? Patronymic { get; set; }
    }

    public class UpdateAuthorDto
    {
        public int IdAuthor { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string? Patronymic { get; set; }
    }
}
