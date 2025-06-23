namespace Library.Application.Dto
{
    /// <summary>
    /// DTO для отображения данных автор-книга.
    /// </summary>
    public class ShowAuthorBookDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер книги.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Номер автора.
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string? Comment { get; set; }
    }

    /// <summary>
    /// DTO для добавления записи автор-книга.
    /// </summary>
    public class AddAuthorBookDto 
    {
        /// <summary>
        /// Номер книги.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Номер автора.
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string? Comment { get; set; }
    }

    /// <summary>
    /// DTO для обновления записи автор-книга.
    /// </summary>
    public class UpdateAuthorBookDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер книги.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Номер автора.
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string? Comment { get; set; }
    }
}
