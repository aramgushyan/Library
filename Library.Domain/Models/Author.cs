using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public class Author
    {
        /// <summary>Id автора</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Имя</summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>Фамилия</summary>
        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        /// <summary>Отчество</summary>
        [StringLength(100)]
        public string? Patronymic { get; set; }
    }
}
