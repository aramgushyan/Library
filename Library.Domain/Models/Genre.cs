using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public class Genre
    {
        /// <summary>Id жанра</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Название</summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
