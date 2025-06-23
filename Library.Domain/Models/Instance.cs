using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public class Instance
    {
        /// <summary>Id экземпляра</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Id библиотеки</summary>
        public int LibraryId { get; set; }

        /// <summary>Id книги</summary>
        public int BookId { get; set; }

        /// <summary>Номер экземпляра</summary>
        [Required]
        public string BookNumber { get; set; }

        /// <summary>Библиотека</summary>
        public LibraryModel Library { get; set; }

        /// <summary>Книга</summary>
        public Book Book { get; set; }
    }
}
