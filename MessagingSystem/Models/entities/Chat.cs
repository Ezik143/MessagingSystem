namespace MessagingSystem.Models.Entities
{
    public enum ChatType
    {
        Direct,
        Group
    }

    public class Chat
    {
        public Guid Id { get; set; }
        public ChatType Type { get; set; }
        public string? Name { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public User Creator { get; set; } = null!;
        public ICollection<Message> Messages = new List<Message>();
        public ICollection<ChatParticipant> Participants = new List<ChatParticipant>();
    }
}
