using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class ShowInstanceDto
    {
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public int BookId { get; set; }

        public string BookNumber { get; set; }

        public string Library { get; set; }
        public string Book { get; set; }
    }

    public class ShowInstanceWithoutDetailsDto 
    {
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public int BookId { get; set; }

        public string BookNumber { get; set; }
    }

    public class UpdateInstanceDto 
    {
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public int BookId { get; set; }

        [Required]
        public string BookNumber { get; set; }
    }

    public class AddInstanceDto
    {
        public int LibraryId { get; set; }
        public int BookId { get; set; }

        [Required]
        public string BookNumber { get; set; }
    }
}
