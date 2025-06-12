using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class LibraryModel
    {
        [Key]
        public int IdLibrary { get; set; }

        [Required]
        [StringLength(100)]
        public string Street { get; set; }
        public int House { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Instance> Instances { get; set; }
    }
}
