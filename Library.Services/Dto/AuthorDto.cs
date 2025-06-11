using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Dto
{
    public class ShowAuthorDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [StringLength(100)]
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
