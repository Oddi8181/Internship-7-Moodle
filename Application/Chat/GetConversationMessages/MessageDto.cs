namespace Application.Chat.GetConversationMessages
{
    public class MessageDto
    {
        public Guid SenderId { get; init; }
        public string SenderEmail { get; init; }
        public string Content { get; init; }
        public DateTime SentAt { get; init; }
    }
}
