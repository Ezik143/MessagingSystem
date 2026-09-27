namespace MessagingSystem.Models.Entities
{
    public enum ReadReceiptStatus
    {
        Delivered,
        Read
    }

    public class ReadReceipt
    {
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
        public ReadReceiptStatus Status { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
