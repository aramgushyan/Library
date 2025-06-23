using System.ComponentModel.DataAnnotations;

namespace Library.Application.Dto
{
    /// <summary>
    /// DTO для отображения автора с книгами.
    /// </summary>
    public class ShowAuthorDto
    {
        /// <summary>
        /// Id автора.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя автора.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия автора.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество автора.
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Список названий книг автора.
        /// </summary>
        public List<string> Books { get; set; }
    }

    /// <summary>
    /// DTO для отображения автора без списка книг.
    /// </summary>
    public class ShowAuthorWithoutBooksDto
    {
        /// <summary>
        /// Id автора.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя автора.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия автора.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество автора.
        /// </summary>
        public string? Patronymic { get; set; }
    }

    /// <summary>
    /// DTO для добавления нового автора.
    /// </summary>
    public class AddAuthorDto
    {
        /// <summary>
        /// Имя автора.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия автора.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        /// <summary>
        /// Отчество автора.
        /// </summary>
        [StringLength(100)]
        public string? Patronymic { get; set; }
    }

    /// <summary>
    /// DTO для обновления данных автора.
    /// </summary>
    public class UpdateAuthorDto
    {
        /// <summary>
        /// Id автора.
        /// </summary>
        public int IdAuthor { get; set; }

        /// <summary>
        /// Имя автора.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия автора.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        /// <summary>
        /// Отчество автора.
        /// </summary>
        [StringLength(100)]
        public string? Patronymic { get; set; }
    }
}
