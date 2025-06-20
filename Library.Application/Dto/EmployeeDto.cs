using Library.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class ShowEmployeeDto
    {
        public int IdEmployee { get; set; }
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly DateBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Role Role { get; set; }

        public string Library { get; set; }
    }

    public class ShowEmployeeForTokensDto
    {
        public int IdEmployee { get; set; }
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string Login { get; set; }
        public DateTime ExpireTime { get; set; }
        public DateOnly DateBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Role Role { get; set; }

        public string Library { get; set; }
    }

    public class ShowEmployeeWithoutDetailsDto
    {
        public int IdEmployee { get; set; }
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
    }

    public class AddEmployeeDto
    {
        [Required]
        [StringLength(10)]
        public string Login { get; set; }

        [Required]
        [StringLength(128)]
        public string PasswordHash { get; set; }

        public int LibraryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly DateBirth { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Role Role { get; set; }
    }

    public class UpdateEmployeeDto 
    {
        public int IdEmployee { get; set; }
        public int LibraryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly DateBirth { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Role Role { get; set; }

        public string Library { get; set; }
    }

}
