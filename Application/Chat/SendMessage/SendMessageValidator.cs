using Application.Common.Validation;

namespace Application.Chat.SendMessage
{
    public class SendMessageValidator
    {
        public ValidationResult Validate(SendMessageCommand command)
        {
            var result = new ValidationResult();

            if (command.SenderId == Guid.Empty)
                AddError(result, "SenderId is required", "SENDER_REQUIRED");

            if (command.ReceiverId == Guid.Empty)
                AddError(result, "ReceiverId is required", "RECEIVER_REQUIRED");

            if (command.SenderId == command.ReceiverId)
                AddError(result, "Cannot send message to yourself", "SELF_MESSAGE");

            if (string.IsNullOrWhiteSpace(command.Content))
                AddError(result, "Message content is required", "CONTENT_REQUIRED");

            return result;
        }

        private static void AddError(
            ValidationResult result,
            string message,
            string code)
        {
            result.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Message = message,
                Code = code
            });
        }
    }
}
