namespace MessagingSystem.Models.Request
{
    public class CreateDirectChatRequest
    {
        public required Guid OtherUserId { get; set; }
    }
}
