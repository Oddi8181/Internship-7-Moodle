using Domain.Entities;
using Domain.Persistance;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class MessageRepository : IMessageRepository
{
    private readonly AppDbContext _context;

    public MessageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(PrivateMessage message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<PrivateMessage>> GetConversationAsync(
        Guid user1Id,
        Guid user2Id)
    {
        return await _context.Messages
            .Where(x =>
                (x.SenderId == user1Id && x.ReceiverId == user2Id) ||
                (x.SenderId == user2Id && x.ReceiverId == user1Id))
            .OrderBy(x => x.SentAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<PrivateMessage>> GetUserMessagesAsync(Guid userId)
    {
        return await _context.Messages
            .Where(x => x.SenderId == userId || x.ReceiverId == userId)
            .ToListAsync();
    }
}
