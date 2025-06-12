using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Dto
{
    public class ShowGenreDto
    {
        public int IdGenre { get; set; }

        [Required]
        [MaxLength(50)]
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
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
