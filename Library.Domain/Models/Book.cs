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

    }
}
