using System.Security.Claims;
using MessagingSystem.Data;
using MessagingSystem.Models.Entities;
using MessagingSystem.Models.Request;
using MessagingSystem.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessagingSystem.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public sealed class AuthController : ControllerBase
{
    private readonly AppDbContext _db;

    public AuthController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost("me")]
    public async Task<ActionResult<UserResponse>> SyncCurrentUser(SyncUserRequest request)
    {
        var firebaseUid = User.FindFirst("user_id")?.Value
            ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            ?? User.FindFirst("sub")?.Value;

        if (string.IsNullOrWhiteSpace(firebaseUid))
        {
            return Unauthorized("The Firebase token does not contain a user ID.");
        }

        var email = User.FindFirst(ClaimTypes.Email)?.Value
            ?? User.FindFirst("email")?.Value
            ?? string.Empty;

        var user = await _db.Users.FirstOrDefaultAsync(u => u.FirebaseUid == firebaseUid);
        var isNewUser = user is null;

        if (user is null)
        {
            user = new User
            {
                Id = Guid.NewGuid(),
                FirebaseUid = firebaseUid
            };
            _db.Users.Add(user);
        }

        user.Username = request.Username;
        user.Email = email;
        user.AvatarUrl = request.AvatarUrl ?? string.Empty;
        user.LastSeenAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();

        var response = new UserResponse(
            user.Id,
            user.FirebaseUid,
            user.Username,
            user.Email,
            user.AvatarUrl,
            user.LastSeenAt);

        return isNewUser ? Created("api/auth/me", response) : Ok(response);
    }
}