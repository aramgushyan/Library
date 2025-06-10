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
        public int IdLibrary { get; set; }
        public int IdBook { get; set; }

        [Required]
        public string BookNumber { get; set; }

        public Library Library { get; set; }
        public Book Book { get; set; }
        public List<BookLending> BookLendings { get; set; }
    }   
}
