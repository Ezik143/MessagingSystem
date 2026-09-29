using MessagingSystem.Models.entities.DTO.Response;
using MessagingSystem.Models.Entities;

namespace MessagingSystem.Models.Response
{
    public sealed record ChatResponse(
        Guid Id,
        ChatType Type,
        string? Name,
        User Creator,
        DateTime CreatedAt,
        IReadOnlyList<ParticipantResponse> Participants
    );
}
