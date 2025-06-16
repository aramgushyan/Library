using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class ShowAuthorBookDto
    {
        public int IdAuthorBook { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string? Comment { get; set; }
    }

    public class AddAuthorBookDto 
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string? Comment { get; set; }
    }

    public class UpdateAuthorBookDto
    {
        public int IdAuthorBook { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string? Comment { get; set; }
    }
}
