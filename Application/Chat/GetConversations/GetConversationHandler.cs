using Application.Common.Model;
using Domain.Persistance;
using System.Reflection.Metadata.Ecma335;

namespace Application.Chat.GetConversations
{
    public class GetConversationHandler
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public GetConversationHandler(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<IEnumerable<GetConversationDto>>> HandleAsync(Guid userId)
        {
            var messages = await _messageRepository.GetUserMessagesAsync(userId);

            var conversations = messages
                .GroupBy(m =>
                    m.SenderId == userId ? m.ReceiverId : m.SenderId)
                .Select(g =>
                {
                    var lastMessage = g.OrderByDescending(m => m.SentAt).First();
                    return new
                    {
                        OtherUserId = g.Key,
                        LastMessage = lastMessage
                    };
                })
                .OrderByDescending(x => x.LastMessage.SentAt)
                .ToList();

            var result = new List<GetConversationDto>();
            // ... (rest of your logic)
        }
    }
}
