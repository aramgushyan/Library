using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class Instance
    {
        [Key]
        public int IdInstance { get; set; }
        public int LibraryId { get; set; }
        public int BookId { get; set; }

        [Required]
        public string BookNumber { get; set; }

        public LibraryModel Library { get; set; }
        public Book Book { get; set; }
    }   
}
