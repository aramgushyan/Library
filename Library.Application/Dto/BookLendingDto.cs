namespace Library.Application.Dto
{
    /// <summary>
    /// DTO для отображения выдачи книги.
    /// </summary>
    public class ShowBookLendingDto
    {
        /// <summary>
        /// Id выдачи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id читателя.
        /// </summary>
        public int ReaderId { get; set; }

        /// <summary>
        /// Id экземпляра.
        /// </summary>
        public int InstanceId { get; set; }

        /// <summary>
        /// Дата выдачи.
        /// </summary>
        public DateOnly DateIssue { get; set; }

        /// <summary>
        /// Срок возврата.
        /// </summary>
        public int ReturnPeriod { get; set; }

        /// <summary>
        /// Дата возврата.
        /// </summary>
        public DateOnly? DateReturn { get; set; }

        /// <summary>
        /// Читатель.
        /// </summary>
        public string Reader { get; set; }

        /// <summary>
        /// Экземпляр.
        /// </summary>
        public string Instance { get; set; }
    }

    /// <summary>
    /// DTO для отображения выдачи книги.
    /// </summary>
    public class ShowBookLendingWithoutDetailsDto
    {
        /// <summary>
        /// Id выдачи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id читателя.
        /// </summary>
        public int ReaderId { get; set; }

        /// <summary>
        /// Id экземпляра.
        /// </summary>
        public int InstanceId { get; set; }

        /// <summary>
        /// Дата выдачи.
        /// </summary>
        public DateOnly DateIssue { get; set; }

        /// <summary>
        /// Срок возврата.
        /// </summary>
        public int ReturnPeriod { get; set; }

        /// <summary>
        /// Дата возврата.
        /// </summary>
        public DateOnly? DateReturn { get; set; }
    }

    /// <summary>
    /// DTO для добавления выдачи книги.
    /// </summary>
    public class AddBookLendingDto
    {
        /// <summary>
        /// Id читателя.
        /// </summary>
        public int ReaderId { get; set; }

        /// <summary>
        /// Id экземпляра.
        /// </summary>
        public int InstanceId { get; set; }

        /// <summary>
        /// Дата выдачи.
        /// </summary>
        public DateOnly DateIssue { get; set; }

        /// <summary>
        /// Срок возврата.
        /// </summary>
        public int ReturnPeriod { get; set; }

        /// <summary>
        /// Дата возврата.
        /// </summary>
        public DateOnly? DateReturn { get; set; }
    }

    /// <summary>
    /// DTO для обновления выдачи книги.
    /// </summary>
    public class UpdateBookLendingDto
    {
        /// <summary>
        /// Id выдачи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id читателя.
        /// </summary>
        public int ReaderId { get; set; }

        /// <summary>
        /// Id экземпляра.
        /// </summary>
        public int InstanceId { get; set; }

        /// <summary>
        /// Дата выдачи.
        /// </summary>
        public DateOnly DateIssue { get; set; }

        /// <summary>
        /// Срок возврата.
        /// </summary>
        public int ReturnPeriod { get; set; }

        /// <summary>
        /// Дата возврата.
        /// </summary>
        public DateOnly? DateReturn { get; set; }
    }
}
