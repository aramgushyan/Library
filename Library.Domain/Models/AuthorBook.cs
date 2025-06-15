using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class AuthorBook
    {
        [Key]
        public int IdAuthorBook { get; set; }
        public int BookId { get; set; } 
        public int AuthorId { get; set; }
        public string? Comment { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
