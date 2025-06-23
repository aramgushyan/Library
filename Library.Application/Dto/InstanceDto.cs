using System.ComponentModel.DataAnnotations;

namespace Library.Application.Dto
{
    /// <summary>
    /// DTO для отображения экземпляра.
    /// </summary>
    public class ShowInstanceDto
    {
        /// <summary>
        /// Id экземпляра
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id библиотеки
        /// </summary>
        public int LibraryId { get; set; }

        /// <summary>
        /// Id книги
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Номер экземпляра
        /// </summary>
        public string BookNumber { get; set; }

        /// <summary>
        /// Библиотека
        /// </summary>
        public string Library { get; set; }

        /// <summary>
        /// Книга
        /// </summary>
        public string Book { get; set; }
    }

    /// <summary>
    /// DTO для отображения экземпляра.
    /// </summary>
    public class ShowInstanceWithoutDetailsDto
    {
        /// <summary>
        /// Id экземпляра
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id библиотеки
        /// </summary>
        public int LibraryId { get; set; }

        /// <summary>
        /// Id книги
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Номер экземпляра
        /// </summary>
        public string BookNumber { get; set; }
    }

    /// <summary>
    /// DTO для обновления экземпляра.
    /// </summary>
    public class UpdateInstanceDto
    {
        /// <summary>
        /// Id экземпляра
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id библиотеки
        /// </summary>
        public int LibraryId { get; set; }

        /// <summary>
        /// Id книги
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Номер экземпляра
        /// </summary>
        [Required]
        public string BookNumber { get; set; }
    }

    /// <summary>
    /// DTO для добавления экземпляра.
    /// </summary>
    public class AddInstanceDto
    {
        /// <summary>
        /// Id библиотеки
        /// </summary>
        public int LibraryId { get; set; }

        /// <summary>
        /// Id книги
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Номер экземпляра
        /// </summary>
        [Required]
        public string BookNumber { get; set; }
    }
}
