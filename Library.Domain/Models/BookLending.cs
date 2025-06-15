using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class BookLending
    {
        [Key]
        public int IdBookLending { get; set; } 
        public int ReaderId { get; set; }
        public int InstanceId { get; set; }
        public DateOnly DateIssue { get; set; }
        public int ReturnPeriod { get; set; }
        public DateOnly? DateReturn { get; set; }

        public Reader Reader { get; set; }
        public Instance Instance { get; set; }

    }
}
