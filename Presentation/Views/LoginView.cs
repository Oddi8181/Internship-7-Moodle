using Application.Authentication.Login;
using Presentation.Session;

namespace Presentation.Views
{
    public class LoginView
    {
        private readonly LoginHandler _handler;

        public LoginView(LoginHandler handler)
        {
            _handler = handler;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN ===");

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            var result = _handler.HandleAsync(new LoginCommand
            {
                Email = email!,
                Password = password!
            }).GetAwaiter().GetResult();

            if (!result.IsSuccess)
            {
                Console.WriteLine("Login failed.");
                Console.ReadKey();
                return;
            }

            CurrentUser.User = result.Value;
        }
    }
}

