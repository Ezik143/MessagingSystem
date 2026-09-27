namespace MessagingSystem.Models.Entities
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public int FileSize { get; set; }
    }
}
