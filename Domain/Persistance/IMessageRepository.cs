using Domain.Entities;

namespace Domain.Persistance
{
    public interface IMessageRepository
    {
        Task AddAsync(PrivateMessage message);
        Task<IEnumerable<PrivateMessage>> GetConversationAsync(Guid userId1, Guid userId2);
        Task<IEnumerable<PrivateMessage>> GetUserMessagesAsync(Guid userId);
    }
}
