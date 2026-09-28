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
        public Message Message { get; set; } = null!;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public ReadReceiptStatus Status { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
