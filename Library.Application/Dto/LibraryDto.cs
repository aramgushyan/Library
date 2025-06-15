using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class ShowLibraryDto
    {
        public int IdLibrary { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public string PhoneNumber { get; set; }

        public List<string> Employees { get; set; }
        public List<BookAndInstancesDto> BooksAndInstances { get; set; }
    }

    public class AddLibraryDto
    {
        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        [Range(1,300)]
        public int House { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }

    public class UpdateLibraryDto
    {
        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        [Range(1, 300)]
        public int House { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }

}
