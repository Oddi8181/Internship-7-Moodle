namespace Application.Chat.GetConversations
{
    public class GetConversationDto
    {
        public Guid UserId { get; init; }
        public string Email { get; init; }
        public DateTime LastMessageAt { get; init; }
        public string LastMessagePreview { get; init; }
    }
}
