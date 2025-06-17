using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class ShowGenreDto
    {
        public int IdGenre { get; set; }
        public string Name { get; set; }
        public List<string> Books { get; set; }
    }

    public class ShowGenreWithoutBooksDto
    {
        public int IdGenre { get; set; }
        public string Name { get; set; }
    }

    public class AddGenreDto 
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }

    public class UpdateGenreDto
    {
        public int IdGenre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
