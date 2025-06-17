using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class ShowBookDto
    {
        public int IdBook { get; set; }
        public string Title { get; set; }

        public List<string> Authors { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Instances { get; set; }

    }

    public class ShowBookWithoutDetailsDto
    {
        public int IdBook { get; set; }
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
        public int IdBook { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}
