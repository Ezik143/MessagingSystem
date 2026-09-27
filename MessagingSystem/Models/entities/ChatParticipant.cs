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
        public Guid UserId { get; set; }
        public ChatParticipantRole Role { get; set; }
        public Guid? LastReadMessageId { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
