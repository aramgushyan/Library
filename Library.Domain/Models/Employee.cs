using Library.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public class Employee
    {
        /// <summary>Id сотрудника</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Логин</summary>
        [Required]
        [StringLength(10)]
        public string Login { get; set; }

        /// <summary>Хеш пароля</summary>
        [Required]
        [StringLength(128)]
        public string PasswordHash { get; set; }

        /// <summary>Id библиотеки</summary>
        public int LibraryId { get; set; }

        /// <summary>Имя</summary>
        [Required]
        public string Name { get; set; }

        /// <summary>Фамилия</summary>
        [Required]
        public string Surname { get; set; }

        /// <summary>Отчество</summary>
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

        /// <summary>Рефреш-токен</summary>
        public string? RefreshToken { get; set; }

        /// <summary>Время окончания действия токена</summary>
        public DateTime ExpireTime { get; set; }

        /// <summary>Роль</summary>
        [Required]
        public Role Role { get; set; }

        /// <summary>Библиотека</summary>
        public LibraryModel Library { get; set; }
    }
}
