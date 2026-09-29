using System.ComponentModel.DataAnnotations;

namespace MessagingSystem.Models.Request;

public sealed record SyncUserRequest
{
    [Required, MaxLength(100)]
    public required string Username { get; init; }

    [MaxLength(500)]
    public string? AvatarUrl { get; init; }
}