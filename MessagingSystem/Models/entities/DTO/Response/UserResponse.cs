namespace MessagingSystem.Models.Response;

public sealed record UserResponse(
    Guid Id,
    string FirebaseUid,
    string Username,
    string Email,
    string AvatarUrl,
    DateTime? LastSeenAt);