using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class BookGenre
    {
        [Key]
        public int IdBookGenre { get; set; }
        public int IdBook {  get; set; }
        public int IdGenre { get; set; }
        public int? SequenceNumber { get; set; }

        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
