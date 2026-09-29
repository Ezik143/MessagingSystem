namespace MessagingSystem.Models.Request
{
    public class UpdateChatRequest
    {
        public required string Name { get; set; }
        public required List<Guid> UserIds { get; set; }
    }
}
