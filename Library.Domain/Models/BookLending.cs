using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public class BookLending
    {
        /// <summary>Id выдачи книги</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Id читателя</summary>
        public int ReaderId { get; set; }

        /// <summary>Id экземпляра книги</summary>
        public int InstanceId { get; set; }

        /// <summary>Дата выдачи</summary>
        public DateOnly DateIssue { get; set; }

        /// <summary>Срок возврата</summary>
        public int ReturnPeriod { get; set; }

        /// <summary>Дата возврата</summary>
        public DateOnly? DateReturn { get; set; }

        /// <summary>Читатель</summary>
        public Reader Reader { get; set; }

        /// <summary>Экземпляр книги</summary>
        public Instance Instance { get; set; }
    }
}
