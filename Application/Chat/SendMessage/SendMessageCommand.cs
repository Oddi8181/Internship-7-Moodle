namespace Application.Chat.SendMessage
{
    public class SendMessageCommand
    {
        public Guid ReceiverId { get; init; }
        public Guid SenderId { get; init; }
        public string Content { get; init; }
    }
}
