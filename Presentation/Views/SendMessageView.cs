using Domain.Entities;
using Infrastructure.Persistence;
using Presentation.Session;

namespace Presentation.Views
{
    public class SendMessageView
    {
        private readonly AppDbContext _context;

        public SendMessageView(AppDbContext context)
        {
            _context = context;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== SEND MESSAGE ===");

            var users = _context.Users
                .Where(u => u.Id != CurrentUser.User!.Id)
                .ToList();

            foreach (var u in users)
            {
                Console.WriteLine($"{u.Id} - {u.Email}");
            }

            Console.Write("Receiver ID: ");
            var receiverId = Guid.Parse(Console.ReadLine()!);

            Console.Write("Message: ");
            var content = Console.ReadLine();

            var receiver = users.First(u => u.Id == receiverId);

            var message = new PrivateMessage(
                CurrentUser.User!,
                receiver,
                content!
            );

            _context.Messages.Add(message);
            _context.SaveChanges();

            Console.WriteLine("Message sent.");
            Console.ReadKey();
        }
    }
}
