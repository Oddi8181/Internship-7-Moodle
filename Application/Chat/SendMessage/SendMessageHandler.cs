using Application.Common.Model;
using Application.Common.Validation;
using Domain.Entities;
using Domain.Persistance;

namespace Application.Chat.SendMessage
{
    public class SendMessageHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly SendMessageValidator _validator;

        public SendMessageHandler(IUserRepository userRepository,IMessageRepository messageRepo, SendMessageValidator validator)
        {
            _userRepository = userRepository;
            _messageRepository = messageRepo;
            _validator = validator;
        }

        public async Task<Result<bool>> Handle(SendMessageCommand command)
        {
            var validation = _validator.Validate(command);
            if (validation.HasErrors)
                return Result<bool>.Failure(validation);

            var sender = await _userRepository.GetByIdAsync(command.SenderId);
            var receiver = await _userRepository.GetByIdAsync(command.ReceiverId);
            if (sender == null || receiver == null)
                return NotFound();
            
            var message = new PrivateMessage
            {
                SenderId = command.SenderId,
                ReceiverId = command.ReceiverId,
                Content = command.Content,
                SentAt = DateTime.UtcNow
            };
            await _messageRepository.AddAsync(message);
            return Result<bool>.Success(true);
        }

        private Result<bool> NotFound()
        {
            var validation = new ValidationResult();
            validation.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Message = "User not found",
                Code = "USER_NOT_FOUND"
            });

            return Result<bool>.Failure(validation);
        }
    }
}
