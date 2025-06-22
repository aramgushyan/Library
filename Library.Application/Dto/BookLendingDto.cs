using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class ShowBookLendingDto
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int InstanceId { get; set; }
        public DateOnly DateIssue { get; set; }
        public int ReturnPeriod { get; set; }
        public DateOnly? DateReturn { get; set; }

        public string Reader { get; set; }
        public string Instance { get; set; }
    }

    public class ShowBookLendingWithoutDetailsDto
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int InstanceId { get; set; }
        public DateOnly DateIssue { get; set; }
        public int ReturnPeriod { get; set; }
        public DateOnly? DateReturn { get; set; }
    }

    public class AddBookLendingDto 
    {
        public int ReaderId { get; set; }
        public int InstanceId { get; set; }
        public DateOnly DateIssue { get; set; }
        public int ReturnPeriod { get; set; }
        public DateOnly? DateReturn { get; set; }
    }

    public class UpdateBookLendingDto
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int InstanceId { get; set; }
        public DateOnly DateIssue { get; set; }
        public int ReturnPeriod { get; set; }
        public DateOnly? DateReturn { get; set; }
    }
}
