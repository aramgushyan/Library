namespace Library.Application.Dto
{
    /// <summary>
    /// DTO для отображения книги и списка её экземпляров.
    /// </summary>
    public class BookAndInstancesDto
    {
        /// <summary>
        /// Название книги.
        /// </summary>
        public string BookTitle { get; set; }

        /// <summary>
        /// Список номеров экземпляров книги.
        /// </summary>
        public List<string> BookNumbers { get; set; }
    }
}
