namespace Domain.Entities
{
    public class PrivateMessage
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }
        public User Sender { get; set; }

        public Guid ReceiverId { get; set; }
        public User Receiver { get; set; }

        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        public PrivateMessage() { }
        public PrivateMessage(User sender, User receiver, string content)
        {
            Id = Guid.NewGuid();
            Sender = sender;
            SenderId = sender.Id;
            Receiver = receiver;
            ReceiverId = receiver.Id;
            Content = content;
            SentAt = DateTime.UtcNow;
        }
    }
}