using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class ShowReaderDto
    {
        public int IdReader { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly DateBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<string> BookLendings { get; set; }
    }

    public class ShowReaderWithoutDetailsDto 
    {
        public int IdReader { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
    }

    public class AddReaderDto 
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Surname { get; set; }

        [StringLength(50)]
        public string? Patronymic { get; set; }
        public DateOnly DateBirth { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class UpdateReaderDto
    {
        public int IdReader { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]

        public string Surname { get; set; }

        [StringLength(50)]
        public string? Patronymic { get; set; }
        public DateOnly DateBirth { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
