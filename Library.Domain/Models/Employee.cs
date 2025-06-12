using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{

    public enum Position 
    {
        Librarian,
        Director, 
        Cleaner,
        Technician
    }
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }

        public int IdLibrary { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        public string? Patronymic { get; set; }

        public DateOnly DateBirth { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Position Position { get; set; }

        public LibraryModel Library { get; set; }

    }
}
