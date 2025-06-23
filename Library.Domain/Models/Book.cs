using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public class Book
    {
        /// <summary>Id книги</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Название книги</summary>
        [Required]
        public string Title { get; set; }
    }
}
