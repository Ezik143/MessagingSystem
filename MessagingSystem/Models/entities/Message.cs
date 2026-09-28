namespace MessagingSystem.Models.Entities
{
    public enum MessageType
    {
        Text,
        Image,
        File
    }

    public class Message
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public Guid SenderId { get; set; }
        public string Content { get; set; } = string.Empty;
        public MessageType Type { get; set; }
        public Guid? ReplyToId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public Chat Chat { get; set; } = null!;
        public User Sender { get; set; } = null!;
        public Message? Replyto { get; set; }

        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
        public ICollection<ReadReceipt> ReadReceipts { get; set; } = new List<ReadReceipt>();
        public ICollection<Message> Replies { get; set; } = new List<Message>();

    }
}
