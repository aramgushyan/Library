using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Dto
{
    public class ShowBookDto
    {
        public int IdBook { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }

    public class AddBookDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }

    public class UpdateBookDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}
