using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public class LibraryModel
    {
        /// <summary>Id библиотеки</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Улица</summary>
        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        /// <summary>Дом</summary>
        [Range(1, 300)]
        public int House { get; set; }

        /// <summary>Телефон</summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
