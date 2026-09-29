using MessagingSystem.Data;
using MessagingSystem.Models.entities.DTO.Response;
using MessagingSystem.Models.Entities;
using MessagingSystem.Models.Request;
using MessagingSystem.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessagingSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ChatsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ChatResponse>> GetById(Guid id)
        {
            var chat = await _db.Chats
                .Include(c => c.Creator)
                .Include(c => c.Participants)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (chat is null)
            {
                return NotFound();
            }

            var response = new ChatResponse(
                chat.Id,
                chat.Type,
                chat.Name,
                chat.Creator,
                chat.CreatedAt,
                chat.Participants
                    .Select(p => new ParticipantResponse(
                        p.ChatId,
                        p.UserId))
                    .ToList());

            return Ok(response);
        }

        [HttpPost("direct")]
        public async Task<ActionResult<ChatResponse>> CreateDirectChat(
            Guid creatorId,
            CreateDirectChatRequest request)
        {
            if (creatorId == request.OtherUserId)
            {
                return BadRequest("You cannot create a chat with yourself.");
            }

            var creator = await _db.Users.FindAsync(creatorId);
            var otherUser = await _db.Users.FindAsync(request.OtherUserId);

            if (creator is null || otherUser is null)
            {
                return NotFound("One or both users do not exist.");
            }

            var chat = new Chat
            {
                Id = Guid.NewGuid(),
                Type = ChatType.Direct,
                Name = null,
                CreatedBy = creatorId,
                CreatedAt = DateTime.UtcNow
            };

            chat.Participants.Add(new ChatParticipant
            {
                ChatId = chat.Id,
                UserId = creatorId,
                Role = ChatParticipantRole.Member,
                JoinedAt = DateTime.UtcNow
            });

            chat.Participants.Add(new ChatParticipant
            {
                ChatId = chat.Id,
                UserId = request.OtherUserId,
                Role = ChatParticipantRole.Member,
                JoinedAt = DateTime.UtcNow
            });

            _db.Chats.Add(chat);
            await _db.SaveChangesAsync();

            var response = new ChatResponse(
                chat.Id,
                chat.Type,
                chat.Name,
                creator,
                chat.CreatedAt,
                chat.Participants
                    .Select(p => new ParticipantResponse(
                        p.ChatId,
                        p.UserId))
                    .ToList());

            return CreatedAtAction(
                nameof(GetById),
                new { id = chat.Id },
                response);
        }
    }
}
