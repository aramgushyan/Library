using System.ComponentModel.DataAnnotations;

namespace Library.Application.Dto
{
    /// <summary>
    /// DTO для отображения книги.
    /// </summary>
    public class ShowBookDto
    {
        /// <summary>
        /// Id книги.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название книги.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Список авторов.
        /// </summary>
        public List<string> Authors { get; set; }

        /// <summary>
        /// Список жанров.
        /// </summary>
        public List<string> Genres { get; set; }

        /// <summary>
        /// Список экземпляров.
        /// </summary>
        public List<string> Instances { get; set; }
    }

    /// <summary>
    /// DTO для отображения книги.
    /// </summary>
    public class ShowBookWithoutDetailsDto
    {
        /// <summary>
        /// Id книги.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название книги.
        /// </summary>
        public string Title { get; set; }
    }

    /// <summary>
    /// DTO для добавления книги.
    /// </summary>
    public class AddBookDto
    {
        /// <summary>
        /// Название книги.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }

    /// <summary>
    /// DTO для обновления книги.
    /// </summary>
    public class UpdateBookDto
    {
        /// <summary>
        /// Id книги.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название книги.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}
