using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public class AuthorBook
    {
        /// <summary>Id</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Id книги</summary>
        public int BookId { get; set; }

        /// <summary>Id автора</summary>
        public int AuthorId { get; set; }

        /// <summary>Комментарий</summary>
        public string? Comment { get; set; }

        /// <summary>Книга</summary>
        public Book Book { get; set; }

        /// <summary>Автор</summary>
        public Author Author { get; set; }
    }
}
