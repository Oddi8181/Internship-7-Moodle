using Presentation.Views;

namespace Presentation.Menus
{
    public class AuthMenu
    {
        private readonly LoginView _loginView;
        private readonly RegisterView _registerView;

        public AuthMenu(LoginView loginView, RegisterView registerView)
        {
            _loginView = loginView;
            _registerView = registerView;
        }

        public void Show()
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("0. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _loginView.Show();
                    break;
                case "2":
                    _registerView.Show();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
