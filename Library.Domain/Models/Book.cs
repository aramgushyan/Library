using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class Book
    {
        [Key]
        public int IdBook { get; set; }
        [Required]
        public string Title { get; set; }

        public List<BookGenre> BookGenres { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }
        public List<Instance> Instances { get; set; } 
    }
}
