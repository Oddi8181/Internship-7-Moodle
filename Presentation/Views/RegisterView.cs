using Application.Authentication.Login;
using Application.Authentication.Register;

namespace Presentation.Views
{
    public class RegisterView
    {
        private readonly RegisterHandler _handler;
        public RegisterView(RegisterHandler handler)
        {
            _handler = handler;
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTER STUDENT ===");

            Console.Write("First name: ");
            var first = Console.ReadLine()?.Trim();

            Console.Write("Last name: ");
            var last = Console.ReadLine()?.Trim();

            Console.Write("Email: ");
            var email = Console.ReadLine()?.Trim();

            Console.Write("Password: ");
            var password = Console.ReadLine()?.Trim();

            Console.Write("Repeat Password: ");
            var repeatPassword = Console.ReadLine()?.Trim();

            
            var result = _handler.HandleAsync(new RegisterCommand
            {
                FirstName = first!,
                LastName = last!,
                Email = email!,
                Password = password!,
                RepeatPassword = repeatPassword!,
                Captcha = "1234",
                ExpectedCaptcha = "1234"
            }).Result;

            if (!result.IsSuccess)
            {
                Console.WriteLine("Registration failed.");
                foreach (var error in result.ValidationResult.ValidationItems())
                    Console.WriteLine($"{error.Code}: {error.Message}");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Registration successful!");
            Console.ReadKey();
        }
    }
}
