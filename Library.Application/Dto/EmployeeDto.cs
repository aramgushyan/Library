using Library.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Dto
{
    /// <summary>
    /// DTO для отображения сотрудника.
    /// </summary>
    public class ShowEmployeeDto
    {
        /// <summary>
        /// Id сотрудника.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id библиотеки.
        /// </summary>
        public int LibraryId { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateOnly DateBirth { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Название библиотеки.
        /// </summary>
        public string Library { get; set; }
    }

    /// <summary>
    /// DTO для отображения сотрудника с токенами.
    /// </summary>
    public class ShowEmployeeForTokensDto
    {
        /// <summary>
        /// Id сотрудника.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id библиотеки.
        /// </summary>
        public int LibraryId { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Время окончания действия токена.
        /// </summary>
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateOnly DateBirth { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Название библиотеки.
        /// </summary>
        public string Library { get; set; }
    }

    /// <summary>
    /// DTO для отображения сотрудника.
    /// </summary>
    public class ShowEmployeeWithoutDetailsDto
    {
        /// <summary>
        /// Id сотрудника.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id библиотеки.
        /// </summary>
        public int LibraryId { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? Patronymic { get; set; }
    }

    /// <summary>
    /// DTO для добавления сотрудника.
    /// </summary>
    public class AddEmployeeDto
    {
        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Хеш пароля.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Id библиотеки.
        /// </summary>
        public int LibraryId { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateOnly DateBirth { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        public Role Role { get; set; }
    }

    /// <summary>
    /// DTO для обновления сотрудника.
    /// </summary>
    public class UpdateEmployeeDto
    {
        /// <summary>
        /// Id сотрудника.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id библиотеки.
        /// </summary>
        public int LibraryId { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateOnly DateBirth { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Название библиотеки.
        /// </summary>
        public string Library { get; set; }
    }
}
