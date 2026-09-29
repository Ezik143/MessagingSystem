namespace MessagingSystem.Models.Request
{
    public class CreateGroupChatRequest
    {
        public required string Name { get; set; }
        public required List<Guid> UserIds { get; set; }
    }
}
