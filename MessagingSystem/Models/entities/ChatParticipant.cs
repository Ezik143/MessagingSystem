namespace MessagingSystem.Models.Entities
{
    public enum ChatParticipantRole
    {
        Admin,
        Member
    }

    public class ChatParticipant
    {
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; } = null!;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public ChatParticipantRole Role { get; set; }
        public Guid? LastReadMessageId { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
