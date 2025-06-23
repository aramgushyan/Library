using System.ComponentModel.DataAnnotations;

namespace Library.Application.Dto
{
    /// <summary>
    /// DTO для отображения библиотеки.
    /// </summary>
    public class ShowLibraryDto
    {
        /// <summary>
        /// Id библиотеки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Дом
        /// </summary>
        public int House { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Сотрудники
        /// </summary>
        public List<string> Employees { get; set; }

        /// <summary>
        /// Книги и экземпляры
        /// </summary>
        public List<BookAndInstancesDto> BooksAndInstances { get; set; }
    }

    /// <summary>
    /// DTO для отображения библиотеки.
    /// </summary>
    public class ShowLibraryWithoutDetailsDto
    {
        /// <summary>
        /// Id библиотеки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Дом
        /// </summary>
        public int House { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string PhoneNumber { get; set; }
    }

    /// <summary>
    /// DTO для добавления библиотеки.
    /// </summary>
    public class AddLibraryDto
    {
        /// <summary>
        /// Улица
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        /// <summary>
        /// Дом
        /// </summary>
        [Range(1, 300)]
        public int House { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }

    /// <summary>
    /// DTO для обновления библиотеки.
    /// </summary>
    public class UpdateLibraryDto
    {
        /// <summary>
        /// Id библиотеки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        /// <summary>
        /// Дом
        /// </summary>
        [Range(1, 300)]
        public int House { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
