using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class ShowBookGenreDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public int? SequenceNumber { get; set; }
    }

    public class UpdateBookGenreDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public int? SequenceNumber { get; set; }
    }

    public class AddBookGenreDto
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public int? SequenceNumber { get; set; }
    }
}
