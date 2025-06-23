namespace Library.Application.Dto
{
    /// <summary>
    /// DTO для отображения книги-жанра.
    /// </summary>
    public class ShowBookGenreDto
    {
        /// <summary>
        /// Id книги-жанра.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id книги.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Id жанра.
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// Порядковый номер.
        /// </summary>
        public int? SequenceNumber { get; set; }
    }

    /// <summary>
    /// DTO для обновления книги-жанра.
    /// </summary>
    public class UpdateBookGenreDto
    {
        /// <summary>
        /// Id книги-жанра.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id книги.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Id жанра.
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// Порядковый номер.
        /// </summary>
        public int? SequenceNumber { get; set; }
    }

    /// <summary>
    /// DTO для добавления книги-жанра.
    /// </summary>
    public class AddBookGenreDto
    {
        /// <summary>
        /// Id книги.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Id жанра.
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// Порядковый номер.
        /// </summary>
        public int? SequenceNumber { get; set; }
    }
}
