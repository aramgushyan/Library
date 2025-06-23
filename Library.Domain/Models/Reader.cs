using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public class Reader
    {
        /// <summary>Id читателя</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Имя</summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>Фамилия</summary>
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        /// <summary>Отчество</summary>
        [StringLength(50)]
        public string? Patronymic { get; set; }

        /// <summary>Дата рождения</summary>
        public DateOnly DateBirth { get; set; }

        /// <summary>Телефон</summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>Email</summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
