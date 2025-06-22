using System.ComponentModel.DataAnnotations;

namespace Library.Application.Dto
{
    public class ShowLibraryDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public string PhoneNumber { get; set; }

        public List<string> Employees { get; set; }
        public List<BookAndInstancesDto> BooksAndInstances { get; set; }
    }

    public class ShowLibraryWithoutDetailsDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public string PhoneNumber { get; set; }
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
        public int Id { get; set; }

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
