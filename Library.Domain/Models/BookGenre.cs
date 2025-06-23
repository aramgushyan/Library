using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public class BookGenre
    {
        /// <summary>Id</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Id книги</summary>
        public int BookId { get; set; }

        /// <summary>Id жанра</summary>
        public int GenreId { get; set; }

        /// <summary>Порядковый номер</summary>
        public int? SequenceNumber { get; set; }

        /// <summary>Книга</summary>
        public Book Book { get; set; }

        /// <summary>Жанр</summary>
        public Genre Genre { get; set; }
    }
}
