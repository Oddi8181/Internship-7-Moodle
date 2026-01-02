using Application.Common.Model;
using Domain.Entities;
using Domain.Persistance;

namespace Application.Chat.GetConversationMessages
{
    public class GetMessageHandler
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public GetMessageHandler(
            IMessageRepository messageRepository,
            IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }
        public async Task<Result<IEnumerable<MessageDto>>> HandleAsync(
        Guid currentUserId,
        Guid otherUserId)
        {
            var messages = await _messageRepository
                .GetConversationAsync(currentUserId, otherUserId);

            var users = new Dictionary<Guid, User>();

            async Task<User?> GetUser(Guid id)
            {
                if (!users.ContainsKey(id))
                    users[id] = await _userRepository.GetByIdAsync(id);
                return users[id];
            }

            var result = new List<MessageDto>();

            foreach (var m in messages.OrderBy(m => m.SentAt))
            {
                var sender = await GetUser(m.SenderId);
                if (sender == null) continue;

                result.Add(new MessageDto
                {
                    SenderId = sender.Id,
                    SenderEmail = sender.Email,
                    Content = m.Content,
                    SentAt = m.SentAt
                });
            }

            return Result<IEnumerable<MessageDto>>.Success(result);
        }
    }
}
