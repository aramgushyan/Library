using System.ComponentModel.DataAnnotations;

namespace Library.Application.Dto
{
    /// <summary>
    /// DTO для отображения жанра.
    /// </summary>
    public class ShowGenreDto
    {
        /// <summary>
        /// Id жанра
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Книги
        /// </summary>
        public List<string> Books { get; set; }
    }

    /// <summary>
    /// DTO для отображения жанра.
    /// </summary>
    public class ShowGenreWithoutBooksDto
    {
        /// <summary>
        /// Id жанра
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// DTO для добавления жанра.
    /// </summary>
    public class AddGenreDto
    {
        /// <summary>
        /// Название
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }

    /// <summary>
    /// DTO для обновления жанра.
    /// </summary>
    public class UpdateGenreDto
    {
        /// <summary>
        /// Id жанра
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
