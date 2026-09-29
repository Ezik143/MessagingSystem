namespace MessagingSystem.Models.entities.DTO.Response
{
    public sealed record ParticipantResponse
    (
        Guid ChatId,
        Guid UserId
        );
}
